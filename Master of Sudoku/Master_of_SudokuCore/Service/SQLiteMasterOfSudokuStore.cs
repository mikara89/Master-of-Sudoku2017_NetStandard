using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Master_of_Sudoku.Model;
using SQLite;

namespace Master_of_Sudoku.Service
{
    public class SQLiteMasterOfSudokuStore : IMasterOfSudokuStore
    {
        private SQLiteAsyncConnection _connction;
        public SQLiteMasterOfSudokuStore(ISQLiteDb db)
        {
            try
            {
                _connction = db.GetConnection();
                var a = _connction.CreateTableAsync<MasterOfSudoku>().Result;
            }
            catch (Exception ex)
            {

                var a=ex.Message;
            }
          
        }
        public async Task<MasterOfSudoku> AddMasterOfSudoku(MasterOfSudoku sudoku)
        {
            await _connction.InsertAsync(sudoku);
            var list = await _connction.Table<MasterOfSudoku>().ToListAsync();
            return list.Single(n => n.Id == list.Max(a=>a.Id)); 
        }

        public async Task DeleteMasterOfSudoku(MasterOfSudoku sudoku)
        {
            await _connction.DeleteAsync(sudoku);
        }

        public async Task<MasterOfSudoku> GetMasterOfSudoku(int Id)
        {
            return await _connction.FindAsync<MasterOfSudoku>(Id);
        }

        public async Task<IEnumerable<MasterOfSudoku>> GetMasterOfSudokusAsync()
        {
            return await _connction.Table<MasterOfSudoku>().ToListAsync();
        }

        public async Task<bool> UpdateMasterOfSudoku(MasterOfSudoku sudoku)
        {
            int a;
            a = await _connction.UpdateAsync(sudoku);
            if (a == 0)
            {
                a = await _connction.InsertAsync(sudoku);
            }
            var succ = a > 0;
            return succ;
        }
    }
}
