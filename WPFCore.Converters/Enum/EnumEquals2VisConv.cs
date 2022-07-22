using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(Enum), typeof(bool), ParameterType = typeof(Enum))]
	public class EnumEquals2VisConv : StaticConverter<EnumEquals2VisConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt64(value) == System.Convert.ToInt64(parameter) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
