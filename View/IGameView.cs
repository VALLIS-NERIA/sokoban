using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View {
    interface IGameView {
        void RefreshGame();
        void Congraz();
        void LoadGame(IGame game);
    }
}