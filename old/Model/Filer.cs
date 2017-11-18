using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Filer : IFiler {
        public string Serialization(IFileable fileable) {
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

        public void Save(string fileName, IFileable fileable) {
            var str = Serialization(fileable);
            using (var sw = new StreamWriter(fileName)) {
                sw.Write(str);
            }
        }

        public string Load(string fileName) => File.ReadAllText(fileName);
    }
}