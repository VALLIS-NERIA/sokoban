using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerNS
{
    public interface IConverter
    {
        string Expanded { get; }
        string Compressed { get; }
        void Compress(string uncompressedLevel);
        void Expand(string uncompressedLevel);
    }
}
