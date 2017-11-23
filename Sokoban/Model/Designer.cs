using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.View;

namespace Sokoban.Model {
    public class DesignerModel : IDesigner {
        private IFiler filer;
        private int height;
        private FloorType[,] map;
        private string myFileName;
        private IDesignerView view;
        private int width;


        public DesignerModel(IFiler filer) { this.filer = filer; }

        public DesignerModel() { }

        public int Width => this.width;
        public int Height => this.height;

        public void CreateLevel(int width, int height) {
            this.map = new FloorType[width, height];
            this.width = width;
            this.height = height;
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    this.map[i, j] = FloorType.Empty;
                }
            }
            this.view?.InitDesigner(this);
        }

        public void LoadDialog() {
            this.filer.LoadDialog();
            if (this.filer.LoadedFile != null) {
                this.myFileName = this.filer.LoadedFile;
                LoadLevel(this.filer.LoadedFile);
            }
        }

        public void LoadLevel(string levelString) {
            // TODO: checker
            var lines = levelString.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            this.width = (from line in lines select line.Length).Max();
            this.height = lines.Length;
            this.map = new FloorType[this.width, this.height];

            for (int i = 0; i < this.height; i++) {
                for (int j = 0; j < this.width; j++) {
                    try {
                        this.map[j, i] = (FloorType) lines[i][j];
                    }
                    catch (IndexOutOfRangeException) {
                        this.map[j, i] = FloorType.Empty;
                    }
                }
            }
            this.view?.InitDesigner(this);
        }

        public void SetView(IDesignerView view) { this.view = view; }

        public void Save() {
            if (this.myFileName != null) {
                this.filer.SaveFile(this.myFileName, this);
            }
            else {
                SaveDialog();
            }
        }

        public void SaveDialog() { this.filer.SaveDialog(this); }


        public FloorType this[int x, int y] {
            get => this.map[x, y];
            set {
                if (value == FloorType.Player) {
                    foreach (FloorType type in this.map) {
                        if (type == FloorType.Player) {
                            throw new InvalidOperationException();
                        }
                    }
                }

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
                    break;
                default:
                    this.map[x, y] = value;
                    break;
                }
                ret:
                this.view?.Update(x, y, this.map[x, y]);
            }
        }

        public void SetFiler(IFiler filer) { this.filer = filer; }

        public bool CheckValid() {
            var goal = 0;
            var block = 0;
            var player = 0;
            foreach (FloorType type in this.map) {
                switch (type) {
                case FloorType.Goal:
                    goal++;
                    break;
                case FloorType.BlockOnGoal:
                    block++;
                    goto case FloorType.Goal;
                case FloorType.PlayerOnGoal:
                    player++;
                    goto case FloorType.Goal;
                case FloorType.Player:
                    player++;
                    break;
                case FloorType.Block:
                    block++;
                    break;
                }
            }
            return goal == block && player == 1;
        }

        public void Save(string fileName) { this.filer.SaveFile(fileName, this); }
        public IEnumerator GetEnumerator() { return this.map.GetEnumerator(); }
    }
}