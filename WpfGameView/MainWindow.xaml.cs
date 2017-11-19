using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sokoban.Controller;
using Sokoban.Model;
using Sokoban.View;

namespace WpfGameView {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, IGameView {
        public MainWindow() { InitializeComponent(); }

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

        public void RefreshGame() {
            foreach (FloorControl floor in this.floors) {
                this.stepTextBox.Text = this.moveCount.ToString();
                floor.RefreshImage();
            }
        }

        public void InitGame(IFileable game) {
            this.moveCount = 0;
            this.panel1.Children.Clear();
            this.panel1.Width = game.Width * new FloorControl().Width;
            this.floors = new FloorControl[game.Height, game.Width];
            for (int x = 0; x < game.Height; x++) {
                for (int y = 0; y < game.Width; y++) {
                    var floor = new FloorControl();
                    this.floors[x, y] = floor;
                    floor.Type = game[x, y];
                    this.panel1.Children.Add(floor);
                }
            }
        }

        public void Congraz() { MessageBox.Show("You Win!"); }

        public void SetController(IGameController controller) { this.controller = controller; }

        public void Update(int x, int y, FloorType type) { this.floors[x, y].Type = type; }
    }
}