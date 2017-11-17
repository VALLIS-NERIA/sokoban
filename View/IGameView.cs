﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Model;

namespace View {
    public interface IGameView {
        void RefreshGame();
        void Congraz();
        void LoadController(IGameController game);
        void Update(int x, int y, FloorType type);
    }
}

