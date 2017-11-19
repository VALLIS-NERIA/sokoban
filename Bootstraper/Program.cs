using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Controller;
using Sokoban.Model;
using Sokoban.View;
using Sokoban.View.WPF;

namespace Bootstraper {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            var filerView = new FilerView();
            var filerModel = new Filer();
            var filerController = new FilerController();
            filerView.SetController(filerController);
            filerController.SetFiler(filerModel);
            filerModel.SetView(filerView);

            var gameView = new GameView();
            var gameModel = new GameModel();
            var gameController = new GameController();
            gameController.SetGame(gameModel);
            gameView.SetController(gameController);
            //gameModel.SetView(gameView);
            gameModel.SetFiler(filerModel);

            var designerView = new DesignerView();
            var designerModel = new DesignerModel();
            var designerController = new DesignerController();
            designerView.SetController(designerController);
            designerController.SetModel(designerModel);
            designerModel.SetView(designerView);

            designerModel.SetFiler(filerModel);

            var wpfGameView = new WPFGameView();
            wpfGameView.SetController(gameController);
            gameModel.SetView(wpfGameView);

            //Application.Run(gameView);

            wpfGameView.ShowDialog();
        }
    }
}