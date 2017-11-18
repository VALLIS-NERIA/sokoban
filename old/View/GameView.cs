using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;
using System.IO;

namespace View {
    public partial class GameView : Form, IGameView {
        private IGame game => this.controller.Game;
        private IGameController controller;
        private FloorControl[,] floors;
        public GameView() { InitializeComponent(); }

        public GameView(IGameController controller) : this() { LoadController(controller); }

        public void Congraz() { MessageBox.Show("You Win!"); }

        public void LoadController(IGameController controller) {
            this.controller = controller;
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
        }

        public void Update(int x, int y, FloorType type) {
            this.floors[x, y].Type = type;
            this.floors[x, y].RefreshImage();
        }

        public void RefreshGame() => RefreshGame(0, 0, this.game.Width + this.game.Height);

        public void RefreshGame(int centerX, int centerY, int radix) {
            int xbegin = centerX - radix >= 0 ? centerX - radix : 0;
            int ybegin = centerY - radix >= 0 ? centerY - radix : 0;
            int xend = centerX + radix >= this.game.Width ? this.game.Width : centerX + radix;
            int yend = centerY + radix >= game.Height ? this.game.Height : centerY + radix;
            for (int x = xbegin; x < xend; x++) {
                for (int y = ybegin; y < yend; y++) {
                    var floor = this.floors[x, y];
                    floor.Type = this.game[x, y];
                    floor.RefreshImage();
                }
            }
            this.stepTextBox.Text = game.MoveCount.ToString();
            if (this.game.IsWin()) {
                Congraz();
            }
            this.stepTextBox.Focus();
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