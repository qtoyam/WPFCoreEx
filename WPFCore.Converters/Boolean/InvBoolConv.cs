using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(bool), typeof(bool))]
	public class InvBoolConv : StaticConverter<InvBoolConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}
	}
}
