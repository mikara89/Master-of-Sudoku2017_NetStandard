using Master_of_Sudoku.CustomRenderers.Controls;
using Master_of_Sudoku.Model;
using Master_of_Sudoku.Service;
using Master_of_Sudoku.ViewModel;
using SudokuGameApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Master_of_Sudoku.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayView : ContentPage
    {
        public static Stopwatch sw = new Stopwatch();
        public PlayView(MasterOfSudokuViewModel sudoku)
        {
            var pageServices = new PageService();
            ViewModel = new PlayViewModel(SudokuCreator.DifficultOptions.Evil, pageServices,sudoku);
            InitializeComponent();
            Padding = new Thickness(0, 20, 0, 0);
            SetCellsInit();
            SizeChanged += (s, e) => { ViewModel.MainWidth = Height> Width?Width:Height; SetGrides(); SetCells(); };           
            lblText.Text = ViewModel.toString;
            lblText.FontSize = 20;
            NavigationPage.SetHasNavigationBar(this, true);
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                sw.Start();

                ViewModel.TimeSpan = sw.Elapsed;
                ViewModel.Time = "Time: " + ViewModel.TimeSpan.Minutes + "m " + ViewModel.TimeSpan.Seconds + "s";
                
                if (!ViewModel.IsGameActive)
                {
                    sw.Reset();
                    return false;
                }                                                 
                return true;
            });
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public PlayViewModel ViewModel { get { return BindingContext as PlayViewModel; } set { BindingContext = value; } }
        public void SetGrides() 
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var gride = this.FindByName<Grid>("gride" + i + "" + j);
                    gride.BackgroundColor = Color.Gray;

                    gride.ColumnDefinitions = new ColumnDefinitionCollection
                    {
                        new ColumnDefinition { Width = new GridLength(ViewModel.CellSize,GridUnitType.Absolute) },
                        new ColumnDefinition { Width = new GridLength(ViewModel.CellSize,GridUnitType.Absolute) },
                        new ColumnDefinition { Width = new GridLength(ViewModel.CellSize,GridUnitType.Absolute) },
                    };
                    gride.RowDefinitions = new RowDefinitionCollection
                    {
                        new RowDefinition { Height = new GridLength(ViewModel.CellSize,GridUnitType.Absolute) },
                        new RowDefinition { Height = new GridLength(ViewModel.CellSize,GridUnitType.Absolute) },
                        new RowDefinition { Height = new GridLength(ViewModel.CellSize,GridUnitType.Absolute) },
                    };
                }               
            }

            var grideMain = this.FindByName<Grid>("grideMain");
            grideMain.Padding = new Thickness(3);
            grideMain.ColumnDefinitions = new ColumnDefinitionCollection
                    {
                        new ColumnDefinition { Width = GridLength.Auto },
                        new ColumnDefinition { Width = GridLength.Auto },
                        new ColumnDefinition { Width = GridLength.Auto },
                    };
            grideMain.RowDefinitions = new RowDefinitionCollection
                    {
                        new RowDefinition { Height = GridLength.Auto },
                        new RowDefinition { Height = GridLength.Auto },
                        new RowDefinition { Height = GridLength.Auto },
                    };
        }
        public void SetCellsInit()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var cell = this.FindByName<NoPaddingButton>("cell" + i + "" + j);
                    cell.Clicked += (s, e) => { OnButtonClicked(s, e);  };
                }
            }
        }
        public void SetCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var cell = this.FindByName<NoPaddingButton>("cell" + i + "" + j);
                    cell.RowIndex = i; cell.ColumnIndex = j;
                    cell.Text = ViewModel.List[(i * 9) + j];
                    cell.FontSize = 25;
                    cell.Margin = 0;
                    cell.BorderRadius = 0;
                    cell.BorderWidth = 0;
                    cell.SetDynamicResource(BackgroundColorProperty, "ListbackgroundColor");
                    cell.SetDynamicResource(NoPaddingButton.TextColorProperty, "textColor");
                }
            }
        }
        void OnButtonClicked(object sender, EventArgs args)
        {
            var btn = (sender as NoPaddingButton);
            if (btn.Text != "") return;
            EnteredName.Text = string.Empty;
            overlay.IsVisible = true;
            EnteredName.Focus();
            ViewModel.SetRowColumnToCheck(btn.RowIndex, btn.ColumnIndex);
        }

        public async Task OnOKButtonClicked(object sender, EventArgs args)
        {
            int val;  
            if (int.TryParse(EnteredName.Text, out val))
            {
                if ((0 < val) && (val <= 9))
                {
                    overlay.IsVisible = false;

                    ViewModel.TestingNum = val;
                    if (!(ViewModel.CheckForResult(val)))
                    {
                        await DisplayAlert("Result", string.Format("The value {0} isn't valid", EnteredName.Text), "OK");
                    }
                    else SetCellsValue();
                    if (ViewModel.IsGameEnded)
                        ViewModel.EndedGameCommand.Execute(null);
                }
                else
                {
                    overlay.IsVisible = false;
                    await DisplayAlert("Bed input",
                        string.Format(@"The value {0} isn't value between 1-9!
Please enter numeric value between 1 and 9!", EnteredName.Text), "OK");
                    
                }
            }
            else
            {
                overlay.IsVisible = false;
                await DisplayAlert("Bed input",
                        string.Format(@"The value {0} isn't numeric!
Please enter numeric value between 1 and 9!", EnteredName.Text), "OK");
                
            }

            
                
        }

        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }
      
        public void SetCellsValue() 
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var cell = this.FindByName<NoPaddingButton>("cell" + i + "" + j);
                    cell.Text = ViewModel.List[(i * 9) + j];   
                }
            }
        }

        public static Task<string> InputBox(INavigation navigation)
        {
            // wait in this proc, until user did his input 
            var tcs = new TaskCompletionSource<string>();

            var lblTitle = new Label { Text = "Title", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var lblMessage = new Label { Text = "Enter new text:" };
            var txtInput = new Entry { Text = "" };

            var btnOk = new Button
            {
                Text = "Ok",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8),
            };
            btnOk.Clicked += async (s, e) =>
            {
                // close page
                var result = txtInput.Text;
                await navigation.PopModalAsync();
                // pass result
                tcs.SetResult(result);
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8)
            };
            btnCancel.Clicked += async (s, e) =>
            {
                // close page
                await navigation.PopModalAsync();
                // pass empty result
                tcs.SetResult(null);
            };

            var slButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnOk, btnCancel },
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(0, 40, 0, 0), BackgroundColor=Color.White,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblTitle, lblMessage, txtInput, slButtons },
            };
            var grid = new Grid
            {
                BackgroundColor = Color.Transparent,
                //Opacity = 0.5,
                RowDefinitions= new RowDefinitionCollection
                {
                    new RowDefinition { Height= new GridLength(1,GridUnitType.Star), },
                    new RowDefinition { Height= new GridLength(2,GridUnitType.Star), },
                    new RowDefinition { Height= new GridLength(2,GridUnitType.Star), },
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width= new GridLength(1,GridUnitType.Star), },
                    new ColumnDefinition { Width= new GridLength(4,GridUnitType.Star), },
                    new ColumnDefinition { Width= new GridLength(1,GridUnitType.Star), },
                },
            };
            grid.Children.Add(layout, 1, 1);
            // create and show page
            var page = new ContentPage();
            page.Content = grid; /*layout;*/
            page.BackgroundColor = Color.Transparent;
            navigation.PushModalAsync(page);
            // open keyboard
            txtInput.Focus();

            // code is waiting her, until result is passed with tcs.SetResult() in btn-Clicked
            // then proc returns the result
            return tcs.Task;
        }
        protected override bool OnBackButtonPressed()
        {
            ViewModel.BackToManuCommand.Execute(null);
            return base.OnBackButtonPressed();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.BackToManuCommand.Execute(null);
        }
    }
    public class TestViewModel
    {
        public ObservableCollection<string> List { get; set; }
        public ObservableCollection<string> ListSolution { get; set; } 
        public string toString { get; set; } 
        public TestViewModel()
        {
            List = new ObservableCollection<string> ();
            ListSolution = new ObservableCollection<string>();
            using (var sudoku = new SudokuCreator(SudokuCreator.DifficultOptions.Evil))
            {
                
                var a=sudoku.Board;
                var aS = sudoku.BoardSolution;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (a[i,j] == 0)
                            List.Add("");
                        if (a[i, j] != 0)
                            List.Add(a[i, j].ToString()); 
                    ListSolution.Add(aS[i,j].ToString());

                    }
                }
                toString =SudokuCreator.ToString(aS); /*SudokuCreator.ToStringCells(sudoku.Cells)*/;
            }
        }
    }
}