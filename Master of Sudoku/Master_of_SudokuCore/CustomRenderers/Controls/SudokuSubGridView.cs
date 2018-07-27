using Master_of_Sudoku.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master_of_Sudoku.CustomRenderers.Controls
{
    public class SudokuSubGridView : ContentView
    {

        public SudokuSubGridView()
        {

            var b = this.BindingContext as TestViewModel;
            Label p0 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p1 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p2 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p3 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p4 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p5 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p6 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p7 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label p8 = new Label
            {
                Text = "X",
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            var grid = new Grid
            {
                Padding = new Thickness(2),
                BackgroundColor = Color.Black,
                RowDefinitions =
            {
                new RowDefinition {Height =50},
                new RowDefinition {Height =50},
                new RowDefinition {Height =50},
            },
                ColumnDefinitions =
            {
                new ColumnDefinition {Width= 50 },
                new ColumnDefinition {Width= 50 },
                new ColumnDefinition {Width= 50 },
            },
            };
            grid.Children.Add(p0, 0, 0);
            grid.Children.Add(p1, 0, 1);
            grid.Children.Add(p2, 0, 2);
            grid.Children.Add(p3, 1, 0);
            grid.Children.Add(p4, 1, 1);
            grid.Children.Add(p5, 1, 2);
            grid.Children.Add(p6, 2, 0);
            grid.Children.Add(p7, 2, 1);
            grid.Children.Add(p8, 2, 2);
            try
            {
                p0.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(0));
                p1.SetBinding <TestViewModel>(Label.TextProperty, i => i.List.ElementAt(1));
                p2.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(2));
                p3.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(3));
                p4.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(4));
                p5.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(5));
                p6.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(6));
                p7.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(7));
                p8.SetBinding<TestViewModel>(Label.TextProperty, i => i.List.ElementAt(8));

                //p0.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(0));
                //p1.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(1));
                //p2.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(2));
                //p3.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(3));
                //p4.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(4));
                //p5.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(5));
                //p6.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(6));
                //p7.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(7));
                //p8.SetBinding<List<string>>(Label.TextProperty, i => i.ElementAt(8));

                //p0.SetBinding(Label.TextProperty, ItemSource.ElementAt(0));
                //p1.SetBinding(Label.TextProperty, ItemSource.ElementAt(1));
                //p2.SetBinding(Label.TextProperty, ItemSource.ElementAt(2));
                //p3.SetBinding(Label.TextProperty, ItemSource.ElementAt(3));
                //p4.SetBinding(Label.TextProperty, ItemSource.ElementAt(4));
                //p5.SetBinding(Label.TextProperty, ItemSource.ElementAt(5));
                //p6.SetBinding(Label.TextProperty, ItemSource.ElementAt(6));
                //p7.SetBinding(Label.TextProperty, ItemSource.ElementAt(7));
                //p8.SetBinding(Label.TextProperty, ItemSource.ElementAt(8));
            }
            catch (Exception)
            {

            }

            Content = grid;
        }



        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create<SudokuSubGridView, List<string>>(w => w.ItemSource, default(List<string>));

        public List<string> ItemSource
        {
            get { return (List<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }




        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ItemSourceProperty.PropertyName)
            {
                BindingContext = ItemSource;
            }
        }

    }


}
