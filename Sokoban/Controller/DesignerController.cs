using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public class DesignerController : IDesignerController {
        private IDesigner model;

        public void CreateNewLevel(int width, int height) { this.model.CreateLevel(width, height); }

        public void Load() { this.model.LoadDialog(); }

        public void Save() { this.model.Save(); }

        public void SaveAs() { this.model.SaveDialog(); }

        public void Set(int x, int y, FloorType type) { this.model[x, y] = type; }

        public void SetModel(IDesigner designer) { this.model = designer; }

        public bool CheckValid() => this.model.CheckValid();
    }
}