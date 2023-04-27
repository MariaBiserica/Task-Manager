using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Task_Manager.ViewModels
{
    internal class IconConverterVM: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string iconPath)
            {
                var uri = new Uri($"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/{iconPath}", UriKind.Absolute);
                var bitmap = new BitmapImage(uri);
                return bitmap;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
