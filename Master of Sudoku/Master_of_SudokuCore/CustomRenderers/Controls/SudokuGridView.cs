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

            Content = grid;
        }


    }
}
