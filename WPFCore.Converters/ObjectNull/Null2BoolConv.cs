using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(object), typeof(bool))]
	public class Null2BoolConv : StaticConverter<Null2BoolConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value is null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
