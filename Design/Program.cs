using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Controller;
using Sokoban.Model;
using Sokoban.View;

namespace Design {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var filerView = new FilerView();
            var filerModel = new Filer();
            var filerController = new FilerController();
            var designerView = new DesignerView();
            var designerModel = new DesignerModel();
            var designerController = new DesignerController();
            filerView.SetController(filerController);
            filerController.SetFiler(filerModel);
            filerModel.SetView(filerView);
            designerView.SetController(designerController);
            designerController.SetModel(designerModel);
            designerModel.SetView(designerView);
            designerModel.SetFiler(filerModel);
            Application.Run(designerView);
        }
    }
}
