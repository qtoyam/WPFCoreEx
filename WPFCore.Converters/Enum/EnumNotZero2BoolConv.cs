using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	/// <summary>
	/// Returns <see langword="true"/> if enum value == 0, otherwise <see langword="false"/>.
	/// </summary>
	[ValueConversion(typeof(Enum), typeof(bool))]
	public class EnumNotZero2BoolConv : StaticConverter<EnumNotZero2BoolConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt64(value) != 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
