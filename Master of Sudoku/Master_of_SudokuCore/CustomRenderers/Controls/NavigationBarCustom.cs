using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Master_of_Sudoku.CustomRenderers.Controls
{
    public class NavigationBarCustom: ContentView
    {
        //public delegate void EventHandler(object sender, EventArgs e); 
        

        public NavigationBarCustom()  
        {
            Button pause = new NoPaddingButton
            {

                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                //Text = "Pause",
                BackgroundColor = Color.Transparent,


            };
            Label score = new Label
            {
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            Label lives = new Label
            {
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            };

            Label time = new Label 
            {
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment= TextAlignment.End,
            };

            Grid mainG = new Grid
            {
                Padding = new Thickness(5),
                RowDefinitions =
            {
                new RowDefinition {Height = new GridLength (1,GridUnitType.Star ) },
            },
                ColumnDefinitions =
            {
                new ColumnDefinition {Width= new GridLength (1,GridUnitType.Auto) },
                new ColumnDefinition {Width= new GridLength (1,GridUnitType.Star ) },
                new ColumnDefinition {Width= new GridLength (1,GridUnitType.Auto) },
                new ColumnDefinition {Width= new GridLength (1,GridUnitType.Auto ) },
            },


            };
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    time.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
                    score.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
                    lives.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
                    break;
                case Device.Android:
                    time.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    score.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    lives.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                case Device.WinPhone:
                case Device.Windows:
                    time.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    score.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    lives.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                    break;
                default:
                    break;
            }
            mainG.BackgroundColor = Color.Green;
            mainG.Children.Add(pause, 0, 0);
            mainG.Children.Add(score, 1, 0);
            mainG.Children.Add(lives, 2, 0);
            mainG.Children.Add(time, 3, 0);
            this.Content = mainG;
            //Binding 
            pause.Clicked +=(s,a)=> { OnClickedPause(); };
            score.SetBinding<ViewModel.PlayViewModel>(Label.TextProperty, i => i.Score,stringFormat:"Score: {0}");
            time.SetBinding<ViewModel.PlayViewModel>(Label.TextProperty, i => i.Time);
            lives.SetBinding<ViewModel.PlayViewModel>(Label.TextProperty, i => i.Lives, stringFormat: "Lives: {0}");
            pause.SetBinding<ViewModel.PlayViewModel>(Button.ImageProperty, i => i.PauseIcon);
        }

        /// <summary>
        /// Setting Click Event For Button
        /// </summary>
        public event EventHandler ClickedPause;
        private void OnClickedPause() 
        {
            EventHandler eventHandler = this.ClickedPause;
            eventHandler?.Invoke((object)this, EventArgs.Empty);

        }
    }

}