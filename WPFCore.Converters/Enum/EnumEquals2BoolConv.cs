using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(Enum), typeof(bool), ParameterType = typeof(Enum))]
	public class EnumEquals2BoolConv : StaticConverter<EnumEquals2BoolConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt64(value) == System.Convert.ToInt64(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
