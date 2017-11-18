using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller {
    public interface IFilerController {
        IFiler Filer { get; }
        void SetFiler(IFiler filer);
        string LoadFile(string fileName);
        void SaveToFile(IFileable fileable, string fileName);
    }
}