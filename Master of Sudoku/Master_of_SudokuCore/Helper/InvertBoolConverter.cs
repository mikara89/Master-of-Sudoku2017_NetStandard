using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master_of_Sudoku.Helper
{
    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TimeSpanToTimeStringConverter : IValueConverter
    {
        public static TimeSpanToTimeStringConverter Instance = new TimeSpanToTimeStringConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan timeSpan = (TimeSpan)value;
            DateTime dateTime = DateTime.MinValue + timeSpan;

            // acknowledgement: based on some code from 
            // http://stackoverflow.com/questions/1292246/why-doesnt-datetime-toshorttimestring-respect-the-short-time-format-in-regio

            DateTimeFormatInfo dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            string shortTimePattern
                = dateTimeFormat.LongTimePattern.Replace(":ss", String.Empty).Replace(":s", String.Empty);
            return dateTime.ToString(shortTimePattern);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("TimeSpanToTimeStringConverter.ConvertBack");
        }

    }
}
