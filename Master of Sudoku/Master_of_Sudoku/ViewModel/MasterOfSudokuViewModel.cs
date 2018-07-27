using Master_of_Sudoku.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_of_Sudoku.ViewModel
{
    public class MasterOfSudokuViewModel
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public bool IsGameFinished { get; set; }
        public int Score { get; set; }
        public int[,] Board { get; set; }
        public int[,] BoardSolved { get; set; }
        public string Difficult { get; set; }
        public Dictionary<int, int> PointsRow { get; set; }
        public Dictionary<int, int> PointsColumn { get; set; }
        public Dictionary<int, int> PointsBlock { get; set; }
        public int PointsGame { get; set; }
        public int MaximumPoints { get; set; }
        public bool IsUnique { get; set; }
        public TimeSpan Time { get; set; }
        public string TimeToString
        { get { return (int)Time.Minutes + ":" + (int)Time.Seconds; } }
        public MasterOfSudoku Sudoku
        {
            get
            {
                return new MasterOfSudoku
                {
                    Id = this.Id,
                    PlayerName = this.PlayerName,
                    IsGameFinished = this.IsGameFinished,
                    Score = this.Score,
                    Board = BoardToArray(this.Board),
                    BoardSolved = BoardToArray(this.BoardSolved),
                    PointsBlock = DictionaryToString(this.PointsBlock),
                    PointsColumn = DictionaryToString(this.PointsColumn),
                    PointsRow = DictionaryToString(this.PointsRow),
                    PointsGame = this.PointsGame,
                    MaximumPoints = this.MaximumPoints,
                    IsUnique = this.IsUnique,
                    Time = this.Time,
                    Difficult = this.Difficult,
                };
            }
        }
        public MasterOfSudokuViewModel()
        {

        }
        public MasterOfSudokuViewModel(MasterOfSudoku sudoku)
        {
            Id = sudoku.Id;
            PlayerName = sudoku.PlayerName;
            IsGameFinished = sudoku.IsGameFinished;
            Score = sudoku.Score;
            Difficult = sudoku.Difficult;
            Board = ArrayToBoard(sudoku.Board);
            BoardSolved= ArrayToBoard(sudoku.BoardSolved);
            PointsBlock = StringToDictionary(sudoku.PointsBlock);
            PointsColumn = StringToDictionary(sudoku.PointsColumn);
            PointsRow = StringToDictionary(sudoku.PointsRow);
            PointsGame = sudoku.PointsGame;
            MaximumPoints = sudoku.MaximumPoints;
            IsUnique = sudoku.IsUnique;
            Time = sudoku.Time;
        }
        public int[,] ArrayToBoard(byte[] arr)
        {
            var b = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    b[i, j] = Convert.ToInt32(arr[(i * 9) + j]);
                }
            }
            return b;
        }
        public byte[] BoardToArray(int[,] board)
        {
            var b = new byte[81];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    b[(i * 9) + j] = Convert.ToByte(board[i, j]);
                }
            }
            return b;
        }
        public Dictionary<int,int> StringToDictionary(string str)
        {
            var dic = new Dictionary<int, int>();
            var strToArr = str.Split(',');
            for (int i = 0; i < strToArr.Count()-1; i++)
            {
                dic.Add(i, Convert.ToInt32(strToArr[i]));
            }
            return dic;
        }
        public string  DictionaryToString(Dictionary<int, int> dic)
        {
            var str ="";
            for (int i = 0; i < dic.Keys.Count; i++)
            {
                str += dic[i]+",";
            }
            return str;
        }
    }
}
