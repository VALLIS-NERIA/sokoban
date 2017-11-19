using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller {
    public interface IDesignerController {
        void CreateNewLevel(int width, int height);

        void Load();

        void SetModel(IDesigner designer);

        void Save();

        void SaveAs();

        void Set(int x, int y, FloorType type);

        bool CheckValid();
    }
}