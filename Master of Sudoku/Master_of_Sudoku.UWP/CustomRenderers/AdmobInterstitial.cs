using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Master_of_Sudoku.CustomRenderers.AdMob;
using Master_of_Sudoku.UWP.CustomRenderers;
using Microsoft.Advertising.WinRT.UI;
using Windows.UI.Popups;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(AdmobInterstitial))]
namespace Master_of_Sudoku.UWP.CustomRenderers
{
    public class AdmobInterstitial : IAdmobInterstitial
    {
        InterstitialAd _adInterstitial=null;

        public void Show(string adUnit )
        {
            _adInterstitial = new InterstitialAd();
            string adapplicatioId = "9NQ4P04F8HH1";
            adUnit = "1100018074";
            
            _adInterstitial.RequestAd(AdType.Display, adUnit, adapplicatioId);
            _adInterstitial.AdReady += (sender, args) => 
            {
                if (InterstitialAdState.Ready == _adInterstitial.State)
                {
                    _adInterstitial.Show();
                }
            };
            _adInterstitial.ErrorOccurred += (sender, args) =>
            {
                //var dialog = new MessageDialog("Error occurred: " + args.ErrorMessage);
                //dialog.Commands.Add(new UICommand("OK"));
                //Task.Run(async() => {await dialog.ShowAsync(); }); 
            };

        }

    }
}