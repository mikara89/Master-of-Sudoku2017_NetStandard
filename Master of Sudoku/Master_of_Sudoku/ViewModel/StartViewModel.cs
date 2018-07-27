using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Master_of_Sudoku.Service;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Master_of_Sudoku.Model;
using static SudokuGameApi.SudokuCreator;
using System.Windows.Input;
using Master_of_Sudoku.View;

namespace Master_of_Sudoku.ViewModel
{
    public class StartViewModel:BaseViewModel
    {
        private PageService _pageService;
        private IMasterOfSudokuStore _masterOfSudokuStore;
        private ObservableCollection<MasterOfSudokuViewModel> _listOfGames;
        private List<DifficultToString> _listOfDifficult =new List<DifficultToString>();
        private bool _isLoading;
        public ICommand FillScoreListTestCommand;
        public ICommand FillScoreListCommand;
        public ICommand StartNewGameCommand;
        public ICommand ResumeNewGameCommand;
        public ICommand DeleteNewGameCommand; 
        private bool _isCreating;
        public string PlayerName { get; set; }
        public DifficultOptions Difficult { get; set; } 
        public ObservableCollection<MasterOfSudokuViewModel> ListOfGames { get { return _listOfGames; } set { SetValue(ref _listOfGames, value);  } }
        public List<DifficultToString> ListOfDifficult { get { return _listOfDifficult; } set { SetValue(ref _listOfDifficult, value); } }
        public bool IsLoading { get { return _isLoading; } set { SetValue(ref _isLoading, value); } }
        public bool IsCreating { get { return _isCreating; } set { SetValue(ref _isCreating, value); } }

        public StartViewModel(PageService pageService)
        {
            
            _pageService = pageService;
            _masterOfSudokuStore = new SQLiteMasterOfSudokuStore(DependencyService.Get<ISQLiteDb>());
            FillDifficultList();
            StartNewGameCommand = new Command(async () => await StartNewGame());
            FillScoreListCommand= new Command(async () => await FillScoreList());
            ResumeNewGameCommand= new Command<int>(async id => await ResumeNewGame(id));
            DeleteNewGameCommand = new Command<int>(async id => await DelateGame(id));
        }
        public async Task FillScoreList()
        {
            IsLoading = true;
            await Task.Delay(3000);
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
                using (var sudoku = new SudokuGameApi.SudokuCreator(Difficult))
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
            var sudoku = await _masterOfSudokuStore.GetMasterOfSudoku(id);
            var game = new MasterOfSudokuViewModel(sudoku);
            if (game.IsGameFinished)
            {
                await _pageService.DisplayAlert("Sorry","You alweady won this game!","Ok");
                return;
            }
            await _pageService.PushAsync(new PlayView(game));
        }
        private async Task DelateGame(int Id)
        {
            var sudoku = await _masterOfSudokuStore.GetMasterOfSudokusAsync();
            await _masterOfSudokuStore.DeleteMasterOfSudoku(sudoku.Single(p => p.Id == Id));
        }
        

    }
}
