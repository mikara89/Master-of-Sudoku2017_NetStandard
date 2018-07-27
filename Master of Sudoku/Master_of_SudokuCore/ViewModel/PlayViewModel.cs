using System;
using System.Linq;
using System.Threading.Tasks;
using SudokuGameApiCore;
using System.Collections.ObjectModel;
using Master_of_Sudoku.Service;
using Master_of_Sudoku.Helper;
using Xamarin.Forms;
using System.Windows.Input;
using Master_of_Sudoku.CustomRenderers.AdMob;
using System.Diagnostics;

namespace Master_of_Sudoku.ViewModel
{
    public class PlayViewModel:BaseViewModel
    {
        private PageService _pageService;
        private double _mainWidth;
        private bool _isGameEnded=false;
        private bool _isGameActive = false; 
        private double _cellSize;
        private int _score;
        private MasterOfSudokuViewModel _sudoku;
        private IMasterOfSudokuStore _masterOfSudokuStore;
        public ICommand EndedGameCommand; 
        public ICommand BackToManuCommand;
        public double CellSize
        {
            get { return _cellSize; }
            set { SetValue(ref _cellSize, value);}
        }
        public double MainWidth
        {
            get { return _mainWidth; }
            set { SetValue(ref _mainWidth, value); CellSize = MainWidth / 13; }
        }
        public int Score
        {
            get { return _sudoku.Score; }
            set { SetValue(ref _score, value);}
        }
        public string Time
        {
            get { return _time; }
            set { SetValue(ref _time, value); }
        }

        public TimeSpan TimeSpan
        {
            get { return _sudoku.Time + (_isResetSw==true ? new TimeSpan(): _timeSpan); }
            set
            {
                SetValue(ref _timeSpan, value);
            }
        }
        public bool IsGameEnded 
        {
            get { return _isGameEnded; }
            set
            {
                SetValue(ref _isGameEnded, value);
            }
        }
        public bool IsGameActive 
        {
            get { return _isGameActive; }
            set
            {
                SetValue(ref _isGameActive, value);
            }
        }

        private int _Lives;
        public int Lives
        {
            get { return _Lives; }
            set
            {
                if (value != null || value != _Lives)
                {
                    SetValue(ref _Lives, value);
                    _sudoku.Lives = Lives;
                }
                    
            }
        }
        public string PauseIcon
        {
            get {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "pause-Small.png";
                    case Device.Android:
                    case Device.WinPhone:
                    case Device.Windows:
                        return "pause.png";
                    default:
                        return null;
                }
            }
           
        }
        public ObservableCollection<string> List { get; set; }
        public ObservableCollection<string> ListSolution { get; set; }
        private SudokuCreator.DifficultOptions _difficult;
        public string difficult { get;private set; }
        public int TestingNum { get; set; }
        public string toString { get; private set; }
        private int _rowIndex;
        private int _columnIndex;
        private string _time; 
        private TimeSpan _timeSpan;
        public bool _isResetSw=false;

