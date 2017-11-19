using System;
using System.Collections.Generic;
using System.Drawing;
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
using Sokoban.Model;

namespace WpfGameView {
    /// <summary>
    /// FloorControl.xaml 的交互逻辑
    /// </summary>
    public partial class FloorControl : UserControl {
        public FloorControl() { InitializeComponent(); }

        private static BitmapImage block = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/block.png"));
        private static BitmapImage goal = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/goal.png"));
        private static BitmapImage player = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/player.png"));
        private static BitmapImage empty = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/empty.png"));
        private static BitmapImage playerOnGoal = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/playerOnGoal.png"));
        private static BitmapImage blockOnGoal = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/blockOnGoal.png"));
        private static BitmapImage wall = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/wall.png"));
        private static BitmapImage okRight = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/okRight.png"));
        private static BitmapImage okLeft = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/okLeft.png"));
        private static BitmapImage noRight = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/noRight.png"));
        private static BitmapImage noLeft = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/noLeft.png"));
        private static BitmapImage okUp = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/okUp.png"));
        private static BitmapImage okDown = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/okDown.png"));
        private static BitmapImage noUp = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/noUp.png"));
        private static BitmapImage noDown = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/noDown.png"));
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
            switch (Type) {
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