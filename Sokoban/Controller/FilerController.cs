using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public class FilerController : IFilerController {
        private IFiler filer;

        public void SetFiler(IFiler filer) { this.filer = filer; }

        public string LoadFile(string fileName) {
            this.filer.LoadFile(fileName);
            return this.filer.LoadedFile;
        }

        public void SaveToFile(IFileable fileable, string fileName) { this.filer.SaveFile(fileName, fileable); }
    }
}