using Master_of_Sudoku.Droid.CustomRenderers;
using Master_of_Sudoku.Service;
using SQLite;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Master_of_Sudoku.Droid.CustomRenderers
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, "Master_of_Sudoku.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}