        public PlayViewModel(SudokuCreator.DifficultOptions difficult, PageService pageService, MasterOfSudokuViewModel sudoku)
        {
            _sudoku = sudoku;
            Score = _sudoku.Score;
            Lives = _sudoku.Lives;
            _pageService = pageService;
            IsGameActive = true;
            _difficult = DifficultList.ListOfDifficult.Where(d=>d.Name== sudoku.Sudoku.Difficult).Single().Value;
            _masterOfSudokuStore = new SQLiteMasterOfSudokuStore(DependencyService.Get<ISQLiteDb>());
            ListSolution = new ObservableCollection<string>();
            List = new ObservableCollection<string>();
            EndedGameCommand = new Command(async () => await EndedGame());
            BackToManuCommand= new Command(async () => await BackToManu());
            var a = sudoku.Board;
                var aS = sudoku.BoardSolved;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (a[i, j] == 0)
                            List.Add("");
                        if (a[i, j] != 0)
                            List.Add(a[i, j].ToString());
                        ListSolution.Add(aS[i, j].ToString());

                    }
                }
                toString ="" /*SudokuCreator.ToString(aS);*/ /*SudokuCreator.ToStringCells(sudoku.Cells)*/;           
        }
        public async Task<bool> CheckForResultAsync(int value) 
        {
            if (!(0 < value) && !(value <= 9)) return false;
            if(value.ToString() == ListSolution[(_rowIndex * 9) + _columnIndex])
            {
                List[(_rowIndex * 9) + _columnIndex] = value.ToString();
                _sudoku.Board[_rowIndex,_columnIndex]= value;

                _sudoku.Score = _sudoku.Score + AddPoint();
                Score =_sudoku.Score;
                if (!_sudoku.Sudoku.Board.Any(n => n == 0))
                    IsGameEnded = true;
                UpdateGameToDb();
                return true;
            }
            Lives -= 1;
            if(Lives<1)
                IsGameEnded = true;
            return false;
        }
        private async Task EndedGame()
        {
            _sudoku.Score = _sudoku.Score + _sudoku.PointsGame;
            _sudoku.Time += _timeSpan;
            IsGameActive = false;
            IsGameEnded = true;
            _sudoku.IsGameFinished = true;
            Score = _sudoku.Score;

            var message= Lives>0? "You Win! Your Score is: " + Score: "You Lost! Your Score won't count!";

            if(Lives > 0) await _masterOfSudokuStore.UpdateMasterOfSudoku(_sudoku.Sudoku);
            else await _masterOfSudokuStore.DeleteMasterOfSudoku(_sudoku.Sudoku);

            await _pageService.DisplayAlert("Finish!", message, "Back to MENU");
            await _pageService.PopAsync();            
        }
        private async Task UpdateGameToDb() 
        {
            _sudoku.Time = _sudoku.Time+_timeSpan;
            _isResetSw = true;
            await _masterOfSudokuStore.UpdateMasterOfSudoku(_sudoku.Sudoku);
        }

        private async Task BackToManu() 
        {
            _sudoku.Time =TimeSpan;
            var succ=await _masterOfSudokuStore.UpdateMasterOfSudoku(_sudoku.Sudoku);
            if (succ)
            {
                await _pageService.PopAsync();
                IsGameActive = false;
                DependencyService.Get<IAdmobInterstitial>().Show();
            }
            return;
        }
        public void SetRowColumnToCheck(int RowIndex, int ColumnIndex)
        {
            _rowIndex = RowIndex;
            _columnIndex = ColumnIndex;
        }
        private int AddPoint()
        {
            var points = 0;
            var index= (_rowIndex * 9) + _columnIndex;
            var rowIndexBlock = _rowIndex / 3;
            var columnIndexBlock = _columnIndex / 3;
            var indexBlock = (rowIndexBlock * 3) + columnIndexBlock;
            var startIndexRow = _rowIndex - _rowIndex % 3;
            var startIndexColumn = _rowIndex - _columnIndex % 3;
            // check row
            if (!GetRow(_sudoku.Board, _rowIndex).Any(n => n == 0))
            {
                points = +_sudoku.PointsRow[_rowIndex];
            }
            // check column
            if (!GetColumn(_sudoku.Board, _columnIndex).Any(n => n == 0))
            {
                points = +_sudoku.PointsColumn[_columnIndex];
            }
            // check block
            var b = GetBlock(_sudoku.Board, _rowIndex,_columnIndex);
            if (!b.Any(n=>n==0))
            {
                points = +_sudoku.PointsBlock[indexBlock];
            }

            return points;
        }

        public static T[] GetRow<T>(T[,] matrix, int row)
        {
            var columns = matrix.GetLength(1);
            var array = new T[columns];
            for (int i = 0; i < columns; ++i)
                array[i] = matrix[row, i];
            return array;
        }
        public static T[] GetColumn<T>(T[,] matrix, int col)
        {
            var rows = matrix.GetLength(0);
            var array = new T[rows];
            for (int i = 0; i < rows; ++i)
                array[i] = matrix[i, col];
            return array;
        }

        public static int[] GetBlock(int[,] arr, int row, int col)
        {
            var array = new int[9];
            int r = row - row % 3;
            int c = col - col % 3;
            int x = 0;
            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                {
                    array[x] = arr[i, j];
                    x++;
                }
            }
            return array;
        }
    }
   
}
//1. 