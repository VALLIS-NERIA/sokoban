using Sokoban.Controller;
using Sokoban.Model;

namespace Sokoban.View {
    public interface IFilerView {
        string LoadedFile { get; }
        void SetController(IFilerController controller);
        System.Windows.Forms.DialogResult LoadDialog();
        System.Windows.Forms.DialogResult SaveDialog(IFileable fileable);
    }
}