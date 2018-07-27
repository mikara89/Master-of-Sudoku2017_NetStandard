using Master_of_Sudoku.CustomRenderers.AdMob;
using Master_of_Sudoku.Droid.CustomRenderers.AdMob;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]
namespace Master_of_Sudoku.Droid.CustomRenderers.AdMob
{
    public class AdMobRenderer : ViewRenderer<AdMobView, Android.Gms.Ads.AdView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var ad = new Android.Gms.Ads.AdView(Forms.Context);
                ad.AdSize = Android.Gms.Ads.AdSize.Banner;
                ad.AdUnitId = "ca-app-pub-4482874738236340/3115700583";

                var requestbuilder = new Android.Gms.Ads.AdRequest.Builder();
                ad.LoadAd(requestbuilder.Build());

                SetNativeControl(ad);
            }
        }
    }
}