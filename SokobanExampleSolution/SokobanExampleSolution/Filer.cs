using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerNS
{
    public class Filer : IFiler, ILoader, ISaver, IChecker 
    {
        protected ILoader Loader;
        protected ISaver Saver;
        protected IConverter Converter;
        protected IChecker Checker; 

        public Filer(ILoader loader, ISaver saver, IConverter converter, IChecker checker)
        {
            Loader = loader;
            Saver = saver;
            Converter = converter;
            Checker = checker; 
        }

        public string Load(string filename)
        {
            throw new NotImplementedException(); // sorry – you gotta do this
        }

        public void Save(string filename, IFileable callMeBackforDetails)
        {
            throw new NotImplementedException(); // sorry – you gotta do this 
        }

        public bool? PreExpandingCheck(string input)
        {
            throw new NotImplementedException(); // sorry – you gotta do this
        }

        public bool? PreCompressingCheck(string input)
        {
            throw new NotImplementedException(); // sorry – you gotta do this
        }
    }
}
