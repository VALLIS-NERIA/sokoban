using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Sokoban.View;

namespace Sokoban.Model {
    public class GameModel : IGame {
        [DebuggerDisplay("{X},{Y}")]
        internal struct Vector2 {
            public int X;
            public int Y;

            public Vector2(int x, int y) {
                this.X = x;
                this.Y = y;
            }

            public static readonly Vector2 Up = new Vector2(0, -1);
            public static readonly Vector2 Right = new Vector2(1, 0);

            public static Vector2 operator +(Vector2 left, Vector2 right) { return new Vector2 {X = left.X + right.X, Y = left.Y + right.Y}; }

            public static Vector2 operator *(Vector2 point, int time) { return new Vector2 {X = point.X * time, Y = point.Y * time}; }

            public static Vector2 operator -(Vector2 value) { return new Vector2 {X = -value.X, Y = -value.Y}; }

            public static bool operator ==(Vector2 left, Vector2 right) { return left.X == right.X && left.Y == right.Y; }

            public static bool operator !=(Vector2 left, Vector2 right) { return !(left == right); }

            public bool Equals(Vector2 other) { return this.X == other.X && this.Y == other.Y; }

            public override bool Equals(object obj) {
                if (Object.ReferenceEquals(null, obj)) return false;
                return obj is Vector2 && this.Equals((Vector2) obj);
            }

            public override int GetHashCode() {
                unchecked {
                    return (this.X * 397) ^ this.Y;
                }
            }
        }

        private struct Memo {
            public Vector2 Location;
            public FloorType OldType;

            public Memo(int x, int y, FloorType type) {
                this.Location = new Vector2(x, y);
                this.OldType = type;
            }

            public Memo(GameModel map, int x, int y) {
                this.Location = new Vector2(x, y);
                this.OldType = map[x, y];
            }

            public Memo(GameModel map, Vector2 v) {
                this.Location = v;
                this.OldType = map[v];
            }

            public static implicit operator List<Memo>(Memo o) { return new List<Memo> {o}; }

            public static List<Memo> operator +(List<Memo> l, Memo o) {
                l.Add(o);
                return l;
            }
        }

        private int height;
        private int width;
        private FloorType[,] map;
        private List<Vector2> goals;
        private Vector2 player = new Vector2(-1, -1);
        private int moveCount = 0;
        private Stack<List<Memo>> undoList;
        private string currentGame;
        private IFiler filer;
        private IGameView view;

        public GameModel() {
            //this.LoadLevel("#####\n#---#\n#-@-#\n#---#\n#####"); 
            this.LoadLevel("######\r\n#-.--#\r\n#-$.-#\r\n#-$--#\r\n#-@--#\r\n######");
        }

        private FloorType this[Vector2 point] {
            get => this[point.X, point.Y];
            set => this[point.X, point.Y] = value;
        }

        public FloorType this[int x, int y] {
            get {
                if (x >= this.width || y >= this.height || x <= -1 || y <= -1) {
                    return FloorType.Wall;
                }
                return this.map[x, y];
            }
            set {
                // value can only be 
                switch (value) {
                case FloorType.Wall:
                case FloorType.BlockOnGoal:
                case FloorType.PlayerOnGoal:
                case FloorType.Goal:
                    throw new ArgumentException();
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
                    if (value == FloorType.Empty) {
                        this.map[x, y] = FloorType.Goal;
                    }
                    return;
                case FloorType.Wall:
                    return;
                default:
                    this.map[x, y] = value;
                    return;
                }
            }
        }

        public int Width => this.width;
        public int Height => this.height;
        public int MoveCount => this.moveCount;
        public int PlayerX => this.player.X;
        public int PlayerY => this.player.Y;
        public bool CheckBoxGoalEqual { get; set; } = false;

        public void Retry() { this.LoadLevel(this.currentGame); }

        public void LoadDialog() {
            this.filer.LoadDialog();
            if (this.filer.LoadedFile != null) {
                LoadLevel(this.filer.LoadedFile);
            }
        }

        public void LoadFile(string fileName) {
            if (this.filer == null) return;
            this.filer.LoadFile(fileName);
            if (this.filer.LoadedFile != null) {
                this.LoadLevel(this.filer.LoadedFile);
            }
        }

        public void SaveDialog() {
            if (this.filer == null) return;
            this.filer.SaveDialog(this);
        }

        public void SaveToFile(string fileName) {
            if (this.filer == null) return;
            this.filer.SaveFile(fileName,this);
        }

        public void LoadLevel(string levelString) {
            var lines = levelString.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            try {
                this.width = (from line in lines select line.Length).Max();
                this.height = lines.Length;
                this.map = new FloorType[this.width, this.height];

                this.goals = new List<Vector2>();
                this.player = new Vector2(-1, -1);
                this.undoList = new Stack<List<Memo>>();
                this.currentGame = levelString;
                this.moveCount = 0;
                var blockCount = 0;
                for (int x = 0; x < this.width; x++) {
                    for (int y = 0; y < this.height; y++) {
                        try {
                            this.map[x, y] = (FloorType) lines[y][x];
                            // detect player
                            switch (this.map[x, y]) {
                            case FloorType.Player:
                                if (this.player != new Vector2(-1, -1)) {
                                    throw new InvalidOperationException("too many players");
                                }
                                else {
                                    this.player = new Vector2(x, y);
                                }
                                break;
                            case FloorType.PlayerOnGoal:
                                this.goals.Add(new Vector2(x, y));
                                goto case FloorType.Player;
                            case FloorType.Goal:
                                this.goals.Add(new Vector2(x, y));
                                break;
                            case FloorType.BlockOnGoal:
                                this.goals.Add(new Vector2(x, y));
                                blockCount++;
                                break;
                            case FloorType.Block:
                                blockCount++;
                                break;
                            }
                        }
                        catch (IndexOutOfRangeException) {
                            this.map[x, y] = FloorType.Empty;
                        }
                    }
                }

                if (this.goals.Count != blockCount&& this.CheckBoxGoalEqual) {
                    throw new ArgumentException($"Goals({this.goals.Count}) and blocks({blockCount}) don't equal");
                }
                this.view?.InitGame(this);
            }
            // reset everything
            catch {
                this.width = (from line in lines select line.Length).Max();
                this.height = lines.Length;
                this.map = new FloorType[this.width, this.height];

                this.goals = new List<Vector2>();
                this.player = new Vector2(-1, -1);
                this.undoList = new Stack<List<Memo>>();
                this.currentGame = levelString;
                this.moveCount = 0;
                this.view?.InitGame(this);
                throw;
            }
        }

