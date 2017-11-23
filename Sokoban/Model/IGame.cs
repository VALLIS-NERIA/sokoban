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
        /// <summary>
        /// How many steps you have moved.
        /// </summary>
        int MoveCount { get; }

        int PlayerX { get; }
        int PlayerY { get; }

        // wether this game should check the equality of box and goals.
        bool CheckBoxGoalEqual { get; set; }

        /// <summary>
        /// Check wether you have won this game.
        /// </summary>
        /// <returns>true = win</returns>
        bool IsWin();

        /// <summary>
        /// Move player to some direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>true = successfully moved.</returns>
        bool Move(Direction direction);

        /// <summary>
        /// Wether you are able to move player to given direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>true = can move</returns>
        bool CanMove(Direction direction);

        /// <summary>
        /// Load the given level from string.
        /// </summary>
        /// <param name="levelString"></param>
        void LoadLevel(string levelString);

        /// <summary>
        /// Shows a dialog and load a level.
        /// </summary>
        void LoadDialog();

        void LoadFile(string fileName);

        /// <summary>
        /// Shows a dialog and save your current game.
        /// </summary>
        void SaveDialog();

        void SaveToFile(string fileName);

        void SetView(IGameView view);
        void SetFiler(IFiler filer);

        /// <summary>
        /// Undo your last operation.
        /// </summary>
        /// <returns>false = you have reached the beginning</returns>
        bool Undo();

        /// <summary>
        /// Restart current level.
        /// </summary>
        void Retry();
    }
}