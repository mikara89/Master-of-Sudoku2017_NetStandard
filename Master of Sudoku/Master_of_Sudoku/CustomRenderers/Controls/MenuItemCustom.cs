using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master_of_Sudoku.CustomRenderers.Controls
{
    public class MenuItemCustom : MenuItem
    {

        //public MenuItemCustom()
        //{
        //    InitVisibility();
        //}

        //private async void InitVisibility()
        //{
        //    OnIsVisibleChanged(this, false, IsVisible);
        //}

        //public new ContentPage Parent { set; get; }

        //public bool IsVisible
        //{
        //    get { return (bool)GetValue(IsVisibleProperty); }
        //    set { SetValue(IsVisibleProperty, value); }
        //}

        //public static BindableProperty IsVisibleProperty =
        //    BindableProperty.Create<MenuItemCustom, bool>(o => o.IsVisible, false, propertyChanged: OnIsVisibleChanged);

        //private static void OnIsVisibleChanged(BindableObject bindable, bool oldvalue, bool newvalue)
        //{
        //    var item = bindable as MenuItemCustom;
        //    var per =item.Parent ;
        //    if (item.Parent == null)
        //        return;

        //    var items = item.ContextActions;

        //    if (newvalue && !items.Contains(item))
        //    {
        //        items.Add(item);
        //    }
        //    else if (!newvalue && items.Contains(item))
        //    {
        //        items.Remove(item);
        //    }
        //}
    }
}
//    public class BindableToolbarItem : ToolbarItem
//    {

//        public BindableToolbarItem()
//        {
//            InitVisibility();
//        }

//        private async void InitVisibility()
//        {
//            OnIsVisibleChanged(this, false, IsVisible);
//        }

//        public new ContentPage Parent { set; get; }

//        public bool IsVisible
//        {
//            get { return (bool)GetValue(IsVisibleProperty); }
//            set { SetValue(IsVisibleProperty, value); }
//        }

//        public static BindableProperty IsVisibleProperty =
//            BindableProperty.Create<BindableToolbarItem, bool>(o => o.IsVisible, false, propertyChanged: OnIsVisibleChanged);

//        private static void OnIsVisibleChanged(BindableObject bindable, bool oldvalue, bool newvalue)
//        {
//            var item = bindable as BindableToolbarItem;

//            if (item.Parent == null)
//                return;

//            var items = item.Parent.ToolbarItems;

//            if (newvalue && !items.Contains(item))
//            {
//                items.Add(item);
//            }
//            else if (!newvalue && items.Contains(item))
//            {
//                items.Remove(item);
//            }
//        }
//    }
//}