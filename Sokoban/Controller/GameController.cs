using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public class GameController : IGameController {
        private IGame game;

        public bool Move(Direction direction) => this.game.Move(direction);

        public bool CanMove(Direction direction) => this.game.CanMove(direction);

        public void Restart() => this.game.Retry();

        public void Load() => this.game.LoadDialog();

        public void SetGame(IGame game) { this.game = game; }

        public void Save() { this.game.SaveDialog(); }

        public bool Undo() => this.game.Undo();
    }
}