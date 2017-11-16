using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Windows.Forms;
using Controller;
using Model;

namespace View {
    public class FilerView:IFilerView {
        public IFilerController Controller { get; }

        public string Load() { return ""; }
        public void Save(IGame game) { this.Controller.SaveToFile(game); }
    }
}
