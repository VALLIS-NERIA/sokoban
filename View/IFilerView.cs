using Controller;
using Model;

namespace View {
    public interface IFilerView {
        IFilerController Controller { get; }

        string Load();
        void Save(IGame game);
    }
}