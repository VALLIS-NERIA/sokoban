using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public class GameController : IGameController {
        private IGame game;

        public bool Move(Direction direction) { return this.game.Move(direction); }
        public void Restart() { this.game.Retry(); }
        public void Load() { this.game.Load(); }
        public void SetGame(IGame game) { this.game = game; }
        public void Save() { this.game.Save(); }
        public bool Undo() { return this.game.Undo(); }
    }
}