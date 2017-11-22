using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model {
    public enum FloorType {
        Wall = (int) '#',
        Empty = (int) '-',
        Player = (int) '@',
        Goal = (int) '.',
        Block = (int) '$',
        BlockOnGoal = (int) '*',
        PlayerOnGoal = (int) '+'
    };

    // Not IEnumerable<T> since multi-dimension arrays don't implement gerenic version
    public interface IFileable : System.Collections.IEnumerable {
        FloorType this[int x, int y] { get; }
        int Height { get; }
        int Width { get; }
    }
}