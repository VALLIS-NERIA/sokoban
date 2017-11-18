using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    interface IDesigningLevel : IFileable {
        void CreateLevel(int width, int height);
        new FloorType this[int x, int y] { get; set; }
        void SaveMe(string fileName);
        bool CheckValid();
    }
}