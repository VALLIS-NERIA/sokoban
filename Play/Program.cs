using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Controller;
using Sokoban.Model;
using Sokoban.View;

namespace Play {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var gameView = new GameView();
            var gameModel = new GameModel();
            var gameController = new GameController();
            gameController.SetGame(gameModel);
            gameView.SetController(gameController);
            gameModel.SetView(gameView);

            var filerView = new FilerView();
            var filerModel = new Filer();
            var filerController = new FilerController();
            filerView.SetController(filerController);
            filerController.SetFiler(filerModel);
            filerModel.SetView(filerView);

            gameModel.SetFiler(filerModel);


            //Other person's IGameView
            //Modified GameModel and GameView
            //Original GameController
            var gameModel1 = new Sokoban.Other.ModifiedGameModel();
            var gameController1 = new GameController();
            var gameView1 = new Sokoban.Other.ModifiedGameView(gameController1, gameModel1);
            gameController1.SetGame(gameModel1);
            gameModel1.SetView(gameView1);


            //Other person's IGameController
            //Modified GameController and GameModel
            //Original GameView
            var gameView2 =new GameView();
            var gameModel2=new Sokoban.Other2.ModifiedGameModel(gameView2);
            var gameController2=new Sokoban.Other2.ModifiedGameController(filerModel);
            gameView2.SetController(gameController2);
            gameController2.SetGame(gameModel2);

            //Application.Run(gameView);
            //Application.Run(gameView1);
            Application.Run(gameView2);
        }
    }
}
