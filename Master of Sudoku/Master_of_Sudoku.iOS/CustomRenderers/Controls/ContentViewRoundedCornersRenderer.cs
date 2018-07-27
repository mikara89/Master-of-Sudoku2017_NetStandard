using Master_of_Sudoku.CustomRenderers.Controls;
using Master_of_Sudoku.iOS.CustomRenderers.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentViewRoundedCorners), typeof(ContentViewRoundedCornersRenderer))]
namespace Master_of_Sudoku.iOS.CustomRenderers.Controls
{
    public class ContentViewRoundedCornersRenderer : VisualElementRenderer<ContentView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                return;
            }

            Layer.CornerRadius = ((ContentViewRoundedCorners)Element).CornerRadius;
        }
    }
}