using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Controller;
using Sokoban.Model;
using Sokoban.Properties;

namespace Sokoban.View {
    public partial class DesignerView : Form, IDesignerView {
        private DesignFloorControl[,] floors;
        private IDesignerController controller;
        private int width;
        private int height;
        private NewMapDialog newMapDialog = new NewMapDialog();

        public DesignerView() {
            InitializeComponent();
            this.buttons = new List<Button> {this.buttonEmpty, this.buttonBlock, this.buttonGoal, this.buttonPlayer, this.buttonWall};
        }

        private FloorType? selectedType;
        private FloorType? selectedType2;
        public FloorType? SelectedType => this.selectedType;
        public FloorType? SelectedType2 => this.selectedType2;
        private List<Button> buttons;
        private Dictionary<MouseButtons, Button> selectedButtons = new Dictionary<MouseButtons, Button>();

        public void InitDesigner(IFileable map) {
            this.panel1.Controls.Clear();
            this.floors = new DesignFloorControl[map.Width, map.Height];
            for (int x = 0; x < map.Width; x++) {
                for (int y = 0; y < map.Height; y++) {
                    var floor = new DesignFloorControl(x, y, this);
                    this.floors[x, y] = floor;
                    floor.Type = map[x, y];
                    this.panel1.Controls.Add(floor);
                    if (y == map.Height - 1) {
                        this.panel1.SetFlowBreak(floor, true);
                    }
                    this.floors[x, y].RefreshImage();
                }
            }
            if (this.panel2.Width < this.Width - 6)
                this.panel2.Left = (this.Width - this.panel2.Width) / 2 - 4;
        }

        private void CreateNewLevel(int width, int height) { this.controller.CreateNewLevel(width, height); }

        public void Update(int x, int y, FloorType type) {
            this.floors[x, y].Type = type;
            this.floors[x, y].RefreshImage();
        }

        public void SetController(IDesignerController controller) { this.controller = controller; }

        public void Set(int x, int y, FloorType type) {
            try {
                this.controller.Set(x, y, type);
            }
            catch (InvalidOperationException) {
                if (type != FloorType.Player) {
                    throw;
                }
                var result = MessageBox.Show("Seems there is already a player, would you like to move it to current position?"
                                             , "Conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    foreach (var floor in this.floors) {
                        if (floor.Type == FloorType.Player) {
                            this.controller.Set(floor.X, floor.Y, FloorType.Empty);
                            this.controller.Set(x, y, type);
                            break;
                        }
                    }
                }
            }
        }


        private void SetButtons(Button button, MouseEventArgs e) {
            MouseButtons mouseButton = e.Button;
            var img = (mouseButton == MouseButtons.Right) ? Resources.check2 : Resources.check;
            foreach (Button b in this.buttons) {
                if (this.selectedButtons.ContainsKey(mouseButton)) {
                    if (b == this.selectedButtons[mouseButton]) {
                        b.Image = null;
                    }
                }
            }
            this.selectedButtons[mouseButton] = button;
            button.Image = img;
        }

        private void buttonEmpty_Click(object sender, MouseEventArgs e) {
            if (((MouseEventArgs) e).Button == MouseButtons.Right) {
                this.selectedType2 = FloorType.Empty;
            }
            else {
                this.selectedType = FloorType.Empty;
            }
            SetButtons(this.buttonEmpty, e);
        }

        private void buttonWall_Click(object sender, MouseEventArgs e) {
            if (((MouseEventArgs) e).Button == MouseButtons.Right) {
                this.selectedType2 = FloorType.Wall;
            }
            else {
                this.selectedType = FloorType.Wall;
            }
            SetButtons(this.buttonWall, e);
        }

        private void buttonGoal_Click(object sender, MouseEventArgs e) {
            if (((MouseEventArgs) e).Button == MouseButtons.Right) {
                this.selectedType2 = FloorType.Goal;
            }
            else {
                this.selectedType = FloorType.Goal;
            }
            SetButtons(this.buttonGoal, e);
        }

        private void buttonBlock_Click(object sender, MouseEventArgs e) {
            if (((MouseEventArgs) e).Button == MouseButtons.Right) {
                this.selectedType2 = FloorType.Block;
            }
            else {
                this.selectedType = FloorType.Block;
            }
            SetButtons(this.buttonBlock, e);
        }

        private void buttonPlayer_Click(object sender, MouseEventArgs e) {
            if (((MouseEventArgs) e).Button == MouseButtons.Right) {
                this.selectedType2 = FloorType.Player;
            }
            else {
                this.selectedType = FloorType.Player;
            }
            SetButtons(this.buttonPlayer, e);
        }

        private void menuNew_Click(object sender, EventArgs e) {
            var result = this.newMapDialog.ShowDialog();
            if (result == DialogResult.OK) {
                CreateNewLevel(this.newMapDialog.Width, this.newMapDialog.Height);
            }
        }

        private void menuOpen_Click(object sender, EventArgs e) { this.controller.Load(); }

        private void menuSave_Click(object sender, EventArgs e) {
            var valid = this.controller.CheckValid();
            if (!valid) {
                var result = MessageBox.Show("There is something wrong in your level, do you wish continue saving?"
                                             , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) {
                    this.controller.Save();
                }
            }
            else {
                this.controller.Save();
            }
        }

        private void DesignerView_Resize(object sender, EventArgs e) {

        }
    }
}