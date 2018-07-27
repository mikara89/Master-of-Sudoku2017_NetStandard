using Master_of_Sudoku.CustomRenderers.Controls;
using Master_of_Sudoku.UWP.CustomRenderers.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NoPaddingButton), typeof(NoPaddingButtonRenerer))]

namespace Master_of_Sudoku.UWP.CustomRenderers.Controls
{
    public class NoPaddingButtonRenerer: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement!=null)
            {

            }else if(e.NewElement!= null)
            {

            }
            if (Control != null)
            {
                Control.Padding = new Windows.UI.Xaml.Thickness(0); 
            }

        }
    }
}