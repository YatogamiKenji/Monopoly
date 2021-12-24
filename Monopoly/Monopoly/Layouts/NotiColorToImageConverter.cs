using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Monopoly.Layouts
{
    class NotiColorToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			switch ((string)value)
			{
				case "Blue":
					return new BitmapImage(new Uri(@"/Monopoly;component/Images/message_box_center_map/message_box_center_map_blue.png", UriKind.Relative));
				case "Red":
					return new BitmapImage(new Uri(@"/Monopoly;component/Images/message_box_center_map/message_box_center_map_red.png", UriKind.Relative));
				case "Green":
					return new BitmapImage(new Uri(@"/Monopoly;component/Images/message_box_center_map/message_box_center_map_green.png", UriKind.Relative));
			}
			return new BitmapImage(new Uri(@"/Monopoly;component/Images/message_box_center_map/message_box_center_map_blue.png", UriKind.Relative));
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
