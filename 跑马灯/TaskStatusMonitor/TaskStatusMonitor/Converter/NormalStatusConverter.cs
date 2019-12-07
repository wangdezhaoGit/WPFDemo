using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TaskStatusMonitor.Enums;

namespace TaskStatusMonitor.Converter
{

    public class NormalStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskStatusEnums ts = (TaskStatusEnums) value ;

            if (ts == TaskStatusEnums.Error)
            {

                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
