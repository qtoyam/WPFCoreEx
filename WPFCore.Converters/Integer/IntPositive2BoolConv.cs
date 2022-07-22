using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(int), typeof(bool))]
	public class IntPositive2BoolConv : StaticConverter<IntPositive2BoolConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt64(value) >= 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
