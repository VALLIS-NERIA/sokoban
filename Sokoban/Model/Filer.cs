using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    sb.Append((char) fileable[x, y]);
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

        public bool SaveDialog(IFileable fileable) {
            var ret = this.view.SaveDialog(fileable);
            return ret == DialogResult.OK;
        }

        public bool LoadDialog() {
            this.loadedFile = null;
            var ret = this.view.LoadDialog();
            return ret == DialogResult.OK;
        }

        public void LoadFile(string fileName) { this.loadedFile = File.ReadAllText(fileName); }
    }
}