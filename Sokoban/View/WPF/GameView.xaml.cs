using System.Windows;
using System.Windows.Input;
using Sokoban.Controller;
using Sokoban.Model;

namespace Sokoban.View.WPF {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WPFGameView : Window, IGameView {
        public WPFGameView() { InitializeComponent(); }

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

            FloorControl initPlayer = null;
            for (int y = 0; y < game.Height; y++) {
                for (int x = 0; x < game.Width; x++) {
                    var floor = new FloorControl();
                    this.floors[x, y] = floor;
                    floor.Type = game[x, y];
                    if (floor.Type == FloorType.Player || floor.Type == FloorType.PlayerOnGoal) {
                        initPlayer = floor;
                    }
                    this.panel1.Children.Add(floor);
                }
            }
            var left = this.controller.CanMove(Direction.Left);
            var right = this.controller.CanMove(Direction.Right);
            var up = this.controller.CanMove(Direction.Up);
            var down = this.controller.CanMove(Direction.Down);
            initPlayer?.SetDirection(up, down, left, right);
        }

        public void Congraz() { MessageBox.Show("You Win!"); }

        public void SetController(IGameController controller) { this.controller = controller; }

        public void Update(int x, int y, FloorType type) {
            this.floors[x, y].Type = type;
            this.floors[x, y].ClearDirection();
            if (type == FloorType.Player || type == FloorType.PlayerOnGoal) {
                var left = this.controller.CanMove(Direction.Left);
                var right = this.controller.CanMove(Direction.Right);
                var up = this.controller.CanMove(Direction.Up);
                var down = this.controller.CanMove(Direction.Down);
                this.floors[x, y].SetDirection(up, down, left, right);
            }
        }

        private void Move(KeyEventArgs e) {
            bool moved = false;
            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.Z) {
                Undo();
                RefreshGame();
            }
            switch (e.Key) {
            case Key.Up:
                moved = this.controller.Move(Direction.Up);
                break;
            case Key.Down:
                moved = this.controller.Move(Direction.Down);
                break;
            case Key.Left:
                moved = this.controller.Move(Direction.Left);
                break;
            case Key.Right:
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

        private void undoButton_Click(object sender, RoutedEventArgs e) { Undo(); }

        private void retryButton_Click(object sender, RoutedEventArgs e) { Retry(); }

        private void loadButton_Click(object sender, RoutedEventArgs e) { this.controller.Load(); }

        private void saveButton_Click(object sender, RoutedEventArgs e) { this.controller.Save(); }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e) { Move(e); }
    }
}