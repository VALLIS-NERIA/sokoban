using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;
using View;

namespace UI {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            var view = new GameView();
            var game = new GameModel();
            var controller = new GameController();
            controller.LoadGame(game);
            view.LoadController(controller);
            Application.Run(view);
        }
    }
}