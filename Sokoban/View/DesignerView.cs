using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public DesignerView() { InitializeComponent(); }

        private FloorType? selectedType;
        public FloorType? SelectedType => this.selectedType;

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

        private void buttonEmpty_Click(object sender, EventArgs e) {
            this.selectedType = FloorType.Empty;
            this.buttonEmpty.Image = Resources.check;
            this.buttonBlock.Image = null;
            this.buttonGoal.Image = null;
            this.buttonPlayer.Image = null;
            this.buttonWall.Image = null;
        }

        private void buttonWall_Click(object sender, EventArgs e) {
            this.selectedType = FloorType.Wall;
            this.buttonEmpty.Image = null;
            this.buttonBlock.Image = null;
            this.buttonGoal.Image = null;
            this.buttonPlayer.Image = null;
            this.buttonWall.Image = Resources.check;
        }

        private void buttonGoal_Click(object sender, EventArgs e) {
            this.selectedType = FloorType.Goal;
            this.buttonEmpty.Image = null;
            this.buttonBlock.Image = null;
            this.buttonGoal.Image = Resources.check;
            this.buttonPlayer.Image = null;
            this.buttonWall.Image = null;
        }

        private void buttonBlock_Click(object sender, EventArgs e) {
            this.selectedType = FloorType.Block;
            this.buttonEmpty.Image = null;
            this.buttonBlock.Image = Resources.check;
            this.buttonGoal.Image = null;
            this.buttonPlayer.Image = null;
            this.buttonWall.Image = null;
        }

        private void buttonPlayer_Click(object sender, EventArgs e) {
            this.selectedType = FloorType.Player;
            this.buttonEmpty.Image = null;
            this.buttonBlock.Image = null;
            this.buttonGoal.Image = null;
            this.buttonPlayer.Image = Resources.check;
            this.buttonWall.Image = null;
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
    }
}