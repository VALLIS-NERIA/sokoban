using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public interface IFileable {
        FloorType this[int x, int y] { get; }
        int Row { get; }
        int Column { get; }
    }
}