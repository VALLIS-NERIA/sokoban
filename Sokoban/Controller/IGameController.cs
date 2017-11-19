using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public interface IGameController {
        bool Move(Direction direction);

        bool CanMove(Direction direction);

        void Restart();

        void Load();

        void SetGame(IGame game);

        void Save();

        bool Undo();
    }
}