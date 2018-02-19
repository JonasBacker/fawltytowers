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

            switch((CompletionStatus) value)
            {
                case CompletionStatus.inProgress:
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

    public class ServiceClassToFilepathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string imagefile = "";

            switch ((ServiceClass) value)
            {
                case ServiceClass.cleaning:
                    imagefile = "Assets/vacuum_cleaner.png";
                    break;
                case ServiceClass.service:
                    imagefile = "Assets/food_drink.png";
                    break;
                case ServiceClass.maintenance:
                    imagefile = "Assets/tools.png";
                    break;
                default:
                    imagefile = "Assets/Square150x150Logo.scale - 200.png";
                    break;
            }

            return imagefile;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class StatusToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            CompletionStatus inStatus = (CompletionStatus)value;

            
            double opac = 1.0;

            if (inStatus != CompletionStatus.inProgress)
                opac = 0.3;

            return opac;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
