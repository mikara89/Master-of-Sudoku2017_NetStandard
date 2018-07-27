using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master_of_Sudoku.CustomRenderers.Controls
{
    public class SudokuGridView : ContentView
    {
        public SudokuGridView()
        {
            //ContentView subGrid0 = new SudokuGridView();
            //ContentView subGrid1 = new SudokuGridView();
            //ContentView subGrid2 = new SudokuGridView();
            //ContentView subGrid3 = new SudokuGridView();
            //ContentView subGrid4 = new SudokuGridView();
            //ContentView subGrid5 = new SudokuGridView();
            //ContentView subGrid6 = new SudokuGridView();
            //ContentView subGrid7 = new SudokuGridView();
            //ContentView subGrid8 = new SudokuGridView();

            var grid = new Grid
            {
                Padding = new Thickness(2),
                RowDefinitions =
            {
                new RowDefinition {Height =GridLength.Auto},
                new RowDefinition {Height =GridLength.Auto},
                new RowDefinition {Height =GridLength.Auto},
            },
                ColumnDefinitions =
            {
                new ColumnDefinition {Width=GridLength.Auto},
                new ColumnDefinition {Width=GridLength.Auto},
                new ColumnDefinition {Width=GridLength.Auto},
            },
            };
            grid.Children.Add(new SudokuGridView(), 0, 0);
            grid.Children.Add(new SudokuGridView(), 0, 1);
            grid.Children.Add(new SudokuGridView(), 0, 2);
            grid.Children.Add(new SudokuGridView(), 1, 0);
            grid.Children.Add(new SudokuGridView(), 1, 1);
            grid.Children.Add(new SudokuGridView(), 1, 2);
            grid.Children.Add(new SudokuGridView(), 2, 0);
            grid.Children.Add(new SudokuGridView(), 2, 1);
            grid.Children.Add(new SudokuGridView(), 2, 2);

            //grid.Children.Add(subGrid0, 0, 0);
            //grid.Children.Add(subGrid1, 0, 1);
            //grid.Children.Add(subGrid2, 0, 2);
            //grid.Children.Add(subGrid3, 1, 0);
            //grid.Children.Add(subGrid4, 1, 1);
            //grid.Children.Add(subGrid5, 1, 2);
            //grid.Children.Add(subGrid6, 2, 0);
            //grid.Children.Add(subGrid7, 2, 1);
            //grid.Children.Add(subGrid8, 2, 2);

            Content = grid;
        }


    }
}
