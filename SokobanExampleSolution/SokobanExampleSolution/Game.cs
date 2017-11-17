using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace GameNS
{
    public class Game : IGame, IFileable
    {
        IFiler Filer;
        public Game(IFiler filer)
        {
            Filer = filer;
        }

        public int GetColumnCount()
        {
            throw new NotImplementedException();
        }

        public int GetMoveCount()
        {
            throw new NotImplementedException();
        }

        public int GetRowCount()
        {
            throw new NotImplementedException();
        }

        public bool IsFinished()
        {
            throw new NotImplementedException();
        }

        public void Load(string newLevel)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction moveDirection)
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public Parts WhatsAt(int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}
