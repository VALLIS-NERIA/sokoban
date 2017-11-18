using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public interface IFiler {
        string Serialization(IFileable fileable);
        void Save(string fileName, IFileable fileable);
        string Load(string fileName);
    }
}