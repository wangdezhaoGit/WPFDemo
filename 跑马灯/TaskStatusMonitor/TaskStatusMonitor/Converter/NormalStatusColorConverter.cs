using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using TaskStatusMonitor.Enums;

namespace TaskStatusMonitor.Converter
{

    public class NormalStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskStatusEnums ts = (TaskStatusEnums) value;

            switch (ts)
            {
                case TaskStatusEnums.Ready:
                    return new SolidColorBrush(Colors.Gray);
                case TaskStatusEnums.Done:
                    return new SolidColorBrush(Colors.Green);
                case TaskStatusEnums.Excuting:
                    return new SolidColorBrush(Colors.Yellow);
                default: return new SolidColorBrush(Colors.Gray);
            }

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
