
using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.OS;

namespace Master_of_Sudoku.Droid
{
    [Activity(Label = "Master_of_Sudoku", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-4482874738236340~7371350800");
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

