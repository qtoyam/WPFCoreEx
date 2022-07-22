using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	/// <summary>
	/// Returns <see langword="false"/> if enum value == 0, otherwise <see langword="true"/>.
	/// </summary>
	[ValueConversion(sourceType: typeof(Enum), targetType: typeof(bool))]
	public class EnumIsZero2Bool : StaticConverter<EnumIsZero2Bool>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt64(value) == 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
