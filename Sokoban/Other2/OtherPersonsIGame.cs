using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Other2 {
    public interface OtherPersonsIGame:Model.IFileable {
        void Move(Model.Direction moveDirection);

        int GetMoveCount();

        void Undo();

        void Restart();

        bool IsFinished();

        void Load(string newLevel);

        string GetMoveHistory();

        double DisplayTime();

    }

}
