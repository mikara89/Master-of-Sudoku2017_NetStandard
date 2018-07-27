using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Master_of_Sudoku.Helper
{
    public class RowNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return 0;
            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            return index + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   
}
