using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace GameTests
{
    class MockFiler : IFiler
    {
        public string Level;

        public MockFiler(string level)
        {
            Level = level;
        }

        public string Load(string filename)
        {
            //
            return Level;
        }

        public void Save(string filename, IFileable callMeBackforDetails)
        {
            // 
        }
    }
}