        public void SetView(IGameView view) {
            this.view = view;
            view.InitGame(this);
        }

        public void SetFiler(IFiler filer) { this.filer = filer; }

        public bool Move(Direction direction) {
            Vector2 vector;
            switch (direction) {
            case Direction.Up:
                vector = Vector2.Up;
                break;
            case Direction.Down:
                vector = -Vector2.Up;
                break;
            case Direction.Right:
                vector = Vector2.Right;
                break;
            default:
            case Direction.Left:
                vector = -Vector2.Right;
                break;
            }
            var ret = MoveTo(vector);
            if (ret != null) {
                this.moveCount += 1;
                this.undoList.Push(ret);
                return true;
            }
            return false;
        }

        public bool CanMove(Direction direction) {
            Vector2 vector;
            switch (direction) {
            case Direction.Up:
                vector = Vector2.Up;
                break;
            case Direction.Down:
                vector = -Vector2.Up;
                break;
            case Direction.Right:
                vector = Vector2.Right;
                break;
            default:
            case Direction.Left:
                vector = -Vector2.Right;
                break;
            }
            return CanMoveTo(vector);
        }

        public bool IsWin() {
            if (this.goals.Count == 0) return false;
            foreach (Vector2 position in this.goals) {
                if (this[position] != FloorType.BlockOnGoal) {
                    return false;
                }
            }
            return true;
        }

        public bool Undo() {
            if (this.undoList.Count == 0) return false;
            var last = this.undoList.Pop();
            var updates = new List<Vector2>();
            foreach (Memo memo in last) {
                // access map directly since "this" indexer has extra operations
                this.map[memo.Location.X, memo.Location.Y] = memo.OldType;
                if (memo.OldType == FloorType.Player) {
                    this.player = memo.Location;
                }
                updates.Add(memo.Location);
            }
            Update(updates.ToArray());
            this.moveCount++;
            return true;
        }

        private void Update(params Vector2[] posList) {
            if (this.view == null) return;
            foreach (Vector2 pos in posList) {
                if (pos.X < this.width && pos.X >= 0 && pos.Y < this.height && pos.Y >= 0) {
                    this.view.Update(pos.X, pos.Y, this[pos]);
                }
            }
            if (IsWin()) {
                this.view.Congraz();
            }
        }

        private List<Memo> MoveTo(Vector2 direction) {
            var oldPlayer = this.player;
            var up = this.player + direction;
            var upup = up + direction;
            var dest = this[up];

            List<Memo> undoMemo = new Memo(this, this.player)
                                  + new Memo(this, up) + new Memo(this, upup);
            switch (dest) {
            case FloorType.Wall:
                goto NoMove;
            case FloorType.Player:
            case FloorType.PlayerOnGoal:
                throw new InvalidOperationException("Impossible");

            // go
            case FloorType.Goal:
            case FloorType.Empty:
                // sample: go left
                // -@  =>  @-
                this[up] = FloorType.Player;
                this[this.player] = FloorType.Empty;
                this.player = up;
                goto Move;

            // push
            case FloorType.Block:
            case FloorType.BlockOnGoal:
                switch (this[upup]) {
                case FloorType.Goal:
                case FloorType.Empty:
                    // -$@  =>  $@-
                    this[upup] = FloorType.Block;
                    this[up] = FloorType.Player;
                    this[this.player] = FloorType.Empty;
                    this.player = up;
                    goto Move;
                default:
                    goto NoMove;
                }
            default:
                goto NoMove;
            }
            NoMove:
            return null;
            Move:
            // Update the view
            Update(oldPlayer, up, upup);
            return undoMemo;
        }

        private bool CanMoveTo(Vector2 direction) {
            var oldPlayer = this.player;
            var up = this.player + direction;
            var upup = up + direction;
            var dest = this[up];

            switch (dest) {
            case FloorType.Wall:
                goto NoMove;
            case FloorType.Player:
            case FloorType.PlayerOnGoal:
                throw new InvalidOperationException("Impossible");

            // go
            case FloorType.Goal:
            case FloorType.Empty:
                // sample: go left
                // -@  =>  @-
                goto Move;

            // push
            case FloorType.Block:
            case FloorType.BlockOnGoal:
                switch (this[upup]) {
                case FloorType.Goal:
                case FloorType.Empty:
                    // -$@  =>  $@-
                    goto Move;
                default:
                    goto NoMove;
                }
            default:
                goto NoMove;
            }
            NoMove:
            return false;
            Move:
            return true;
        }

        public IEnumerator GetEnumerator() { return this.map.GetEnumerator(); }
    }
}