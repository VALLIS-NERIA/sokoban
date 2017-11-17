using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public interface IGameController {
        bool Move(Direction direction);
        void Restart();
        void Load(string levelString);
        void SetGame(IGame game);
        string Save();
        bool Undo();
    }
}
