using Master_of_Sudoku.UWP.CustomRenderers;
using Master_of_Sudoku.CustomRenderers.AdMob;
using Microsoft.Advertising.WinRT.UI;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]
namespace Master_of_Sudoku.UWP.CustomRenderers 
{
    public class AdMobRenderer : ViewRenderer<AdMobView, AdControl>
    {
        string bannerId = "1100000152";
        AdControl adView;
        string applicationID = "9NQ4P04F8HH1";
        void CreateNativeAdControl()
        {
            if (adView != null)
                return;

            var width = 300;
            var height = 50;
            //if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop")
            //{
            //    width = 728;
            //    height = 90;
            //}
            // Setup your BannerView, review AdSizeCons class for more Ad sizes. 
            adView = new AdControl
            {
                ApplicationId = applicationID,
                AdUnitId = bannerId,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom,
                Height = height,
                Width = width
            };

        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            var view = Element as AdMobView;
            if (e.OldElement != null || view == null)
                return;

            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
            }
        }
    }
}