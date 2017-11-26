using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Other2 {
    public class ModifiedGameController : ModifiedIGameController {
        private Other2.OtherPersonsIGame game;
        private IFiler filer;

        public ModifiedGameController(IFiler filer) { this.filer = filer; }
        public bool Move(Direction direction) {

            var count0 = this.game.GetMoveCount();
            this.game.Move(direction);
            var count1 = this.game.GetMoveCount();
            return count1 != count0;
        }

        public bool CanMove(Direction direction) => true;// It doesn't matter since the WinForm GameView don't use this method.

        public void Restart() => this.game.Restart();

        public void Load() {
            var result = this.filer.LoadDialog();
            if (result == true) {
                this.game.Load(this.filer.LoadedFile);
            }
        }
        // nothing
        public void SetGame(IGame game) {  }

        public void SetGame(OtherPersonsIGame game) { this.game = game; }

        //oops, other person's game cannot save
        public void Save() {  }

        public bool Undo() {
            var count0 = this.game.GetMoveCount();
            this.game.Undo();
            var count1 = this.game.GetMoveCount();
            return count1 != count0;
        }
    }
}