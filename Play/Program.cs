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
            var filerView = new FilerView();
            var filerModel = new Filer();
            var filerController = new FilerController();
            gameController.SetGame(gameModel);
            gameView.SetController(gameController);
            gameModel.SetView(gameView);
            filerView.SetController(filerController);
            filerController.SetFiler(filerModel);
            filerModel.SetView(filerView);
            gameModel.SetFiler(filerModel);
            Application.Run(gameView);
        }
    }
}
