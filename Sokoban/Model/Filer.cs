using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.View;

namespace Sokoban.Model {
    public class Filer : IFiler {
        private IFilerView view;
        private string loadedFile;
        public string LoadedFile => this.loadedFile;

        public string Serialize(IFileable fileable) {
            var sb = new StringBuilder();
            var width = fileable.Width;
            var height = fileable.Height;
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    sb.Append(fileable[x, y]);
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public void SetView(IFilerView view) { this.view = view; }

        public void SaveFile(string fileName, IFileable fileable) {
            var str = Serialize(fileable);
            using (var sw = new StreamWriter(fileName)) {
                sw.Write(str);
            }
        }

        public void SaveDialog(IFileable fileable) { this.view.SaveDialog(fileable); }
        public void LoadDialog() { this.view.LoadDialog(); }

        public void LoadFile(string fileName) { this.loadedFile = File.ReadAllText(fileName); }

    }
}