using Sokoban.Controller;
using Sokoban.Model;

namespace Sokoban.View{
    public interface IFilerView {
        IFilerController Controller { get; }

        string Load();
        void Save(IGame game);
    }
}