
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Master_of_Sudoku.CustomRenderers.AdMob;
using Master_of_Sudoku.iSO.CustomRenderers.AdMob;
using iAd;
using Google.MobileAds;
using CoreGraphics;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]

namespace Master_of_Sudoku.iSO.CustomRenderers.AdMob 
{
    public class AdMobRenderer : ViewRenderer
    {
        const string AdmobID = "ca-app-pub-4482874738236340/1923583008";

        BannerView adView;
        bool viewOnScreen;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {
                UIViewController viewCtrl = null;

                foreach (UIWindow v in UIApplication.SharedApplication.Windows)
                {
                    if (v.RootViewController != null)
                    {
                        viewCtrl = v.RootViewController;
                    }
                }

                adView = new BannerView(size: AdSizeCons.Banner, origin: new CGPoint(-10, 0))
                {
                    AdUnitID = AdmobID,
                    RootViewController = viewCtrl
                };

                adView.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen) this.AddSubview(adView);
                    viewOnScreen = true;
                };


                adView.LoadRequest(Request.GetDefaultRequest());
                base.SetNativeControl(adView);
            }
        }
    }



    //public class AdMobRenderer : ViewRenderer
    //{
    //    const string AdmobID = "ca-app-pub-4482874738236340/4199263114";

    //    BannerView adView;
    //    bool viewOnScreen;

    //    protected override void OnElementChanged(ElementChangedEventArgs<View> e)
    //    {
    //        base.OnElementChanged(e);

    //        if (e.NewElement == null)
    //            return;

    //        if (e.OldElement == null)
    //        {
    //            adView = new BannerView(size: AdSizeCons.SmartBannerPortrait,
    //                                       origin: new CGPoint(0, UIScreen.MainScreen.Bounds.Size.Height - AdSizeCons.Banner.Size.Height))
    //            {
    //                AdUnitID = AdmobID,
    //                RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
    //            };

    //            adView.AdReceived += (sender, args) =>
    //            {
    //                if (!viewOnScreen) this.AddSubview(adView);
    //                viewOnScreen = true;
    //            };


    //            adView.LoadRequest(Request.GetDefaultRequest());
    //            base.SetNativeControl(adView);
    //        }
    //    }
    //}
}