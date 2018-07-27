using Master_of_Sudoku.Model;
using Master_of_Sudoku.Service;
using Master_of_Sudoku.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static SudokuGameApiCore.SudokuCreator;

namespace Master_of_Sudoku.ViewModel
{
    public class StartViewModel:BaseViewModel
    {
        private PageService _pageService;
        private IMasterOfSudokuStore _masterOfSudokuStore;
        private ObservableCollection<MasterOfSudokuViewModel> _listOfGames;
        private List<DifficultToString> _listOfDifficult =new List<DifficultToString>();
        private bool _isLoading;
        private bool _isGameCreating;
        public ICommand FillScoreListTestCommand;
        public ICommand FillScoreListCommand;
        public ICommand StartNewGameCommand;
        public ICommand ResumeNewGameCommand;
        public ICommand DeleteNewGameCommand;

        
        public string PlayerName { get; set; }
        public DifficultOptions Difficult { get; set; } 
        public ObservableCollection<MasterOfSudokuViewModel> ListOfGames { get { return _listOfGames; } set { SetValue(ref _listOfGames, value);  } }
        public List<DifficultToString> ListOfDifficult { get { return _listOfDifficult; } set { SetValue(ref _listOfDifficult, value); } }
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetValue(ref _isLoading, value);
            }
        }
        public bool IsGameCreating
        {
            get
            {
                return _isGameCreating;
            }
            set
            {
                SetValue(ref _isGameCreating, value);
            }
        }
         
        public StartViewModel(PageService pageService)
        {
            
            _pageService = pageService;
            _masterOfSudokuStore = new SQLiteMasterOfSudokuStore(DependencyService.Get<ISQLiteDb>());
            FillDifficultList();
            StartNewGameCommand = new Command(async () => { if (IsGameCreating) return; IsGameCreating = true; await StartNewGame(); IsGameCreating = false; });
            FillScoreListCommand= new Command(async () => await FillScoreList());
            ResumeNewGameCommand= new Command<int>(async id => await ResumeNewGame(id));
            DeleteNewGameCommand = new Command<int>(async id => await DelateGame(id));
            IsGameCreating = false;
        }
        public async Task FillScoreList()
        {
            IsLoading = true;
            _listOfGames = new ObservableCollection<MasterOfSudokuViewModel>();
            var db= await _masterOfSudokuStore.GetMasterOfSudokusAsync();
            var list = new List<MasterOfSudokuViewModel>();
            foreach (var item in db.OrderByDescending(p => p.Score))
            {
                list.Add(new MasterOfSudokuViewModel(item));             
            }
            ListOfGames = new ObservableCollection<MasterOfSudokuViewModel>(list.OrderByDescending(p => p.Score));
            IsLoading = false;
        }
        
        private void FillDifficultList()
        {
            _listOfDifficult.Add(new DifficultToString { Name = "Easy", Value = DifficultOptions.Easy });
            _listOfDifficult.Add(new DifficultToString { Name = "Medium", Value = DifficultOptions.Medium });
            _listOfDifficult.Add(new DifficultToString { Name = "Hard", Value = DifficultOptions.Difficult });
            _listOfDifficult.Add(new DifficultToString { Name = "Evil", Value = DifficultOptions.Evil });
        }

        private async Task StartNewGame() 
        {
            if (PlayerName=="" || PlayerName == null)
            {
                await _pageService.DisplayAlert("Error", "Please enter your name!", "OK");
                return;
            }
            try
            {
                using (var sudoku = new SudokuGameApiCore.SudokuCreator(Difficult))
                {
                    var game = new MasterOfSudokuViewModel
                    {
                        PlayerName = PlayerName,
                        Difficult = ListOfDifficult
                        .Single(p => p.Value == Difficult)
                        .Name,
                        Board = sudoku.Board,
                        BoardSolved = sudoku.BoardSolution,
                        IsGameFinished = false,
                        IsUnique = sudoku.IsUnique,
                        MaximumPoints = sudoku.MaximumPoints,
                        PointsBlock = sudoku.PointsBlocks,
                        PointsColumn = sudoku.PointsColumns,
                        PointsGame = sudoku.PointsGame,
                        PointsRow = sudoku.PointsRow,
                        Score = 0,
                        Time = TimeSpan.FromSeconds(0),
                        Lives=3
                    };
                    
                    await _pageService.PushAsync(new PlayView(new MasterOfSudokuViewModel(await _masterOfSudokuStore.AddMasterOfSudoku(game.Sudoku))));
                }
            }
            catch (Exception ex)
            {
                await _pageService.DisplayAlert("Error","Error: "+ex.Message,"ok");
            }
        }

        private async Task ResumeNewGame(int id) 
        {
            IsGameCreating = true;
            var sudoku = await _masterOfSudokuStore.GetMasterOfSudoku(id);
            var game = new MasterOfSudokuViewModel(sudoku);
            if (game.IsGameFinished)
            {
                await _pageService.DisplayAlert("Sorry","You alweady won this game!","Ok");
                IsGameCreating = false;
                return;
            }
            IsGameCreating = false;
            await _pageService.PushAsync(new PlayView(game));
            //await _pageService.SaveAppProperties("GameRunning", Convert.ToString(id));
        }

        public string HeaderText
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return "Slide on game to Resume/Delete";
                    case Device.Android:
                        return "Hold on game to Resume/Delete";
                    case Device.WinPhone:
                    case Device.Windows:
                        return "Right click on game to Resume/Delete"; ;
                    default:
                        return null;
                }
            }
        }

        private async Task DelateGame(int Id)
        {
            var sudoku = await _masterOfSudokuStore.GetMasterOfSudokusAsync();
            await _masterOfSudokuStore.DeleteMasterOfSudoku(sudoku.Single(p => p.Id == Id));
        }
        

    }
}
