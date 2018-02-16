using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace StaffUtility
{
    public class StatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility vis;

            switch((Model.CompletionStatus) value)
            {
                case Model.CompletionStatus.inProgress:
                    vis = Visibility.Visible;
                    break;
                default:
                    vis = Visibility.Collapsed;
                    break;
            }

            return vis;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedObjectToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility vis = Visibility.Collapsed;

            if (parameter != null)
            {
                int ob = (Int32)value;

                int selected = Int32.Parse( (string) parameter);

                if (ob == selected)
                    vis = Visibility.Visible;
            }
            return vis;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
