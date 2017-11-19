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
        public void Congraz() { throw new NotImplementedException(); }

        private List<FloorControl> floors;

        public void LoadGame(IGame game) {
            this.floors = new List<FloorControl>();
            this.game = game;
            for (int x = 0; x < game.Width; x++) {
                for (int y = 0; y < game.Height; y++) {
                    var floor = new FloorControl();
                    this.floors.Add(floor);
                    floor.Type = game[x, y];
                    this.panel1.Controls.Add(floor);
                    if (y == game.Height - 1) {
                        this.panel1.SetFlowBreak(floor, true);
                    }
                }
            }
        }

        public void RefreshGame() {
            foreach (FloorControl floor in this.floors) {
                floor.RefreshImage();
            }
        }

        private void GameView_Load(object sender, EventArgs e) {
            var game = new GameModel();
            game.LoadLevel(File.ReadAllText("level1.txt"));
            //LoadGame(game);
            this.label1.Focus();
        }

        private void GameView_KeyDown(object sender, KeyEventArgs e) {
            bool moved = false;
            switch (e.KeyCode) {
            case Keys.Up:
                moved=this.game.Move(Direction.Up);
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
        }

        private void GameView_Click(object sender, EventArgs e) {

        }
    }
}