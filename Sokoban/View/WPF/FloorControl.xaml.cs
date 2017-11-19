using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Sokoban.Model;

namespace Sokoban.View.WPF {
    /// <summary>
    /// FloorControl.xaml 的交互逻辑
    /// </summary>
    public partial class FloorControl : UserControl {
        public FloorControl() { InitializeComponent(); }

        private static BitmapImage block = new BitmapImage(new Uri(@"/Sokoban;component/Resources/block.png",UriKind.Relative));
        private static BitmapImage goal = new BitmapImage(new Uri(@"/Sokoban;component/Resources/goal.png",UriKind.Relative));
        private static BitmapImage player = new BitmapImage(new Uri(@"/Sokoban;component/Resources/player.png",UriKind.Relative));
        private static BitmapImage empty = new BitmapImage(new Uri(@"/Sokoban;component/Resources/empty.png",UriKind.Relative));
        private static BitmapImage playerOnGoal = new BitmapImage(new Uri(@"/Sokoban;component/Resources/playerOnGoal.png",UriKind.Relative));
        private static BitmapImage blockOnGoal = new BitmapImage(new Uri(@"/Sokoban;component/Resources/blockOnGoal.png",UriKind.Relative));
        private static BitmapImage wall = new BitmapImage(new Uri(@"/Sokoban;component/Resources/wall.png",UriKind.Relative));
        private static BitmapImage okRight = new BitmapImage(new Uri(@"/Sokoban;component/Resources/okRight.png",UriKind.Relative));
        private static BitmapImage okLeft = new BitmapImage(new Uri(@"/Sokoban;component/Resources/okLeft.png",UriKind.Relative));
        private static BitmapImage noRight = new BitmapImage(new Uri(@"/Sokoban;component/Resources/noRight.png",UriKind.Relative));
        private static BitmapImage noLeft = new BitmapImage(new Uri(@"/Sokoban;component/Resources/noLeft.png",UriKind.Relative));
        private static BitmapImage okUp = new BitmapImage(new Uri(@"/Sokoban;component/Resources/okUp.png",UriKind.Relative));
        private static BitmapImage okDown = new BitmapImage(new Uri(@"/Sokoban;component/Resources/okDown.png",UriKind.Relative));
        private static BitmapImage noUp = new BitmapImage(new Uri(@"/Sokoban;component/Resources/noUp.png",UriKind.Relative));
        private static BitmapImage noDown = new BitmapImage(new Uri(@"/Sokoban;component/Resources/noDown.png",UriKind.Relative));
        private FloorType type;

        public FloorType Type {
            get => this.type;
            set {
                this.type = value;
                RefreshImage();
            }
        }

        public void RefreshImage() {
            BitmapImage bitmap;
            switch (this.Type) {
            case FloorType.Goal:
                bitmap = goal;
                break;
            case FloorType.Block:
                bitmap = block;
                break;
            case FloorType.BlockOnGoal:
                bitmap = blockOnGoal;
                break;
            case FloorType.Player:
                bitmap = player;
                break;
            case FloorType.PlayerOnGoal:
                bitmap = playerOnGoal;
                break;
            case FloorType.Wall:
                bitmap = wall;
                break;
            default:
            case FloorType.Empty:
                bitmap = empty;
                break;
            }
            this.BackgroundImage.Source = bitmap;
        }

        public void SetDirection(bool up, bool down, bool left, bool right) {
            this.OverlayImageN.Source = up ? okUp : noUp;
            this.OverlayImageS.Source = down ? okDown : noDown;
            this.OverlayImageW.Source = left ? okLeft : noLeft;
            this.OverlayImageE.Source = right ? okRight : noRight;
        }
    }
}