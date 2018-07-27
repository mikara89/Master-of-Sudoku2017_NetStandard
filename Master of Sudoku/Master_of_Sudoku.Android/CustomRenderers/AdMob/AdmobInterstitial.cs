using Master_of_Sudoku;
using Android.Gms.Ads;
using Master_of_Sudoku.Droid;
using Android.App;
using Master_of_Sudoku.Droid.CustomRenderers.AdMob;
using Master_of_Sudoku.CustomRenderers.AdMob;

[assembly: Xamarin.Forms.Dependency(typeof(AdmobInterstitial))]
namespace Master_of_Sudoku.Droid.CustomRenderers.AdMob
{
    public class AdmobInterstitial : IAdmobInterstitial
    {
        InterstitialAd _ad;

        public void Show(string adUnit=null)
        {
            var context = Application.Context;
            _ad = new InterstitialAd(context);
            _ad.AdUnitId = "ca-app-pub-4482874738236340/9548235239";

            var intlistener = new InterstitialAdListener(_ad);
            intlistener.OnAdLoaded();
            _ad.AdListener = intlistener;

            var requestbuilder = new AdRequest.Builder();
            _ad.LoadAd(requestbuilder.Build());
        }
    }
}