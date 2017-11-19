using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Model;
using Sokoban.Controller;
using System.IO;
using Sokoban.Properties;

namespace Sokoban.View {
    public partial class GameView : Form, IGameView {
        private IGameController controller;
        private FloorControl[,] floors;
        private int _moveCount = 0;

        private int moveCount {
            get => this._moveCount;
            set {
                this._moveCount = value;
                this.stepTextBox.Text = this.moveCount.ToString();
            }
        }

        public GameView() { InitializeComponent(); }

        public GameView(IGameController controller) : this() { SetController(controller); }

        protected override bool ProcessDialogKey(Keys keyData) => false;

        public void Congraz() { MessageBox.Show("You Win!"); }

        public void SetController(IGameController controller) { this.controller = controller; }

        public void InitGame(IFileable game) {
            this.moveCount = 0;
            this.panel1.Controls.Clear();
            this.floors = new FloorControl[game.Height, game.Width];
            for (int x = 0; x < game.Height; x++) {
                for (int y = 0; y < game.Width; y++) {
                    var floor = new FloorControl();
                    this.floors[x, y] = floor;
                    floor.Type = game[x, y];
                    this.panel1.Controls.Add(floor);
                }
                this.panel1.SetFlowBreak(this.floors[x, game.Width - 1], true);
            }
            if (this.Width > this.panel1.Width) {
                this.panel1.Left = (this.Width - this.panel1.Width) / 4;
            }
            else {
                this.panel1.Left = 1;
            }
            if (this.Width > this.panel2.Width) {
                this.panel2.Left = (this.Width - this.panel2.Width) / 4;
            }
            else {
                this.panel2.Left = 1;
            }
            RefreshGame();
        }

        public void Update(int x, int y, FloorType type) {
            this.floors[x, y].Type = type;
            this.floors[x, y].RefreshImage();
            if (type == FloorType.Player || type== FloorType.PlayerOnGoal) {
                // TODO
            }
        }

        public void RefreshGame() {
            foreach (FloorControl floor in this.floors) {
                this.stepTextBox.Text = this.moveCount.ToString();
                floor.RefreshImage();
            }
        }


        private new void Move(KeyEventArgs e) {
            bool moved = false;
            if (e.Control == true && e.KeyCode == Keys.Z) {
                this.undoButton_Click(null, null);
                RefreshGame();
            }
            switch (e.KeyCode) {
            case Keys.Up:
                moved = this.controller.Move(Direction.Up);
                break;
            case Keys.Down:
                moved = this.controller.Move(Direction.Down);
                break;
            case Keys.Left:
                moved = this.controller.Move(Direction.Left);
                break;
            case Keys.Right:
                moved = this.controller.Move(Direction.Right);
                break;
            }

            if (moved) {
                this.moveCount++;
                //RefreshGame();
            }
        }

        private void Retry() {
            this.controller.Restart();
            //RefreshGame();
        }

        private void Undo() {
            var ret = this.controller.Undo();
            if (ret) {
                //RefreshGame();
                this.moveCount++;
            }
        }


        private void GameView_KeyDown(object sender, KeyEventArgs e) { Move(e); }

        private void retryButton_Click(object sender, EventArgs e) { Retry(); }

        private void undoButton_Click(object sender, EventArgs e) { Undo(); }

        private void loadButton_Click(object sender, EventArgs e) { this.controller.Load(); }

        private void saveButton_Click(object sender, EventArgs e) { this.controller.Save(); }

        private void GameView_Resize(object sender, EventArgs e) {  }
    }
}