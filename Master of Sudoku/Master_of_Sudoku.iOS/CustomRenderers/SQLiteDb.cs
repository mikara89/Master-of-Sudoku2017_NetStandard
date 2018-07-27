using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Master_of_Sudoku.iOS.CustomRenderers;
using Master_of_Sudoku.Service;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Master_of_Sudoku.iOS.CustomRenderers
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