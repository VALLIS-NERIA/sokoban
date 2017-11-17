using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public class FilerController :IFilerController {
        private IFiler filer;
        public void SetFiler(IFiler filer) { this.filer = filer; }
        public string LoadFile(string fileName) { return this.filer.LoadFile(fileName); }
        public void SaveToFile(IFileable fileable, string fileName) { throw new NotImplementedException(); }
    }
}
