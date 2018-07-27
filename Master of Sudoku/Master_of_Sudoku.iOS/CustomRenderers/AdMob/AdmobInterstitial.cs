using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Master_of_Sudoku.CustomRenderers.AdMob;
using Foundation;
using UIKit;
using Google.MobileAds;
using Master_of_Sudoku.iOS.CustomRenderers.AdMob;

[assembly: Xamarin.Forms.Dependency(typeof(AdmobInterstitial))]
namespace Master_of_Sudoku.iOS.CustomRenderers.AdMob
{
    public class AdmobInterstitial : IAdmobInterstitial
    {
        Interstitial _adInterstitial;

        public void Show(string adUnit=null)
        {
            _adInterstitial = new Interstitial("ca-app-pub-4482874738236340/4030871599");
            _adInterstitial.AdReceived += (sender, args) =>
            {
                if (_adInterstitial.IsReady)
                {
                    var window = UIApplication.SharedApplication.KeyWindow;
                    var vc = window.RootViewController;
                    while (vc.PresentedViewController != null)
                    {
                        vc = vc.PresentedViewController;
                    }
                    _adInterstitial.PresentFromRootViewController(vc);
                }
            };
        

            _adInterstitial.LoadRequest(Request.GetDefaultRequest());

        }
    }
}