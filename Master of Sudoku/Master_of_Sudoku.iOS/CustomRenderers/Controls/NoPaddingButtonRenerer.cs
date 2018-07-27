using Master_of_Sudoku.CustomRenderers.Controls;
using Master_of_Sudoku.iOS.CustomRenderers.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoPaddingButton), typeof(NoPaddingButtonRenerer))]

namespace Master_of_Sudoku.iOS.CustomRenderers.Controls 
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
                //Control.ContentEdgeInsets.Bottom = new nfloat(0);
                //Control.ContentEdgeInsets = UIKit.UIEdgeInsets.FromString("0,0,0,0"); 
            }

        }
    }
}