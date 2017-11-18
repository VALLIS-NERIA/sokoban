using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller {
    public interface IGameController {
        IGame Game { get; }
        bool Move(Direction direction);
        void Restart();
        void Load(string levelString);
        void LoadGame(IGame game);
        string Save();
        bool Undo();
    }
}
