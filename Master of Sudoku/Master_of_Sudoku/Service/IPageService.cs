using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master_of_Sudoku.Service
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);

        void OpenUrl(string url);

        Task PushModalAsync(Page page);
        Task<Page> PopModalAsync();

        Task ReturnToMainPage();

        Task SaveAppProperties(string key, string value);
        string GetAppProperties(string key);
    }
}
