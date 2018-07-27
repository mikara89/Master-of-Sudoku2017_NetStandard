using Master_of_Sudoku.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_of_Sudoku.Service
{
    public interface IMasterOfSudokuStore
    {
        Task<IEnumerable<MasterOfSudoku>> GetMasterOfSudokusAsync();
        Task<MasterOfSudoku> GetMasterOfSudoku(int Id); 
        Task<MasterOfSudoku> AddMasterOfSudoku(MasterOfSudoku sudoku); 
        Task<bool> UpdateMasterOfSudoku(MasterOfSudoku sudoku);
        Task DeleteMasterOfSudoku(MasterOfSudoku sudoku);
    }
}
