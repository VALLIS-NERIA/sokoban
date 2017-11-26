using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Other2 {
    public interface ModifiedIGameController :Controller.IGameController{
        bool Move(Direction direction);

        bool CanMove(Direction direction);

        void Restart();

        void Load();

        void SetGame(OtherPersonsIGame game);

        void Save();

        bool Undo();
    }
}