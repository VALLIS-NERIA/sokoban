using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sokoban.Model;

namespace UnitTest {
    [TestClass]
    public class UnitTest1 {
        #region move

        [TestMethod]
        public void MovePlayerUp() {
            string level = "#####\n#---#\n#-@-#\n#---#\n#####";
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Up);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MovePlayerRight() {
            string level = "#####\n#---#\n#-@-#\n#---#\n#####";
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 3;
            game.Move(Direction.Right);
            var actual = game.PlayerX;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MovePlayerDown() {
            string level = "#####\n#---#\n#-@-#\n#---#\n#####";
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 3;
            game.Move(Direction.Down);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MovePlayerLeft() {
            string level = "#####\n#---#\n#-@-#\n#---#\n#####";
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Left);
            var actual = game.PlayerX;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region moveToWall

        [TestMethod]
        public void MovePlayerUpToWall() {
            string level = "###\n#@#\n###"; // I'm surrounded with 8 walls! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Up);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MovePlayerDownToWall() {
            string level = "###\n#@#\n###"; // I'm surrounded with 8 walls! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Down);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MovePlayerLeftToWall() {
            string level = "###\n#@#\n###"; // I'm surrounded with 8 walls! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Left);
            var actual = game.PlayerX;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MovePlayerRightToWall() {
            string level = "###\n#@#\n###"; // I'm surrounded with 8 walls! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Right);
            var actual = game.PlayerX;
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region elementInRightLocation
        /*   x0 1 2 3 4
         *  y         
         *  0 # # # # #
         *  1 # - $ - #
         *  2 # - @ - #
         *  3 # - . - #
         *  4 # # # # #
         */
        [TestMethod]
        public void RightLocation_Wall() {
            string level = "#####\n#-$-#\n#-@-#\n#-.-#\n#####"; 
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = FloorType.Wall;
            var actual = game[0,1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightLocation_Block() {
            string level = "#####\n#-$-#\n#-@-#\n#-.-#\n#####"; 
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = FloorType.Block;
            var actual = game[2,1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightLocation_Goal() {
            string level = "#####\n#-$-#\n#-@-#\n#-.-#\n#####"; 
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = FloorType.Goal;
            var actual = game[2, 3];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightLocation_Player() {
            string level = "#####\n#-$-#\n#-@-#\n#-.-#\n#####"; 
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = FloorType.Player;
            var actual = game[2, 2];
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Block and Goals

        [TestMethod]
        public void SameBlockAndGoals() {
            string level = "@$."; //
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = true;
            var goal = 0;
            var block = 0;
            foreach (FloorType floor in game) {
                if (floor == FloorType.Goal) goal++;
                if (floor == FloorType.Block) block++;
            }
            var actual = goal == block;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GameWins() {
            string level = "@$."; //
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = true;
            game.Move(Direction.Right);
            var actual =game.IsWin();
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}