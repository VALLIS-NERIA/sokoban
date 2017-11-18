using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.View;

namespace Sokoban.Model {
    public interface IFiler {
        string LoadedFile { get; }

        string Serialize(IFileable fileable);
        void SetView(IFilerView view);

        // for FilerController to call
        void SaveFile(string fileName, IFileable fileable);
        // for other models to call
        bool SaveDialog(IFileable fileable);
        // for FilerController to call
        void LoadFile(string fileName);
        // for other models to call
        bool LoadDialog();
    }
}