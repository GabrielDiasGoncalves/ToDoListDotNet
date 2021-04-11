using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ToDoList.UI.Converters
{
    public class ColorToSolidColorBrushValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color)
            {
                var color = (System.Drawing.Color)value;
                return new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}