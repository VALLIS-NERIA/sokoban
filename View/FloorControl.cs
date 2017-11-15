﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Properties;
using Model;

namespace View {
    public partial class FloorControl : UserControl {
        public FloorControl() { InitializeComponent(); }
        public FloorType Type;

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

        private void FloorControl_Enter(object sender, EventArgs e) {

        }
    }
}

