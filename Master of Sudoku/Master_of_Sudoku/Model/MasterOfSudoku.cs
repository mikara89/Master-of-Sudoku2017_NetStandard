using Master_of_Sudoku.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_of_Sudoku.Model
{
    public class MasterOfSudoku
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public bool IsGameFinished { get; set; }
        public int Score { get; set; }
        public byte[] Board { get; set; }
        public byte[] BoardSolved { get; set; }
        public string Difficult { get; set; }
        public string PointsRow { get; set; }
        public string PointsColumn { get; set; }
        public string PointsBlock { get; set; }
        public int PointsGame { get; set; }
        public int MaximumPoints { get; set; }
        public bool IsUnique { get; set; }  
        public TimeSpan Time { get; set; }

      
    }
}
