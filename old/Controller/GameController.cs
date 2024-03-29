﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller {
    public class GameController : IGameController {
        private IGame game;
        //private IFiler filer;

        public IGame Game => this.game;
        public bool Move(Direction direction) { return this.game.Move(direction); }
        public void Restart() { this.game.Retry(); }

        public void Load(string levelString) { this.game.LoadLevel(levelString); }
        public void LoadGame(IGame game) { this.game = game; }
        public string Save() { throw new NotImplementedException(); }
        public bool Undo() { return this.game.Undo(); }
    }
}