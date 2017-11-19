using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Controller;
using Sokoban.Model;

namespace Sokoban.View {
    public interface IDesignerView {
        FloorType? SelectedType { get; }
        void InitDesigner(IFileable map);
        void Update(int x, int y, FloorType type);
        void SetController(IDesignerController controller);
        void Set(int x, int y, FloorType type);
    }
}
