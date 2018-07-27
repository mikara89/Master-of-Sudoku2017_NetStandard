using SQLite;

namespace Master_of_Sudoku.Service
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
