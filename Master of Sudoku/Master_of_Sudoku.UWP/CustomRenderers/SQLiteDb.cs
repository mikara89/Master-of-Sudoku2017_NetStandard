
using Xamarin.Forms;
using Master_of_Sudoku.Service;
using SQLite;
using System.IO;
using Master_of_Sudoku.UWP.CustomRenderers;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Master_of_Sudoku.UWP.CustomRenderers
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var path = Path.Combine(
               Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Master_of_Sudoku.db3");

            return new SQLiteAsyncConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
        }
    }
}