using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Properties;
using Sokoban.Model;

namespace Sokoban.View {
    public partial class DesignFloorControl : Control {
        public DesignFloorControl() { InitializeComponent(); }

        public DesignFloorControl(int x, int y, IDesignerView view) : this() {
            this.X = x;
            this.Y = y;
            this.View = view;
        }

        public IDesignerView View { get; }
        public FloorType Type;
        public int X { get; }
        public int Y { get; }

        public void RefreshImage() {
            string resourceName = "";
            switch (Type) {
            case FloorType.Goal:
                resourceName = "goal";
                break;
            case FloorType.Block:
                resourceName = "block";
                break;
            case FloorType.BlockOnGoal:
                resourceName = "blockOnGoal";
                break;
            case FloorType.Empty:
                resourceName = "empty";
                break;
            case FloorType.Player:
                resourceName = "player";
                break;
            case FloorType.PlayerOnGoal:
                resourceName = "playerOnGoal";
                break;
            case FloorType.Wall:
                resourceName = "wall";
                break;
            }
            object obj = Resources.ResourceManager.GetObject(resourceName);
            this.BackgroundImage = (Bitmap) obj;
        }

        private void FloorControl_Load(object sender, EventArgs e) { RefreshImage(); }

        private void FloorControl_Enter(object sender, EventArgs e) { }

        private void DesignFloorControl_Click(object sender, EventArgs e) {
            if (((MouseEventArgs) e).Button == MouseButtons.Right) {
                this.View.Set(this.X, this.Y, (FloorType) this.View.SelectedType2);

            }
            else {
                if (this.View.SelectedType != null) {
                    this.View.Set(this.X, this.Y, (FloorType) this.View.SelectedType);
                }
            }
        }
    }
}