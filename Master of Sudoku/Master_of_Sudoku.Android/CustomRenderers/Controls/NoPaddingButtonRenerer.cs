using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
//using Android.Widget;
using Xamarin.Forms;
using Master_of_Sudoku.CustomRenderers.Controls;
using Xamarin.Forms.Platform.Android;
using Master_of_Sudoku.Droid.CustomRenderers.Controls;

[assembly: ExportRenderer(typeof(NoPaddingButton), typeof(NoPaddingButtonRenerer))]
namespace Master_of_Sudoku.Droid.CustomRenderers.Controls
{
    public class NoPaddingButtonRenerer:ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {

            }
            else if (e.NewElement != null)
            {

            }
            Control?.SetPadding(0, 0, 0, 0);
        }
    }
}