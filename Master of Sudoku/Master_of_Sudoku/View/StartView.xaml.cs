﻿using Master_of_Sudoku.Model;
using Master_of_Sudoku.Service;
using Master_of_Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Master_of_Sudoku.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartView : ContentPage
    {
        public StartView()
        {
            var b = true;
            var pageService = new PageService();
            ViewModel = new StartViewModel(pageService);
            
            InitializeComponent();
            pckDifficult.SelectedIndex = 1;
            
            btnStart.Clicked += (s, e) => 
            {
                ViewModel.PlayerName = pckUser.Text;
                var diff = pckDifficult.SelectedItem as DifficultToString;
                ViewModel.Difficult = diff.Value;
                ViewModel.StartNewGameCommand.Execute(null);
            };
            btnStyle.Clicked += (s, e) =>
            {
                if (b)
                {
                    Resources["backgroundColor"] = Color.FromRgb(33, 40, 48);
                    Resources["ListbackgroundColor"] = Color.FromRgb(45, 40, 48);
                    Resources["BorderListbackgroundColor"] = Color.FromRgb(45, 110, 137);
                    b = false;
                }
                else
                {
                    Resources["backgroundColor"] = Color.FromHex("#99CB55");
                    Resources["ListbackgroundColor"] = Color.FromHex("#779E42");
                    Resources["BorderListbackgroundColor"] = Color.FromHex("#496128");
                    b = true;
                }
                
            };
            //listViewScore.ItemsSource = ViewModel.ListOfGames;
            var a = listViewScore.ItemsSource;
        }
        public StartViewModel ViewModel { get { return BindingContext as StartViewModel; } set { BindingContext = value; } }
        protected override void OnAppearing()
        {
            ViewModel.FillScoreListCommand.Execute(null);
            base.OnAppearing();
        }
        void OnButtonClicked(object sender, EventArgs args)
        {

        }

        public async Task OnOKButtonClicked(object sender, EventArgs args)
        {
        }

        void OnCancelButtonClicked(object sender, EventArgs args)
        {

        }

        private async Task MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var sudoku = menuItem.BindingContext as MasterOfSudokuViewModel;
            if (menuItem.Text== "Delete")
            {
                ViewModel.DeleteNewGameCommand.Execute(sudoku.Id);
                ViewModel.ListOfGames.Remove(sudoku);
            }
            else
            {
                ViewModel.ResumeNewGameCommand.Execute(sudoku.Id);
            }

        }

        private void ViewCell_Appearing(object sender, EventArgs e)
        {
            var p = sender as Cell;
            var sudoku = p.BindingContext as MasterOfSudokuViewModel;
            var list = p.ContextActions;
            var resume = list.SingleOrDefault(n => n.Text == "Resume");
            if (sudoku.IsGameFinished)
            {
                if (list.Contains(resume))
                {
                    list.Remove(resume);
                }
            }

        }
    }
}
