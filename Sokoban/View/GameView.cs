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

namespace Sokoban.View {
    public partial class GameView : Form, IGameView {
        private IGameController controller;
        private FloorControl[,] floors;
        public GameView() { InitializeComponent(); }

        public GameView(IGameController controller) : this() { SetController(controller); }
        protected override bool ProcessDialogKey(Keys keyData) => false;
        public void Congraz() { MessageBox.Show("You Win!"); }

        public void SetController(IGameController controller) {
            this.controller = controller;
        }

        public void InitGame(IFileable game) {
            this.floors = new FloorControl[game.Width, game.Height];
            for (int x = 0; x < game.Width; x++) {
                for (int y = 0; y < game.Height; y++) {
                    var floor = new FloorControl();
                    this.floors[x, y] = floor;
                    floor.Type = game[x, y];
                    this.panel1.Controls.Add(floor);
                    if (y == game.Height - 1) {
                        this.panel1.SetFlowBreak(floor, true);
                    }
                }
            }
            RefreshGame();
        }

        public void Update(int x, int y, FloorType type) {
            this.floors[x, y].Type = type;
            this.floors[x, y].RefreshImage();
        }

        public void RefreshGame() {
            foreach (FloorControl floor in this.floors) {
                floor.RefreshImage();
            }
        }

        private void GameView_Load(object sender, EventArgs e) { }

        private void GameView_KeyDown(object sender, KeyEventArgs e) {
            bool moved = false;
            if (e.Control == true && e.KeyCode == Keys.Z) {
                this.controller.Undo();
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
                RefreshGame();
            }
        }

        private void retryButton_Click(object sender, EventArgs e) {
            this.controller.Restart();
            RefreshGame();
        }

        private void undoButton_Click(object sender, EventArgs e) {
            this.controller.Undo();
            RefreshGame();
        }

        private void loadButton_Click(object sender, EventArgs e) { new LoadDialog().ShowDialog(); }
    }
}