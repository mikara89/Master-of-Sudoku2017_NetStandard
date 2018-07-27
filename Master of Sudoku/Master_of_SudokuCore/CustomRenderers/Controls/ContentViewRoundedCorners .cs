using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Master_of_Sudoku.CustomRenderers.Controls
{
    public class ContentViewRoundedCorners: ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create<ContentViewRoundedCorners, float>(x => x.CornerRadius, 0);
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); } }
    }
}
