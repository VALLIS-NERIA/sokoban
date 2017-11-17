using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.View;


namespace Sokoban.Model {
    public enum Direction {
        Up,
        Down,
        Left,
        Right
    }

    public interface IGame : IFileable {
        int MoveCount { get; }

        bool IsWin();
        bool Move(Direction direction);
        void LoadLevel(string levelString);
        void SetView(IGameView view);
        bool Undo();
        void Retry();
    }
}