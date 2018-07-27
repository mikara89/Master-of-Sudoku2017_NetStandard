using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master_of_Sudoku.Service
{
    public class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public void OpenUrl(string url)
        {
            Device.OpenUri(new Uri(url));
        }

        public async Task PushModalAsync(Page page)
        {
            await MainPage.Navigation.PushModalAsync(page);
        }
        public async Task<Page> PopModalAsync()
        {
            return await MainPage.Navigation.PopModalAsync();
        }

        public async Task ReturnToMainPage()
        {

            //Application.Current.MainPage = new Views.Master();

        }

        public Page MainPage
        {
            get { return Application.Current.MainPage; }
        }

        public async Task SaveAppProperties(string key, string value)
        {
            Application.Current.Properties[key] = value;
            await Application.Current.SavePropertiesAsync();
        }
        public string GetAppProperties(string key)
        {
            return Application.Current.Properties[key].ToString();

        }

    }
}
