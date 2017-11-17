using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Controller;
using Sokoban.Model;

namespace Sokoban.View {
    public interface IGameView {
        void RefreshGame();
        void InitGame(IFileable game);
        void Congraz();
        void SetController(IGameController game);
        void Update(int x, int y, FloorType type);
    }
}