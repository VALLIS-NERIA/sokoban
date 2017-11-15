using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Checker : IChecker {
        public bool CheckLevel(IFileable fileable) {
            var width = fileable.Width;
            var height = fileable.Height;
            var blockc = 0;
            var goalc = 0;
            var playerc = 0;
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    switch (fileable[x, y]) {
                    case FloorType.Block:
                        blockc++;
                        break;
                    case FloorType.BlockOnGoal:
                        blockc++;
                        goto case FloorType.Goal;
                    case FloorType.Player:
                        playerc++;
                        break;
                    case FloorType.PlayerOnGoal:
                        playerc++;
                        goto case FloorType.Goal;
                    case FloorType.Goal:
                        goalc++;
                        break;
                    }
                }
            }
            return goalc == blockc && playerc == 1;
        }
    }
}