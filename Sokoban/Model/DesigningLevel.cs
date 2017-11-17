using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model {
    public class DesigningLevel : IDesigningLevel {
        private FloorType[,] map;
        private IChecker checker;
        private IFiler filer;

        public DesigningLevel(IChecker checker, IFiler filer) {
            this.checker = checker;
            this.filer = filer;
        }

        public void CreateLevel(int width, int height) {
            this.map = new FloorType[width, height];
            this.Width = width;
            this.Height = height;
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    this.map[i, j] = FloorType.Empty;
                }
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public FloorType this[int x, int y] {
            get => this.map[x, y];
            set {
                switch (this.map[x, y]) {
                // handles cases of goal
                case FloorType.Goal:
                case FloorType.PlayerOnGoal:
                case FloorType.BlockOnGoal:
                    if (value == FloorType.Player) {
                        this.map[x, y] = FloorType.PlayerOnGoal;
                    }
                    if (value == FloorType.Block) {
                        this.map[x, y] = FloorType.BlockOnGoal;
                    }
                    else {
                        goto default;
                    }
                    return;
                default:
                    this.map[x, y] = value;
                    return;
                }
            }
        }

        public void SaveMe(string fileName) { this.filer.SaveFile(fileName, this); }
        public bool CheckValid() { return this.checker.CheckLevel(this); }
    }
}