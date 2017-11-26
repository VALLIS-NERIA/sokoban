using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Other {
    public interface OtherPersonsIGameView {
        void DisplayMenu();

        void RedrawLevel();

        void DrawGameControls();

        void DisplaySystemMessage(string msg);
    }
}
