using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    interface IGameController {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        void Restart();
        void Load();
        void Save();
    }
}
