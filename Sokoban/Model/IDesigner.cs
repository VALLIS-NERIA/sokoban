using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.View;

namespace Sokoban.Model {
    public interface IDesigner : IFileable {
        void CreateLevel(int width, int height);
        new FloorType this[int x, int y] { get; set; }
        void LoadDialog();
        void LoadLevel(string levelString);
        void SetView(IDesignerView view);
        void SetFiler(IFiler filer);
        void Save();
        void SaveDialog();
        bool CheckValid();
    }
}