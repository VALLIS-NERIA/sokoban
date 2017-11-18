using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public enum FloorType {
        Wall = (int) '#',
        Empty = (int) '-',
        Player = (int) '@',
        Goal = (int) '.',
        Block = (int) '$',
        BlockOnGoal = (int) '*',
        PlayerOnGoal = (int) '+'
    };

    public interface IFileable {
        FloorType this[int x, int y] { get; }
        int Height { get; }
        int Width { get; }
    }
}