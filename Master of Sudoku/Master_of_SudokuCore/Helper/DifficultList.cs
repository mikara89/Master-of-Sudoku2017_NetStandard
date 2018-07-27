using Master_of_Sudoku.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SudokuGameApiCore.SudokuCreator;

namespace Master_of_Sudoku.Helper
{
    public static class DifficultList
    {
        public static List<DifficultToString> ListOfDifficult {
            get
            {
                return new List<DifficultToString>
               {
                   new DifficultToString { Name = "Easy", Value = DifficultOptions.Easy },
                   new DifficultToString { Name = "Medium", Value = DifficultOptions.Medium },
                   new DifficultToString { Name = "Hard", Value = DifficultOptions.Difficult },
                   new DifficultToString { Name = "Evil", Value = DifficultOptions.Evil }
               };
            }
            }
    }
}
