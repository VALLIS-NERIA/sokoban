using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public interface IFilerController {
        void SetFiler(IFiler filer);

        string LoadFile(string fileName);

        void SaveToFile(IFileable fileable, string fileName);
    }
}