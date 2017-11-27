using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sokoban.Controller;
using Sokoban.Model;
using Sokoban.View;

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
            var actual = game[0, 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightLocation_Block() {
            string level = "#####\n#-$-#\n#-@-#\n#-.-#\n#####";
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = FloorType.Block;
            var actual = game[2, 1];
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
            var actual = game.IsWin();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Player Out Of Map

        [TestMethod]
        public void PlayerExit_Up() {
            string level = "@"; // Noooooo there is nothing around me! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 0;
            game.Move(Direction.Up);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerExit_Down() {
            string level = "@"; // Noooooo there is nothing around me! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 0;
            game.Move(Direction.Down);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerExit_Left() {
            string level = "@"; // Noooooo there is nothing around me! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 0;
            game.Move(Direction.Left);
            var actual = game.PlayerX;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerExit_Right() {
            string level = "@"; // Noooooo there is nothing around me! QAQ
            var game = new GameModel();
            game.LoadLevel(level);
            var expected = 0;
            game.Move(Direction.Right);
            var actual = game.PlayerX;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Push Box Out of Map

        [TestMethod]
        public void BoxExit_Up() {
            string level = "$$$\n$@$\n$$$"; // So many boxes!
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Up);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoxExit_Down() {
            string level = "$$$\n$@$\n$$$"; // So many boxes!
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Down);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoxExit_Left() {
            string level = "$$$\n$@$\n$$$"; // So many boxes!
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Left);
            var actual = game.PlayerX;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoxExit_Right() {
            string level = "$$$\n$@$\n$$$"; // So many boxes!
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = 1;
            game.Move(Direction.Up);
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Push Box Correctly

        [TestMethod]
        public void BoxPush_Up() {
            string level = "-----\n--$--\n-$@$-\n--$--\n-----";
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Block;
            game.Move(Direction.Up);
            var actual = game[2, 0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoxPush_Down() {
            string level = "-----\n--$--\n-$@$-\n--$--\n-----";
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Block;
            game.Move(Direction.Down);
            var actual = game[2, 4];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoxPush_Left() {
            string level = "-----\n--$--\n-$@$-\n--$--\n-----";
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Block;
            game.Move(Direction.Left);
            var actual = game[0, 2];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoxPush_Right() {
            string level = "-----\n--$--\n-$@$-\n--$--\n-----";
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Block;
            game.Move(Direction.Right);
            var actual = game[4, 2];
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Box push into something

        [TestMethod]
        public void BoxPushInto_Wall() {
            string level = "--#--\n--$--\n-$@$-\n--$--\n--$--";
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Block;
            game.Move(Direction.Up);
            var actual = game[2, 1];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoxPushInto_AnotherBlock() {
            string level = "--#--\n--$--\n-$@$-\n--$--\n--$--";
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Block;
            game.Move(Direction.Down);
            var actual = game[2, 3];
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Undo

        [TestMethod]
        public void Undo_Basic() {
            string level = "-----\n-----\n--@--\n-----\n-----"; // Soooooo lonely! QAQ
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Player;
            game.Move(Direction.Up);
            game.Undo();
            var actual = game[2, 2];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Undo_Many() {
            string level = "-----\n-----\n--@--\n-----\n-----"; // Soooooo lonely! QAQ
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = FloorType.Player;
            game.Move(Direction.Up);
            game.Move(Direction.Right);
            game.Move(Direction.Down);
            game.Undo();
            game.Undo();
            game.Undo();
            var actual = game[2, 2];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Undo_TooMany() {
            string level = "-----\n-----\n--@--\n-----\n-----"; // Soooooo lonely! QAQ
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = false;
            game.Move(Direction.Up);
            game.Undo();
            var actual = game.Undo(); // Too many undos should return false.
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region ModelCooperation

        [TestMethod]
        public void StartGame() {
            string level = "-----\n-----\n--@--\n-----\n-----"; // Soooooo lonely! QAQ
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = true;
            var controller = new GameController();
            var view = new GameView();
            view.SetController(controller);
            controller.SetGame(game);
            game.SetView(view);
            try {
                view.Show();
                view.Close();
            }
            catch {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SaveGame() {
            string level = "-----\n-----\n--@--\n-----\n-----"; // Soooooo lonely! QAQ
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            game.LoadLevel(level);
            var expected = true;
            var filer = new Filer();
            game.SetFiler(filer);
            game.SaveToFile("test.txt");
            Assert.AreEqual(File.ReadAllText("test.txt").Trim(), "-----\n-----\n--@--\n-----\n-----".Replace("\n", Environment.NewLine));
        }

        [TestMethod]
        public void LoadGame() {
            string level = "-----\n-----\n--@--\n-----\n-----"; // Soooooo lonely! QAQ
            var game = new GameModel();
            game.CheckBoxGoalEqual = false; // suppress expection
            var expected = 2;
            var filer = new Filer();
            game.SetFiler(filer);
            game.LoadFile("test.txt");
            var actual = game.PlayerY;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Designer

        [TestMethod]
        public void Designer_Default() {
            var designer = new DesignerModel();
            designer.CreateLevel(6, 6);
            var expected = FloorType.Empty;
            var actual = designer[2, 0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Designer_Put() {
            var designer = new DesignerModel();
            designer.CreateLevel(6, 6);
            var expected = FloorType.Wall;
            designer[2, 0] = FloorType.Wall;
            var actual = designer[2, 0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Designer_PutOnGoal() {
            var designer = new DesignerModel();
            designer.CreateLevel(6, 6);
            var expected = FloorType.BlockOnGoal;
            designer[2, 0] = FloorType.Goal;
            designer[2, 0] = FloorType.Block;
            var actual = designer[2, 0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Designer_Check() {
            var designer = new DesignerModel();
            designer.CreateLevel(6, 6);
            var expected = false;
            designer[2, 0] = FloorType.Goal;
            designer[2, 0] = FloorType.Block;
            designer[3, 0] = FloorType.Block;
            var actual = designer.CheckValid();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Designer_Check2() {
            Assert.ThrowsException<InvalidOperationException>(
                () => {
                    var designer = new DesignerModel();
                    designer.CreateLevel(6, 6);
                    designer[2, 0] = FloorType.Player;
                    designer[3, 0] = FloorType.Player;
                });
        }

        [TestMethod]
        public void Designer_Save() {
            var designer = new DesignerModel();
            var filer = new Filer();
            designer.SetFiler(filer);
            designer.CreateLevel(5, 5);
            var expected = false;
            designer[2, 2] = FloorType.Player;
            designer.Save("designertest.txt");
            Assert.AreEqual(File.ReadAllText("designertest.txt").Trim(), "-----\n-----\n--@--\n-----\n-----".Replace("\n", Environment.NewLine));
        }

        [TestMethod]
        public void Designer_Load() {
            var designer = new DesignerModel();
            designer.CreateLevel(5, 5);
            var expected = FloorType.Player;
            designer.LoadLevel(File.ReadAllText("designertest.txt"));
            var actual = designer[2, 2];
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}