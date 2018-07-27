using Master_of_Sudoku.CustomRenderers.Controls;
using Master_of_Sudoku.UWP.CustomRenderers.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ContentViewRoundedCorners), typeof(ContentViewRoundedCornersRenderer))]
namespace Master_of_Sudoku.UWP.CustomRenderers.Controls
{
    public class ContentViewRoundedCornersRenderer : VisualElementRenderer<ContentView, Border>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                return;
            }
            Control.CornerRadius= CornerRadiusHelper.FromUniformRadius( ((ContentViewRoundedCorners)Element).CornerRadius);
           
        }
    }
}