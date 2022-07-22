using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class InvBool2VisConv : StaticConverter<InvBool2VisConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (Visibility)value != Visibility.Visible;
		}
	}
}
