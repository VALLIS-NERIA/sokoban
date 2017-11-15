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
using System.IO;

namespace View {
    public partial class GameView : Form, IGameView {
        public GameView() { InitializeComponent(); }
        private IGame game;
        public void Congraz() { MessageBox.Show("You Win!"); }

        private FloorControl[,] floors;

        public void LoadGame(IGame game) {
            this.floors = new FloorControl[game.Width, game.Height];
            this.game = game;
            for (int x = 0; x < game.Width; x++) {
                for (int y = 0; y < game.Height; y++) {
                    var floor = new FloorControl();
                    this.floors[x, y] = floor;
                    floor.Type = game[x, y];
                    this.panel1.Controls.Add(floor);
                    floor.KeyDown += (s, e) => { MessageBox.Show($"{x},{y}"); };
                    if (y == game.Height - 1) {
                        this.panel1.SetFlowBreak(floor, true);
                    }
                }
            }
        }

        public void RefreshGame() {
            for (int x = 0; x < game.Width; x++) {
                for (int y = 0; y < game.Height; y++) {
                    var floor = this.floors[x, y];
                    floor.Type = this.game[x, y];
                    floor.RefreshImage();
                }
            }
        }

        private void GameView_Load(object sender, EventArgs e) {
            var game = new GameModel();
            game.LoadLevel(File.ReadAllText("level1.txt"));
            LoadGame(game);
        }

        private void GameView_KeyDown(object sender, KeyEventArgs e) {
            bool moved = false;
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right) {
                return;
            }
            if (this.game.IsWin()) {
                Congraz();
                return;
            }
            switch (e.KeyCode) {
            case Keys.Up:
                moved = this.game.Move(Direction.Up);
                break;
            case Keys.Down:
                moved = this.game.Move(Direction.Down);
                break;
            case Keys.Left:
                moved = this.game.Move(Direction.Left);
                break;
            case Keys.Right:
                moved = this.game.Move(Direction.Right);
                break;
            }

            if (moved) {
                RefreshGame();
            }
            if (this.game.IsWin()) {
                Congraz();
                return;
            }
        }

        private void GameView_Click(object sender, EventArgs e) { }

        private void GameView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) { }
    }
}