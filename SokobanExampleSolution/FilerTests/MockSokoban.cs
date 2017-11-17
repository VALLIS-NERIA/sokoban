using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace FilerTests
{
    class MockSokoban : IFileable
    // this class acts like a Game or a Designer
    {
        // secret and faked level 
        // only an array of string for testing purposes 
        // a Designer or a game should have different / better internal sructures 
        protected string[] TestLevel = new string[] { "#####              ",
                                                      "#   #              ",
                                                      "#$  #              ",
                                                      "###  $##           ",
                                                      "#  $ $ #           ",
                                                      "### # ## #   ######",
                                                      "#   # ## #####  ..#",
                                                      "# $  $          ..#",
                                                      "##### ### #@##  ..#",
                                                      "#     #########    ",
                                                      "#######            "
                                                     };
        // publics for unittest to check 
        // for testing purposes to audit what called and how often 
        public int GetRowCallCount = 0;
        public int GetColumnCallCount = 0;
        public Parts WhatsAtCallCount = 0;
        public List<int> rowsChecked = new List<int>();
        public List<int> columnsChecked = new List<int>();

        // for IFileable 
        public int GetRowCount()
        {
            GetRowCallCount++;
            return 10;
        }

        public int GetColumnCount()
        {
            GetColumnCallCount++;
            return 19;
        }

        public Parts WhatsAt(int row, int column)
        {
            WhatsAtCallCount++;
            rowsChecked.Add(row);
            columnsChecked.Add(column);
            // UPDATED CODE 
            char part = TestLevel[row][column];
            return (Parts)(int)part;            
        }
    }
}
