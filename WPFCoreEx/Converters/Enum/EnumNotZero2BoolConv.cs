using System;
using System.Globalization;
using System.Windows.Data;

using WPFCoreEx.Exceptions;
using WPFCoreEx.MarkupExtensions;

namespace WPFCoreEx.Converters
{
	/// <summary>
	/// Converts <see cref="Enum"/> to <see langword="bool"/>. If <see cref="Enum"/> value is 0 return <see langword="true"/>, otherwise <see langword="false"/>.
	/// </summary>
	[ValueConversion(typeof(System.Enum), typeof(bool))]
	public class EnumNotZero2BoolConv : StaticMarkupExtension<EnumNotZero2BoolConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt32(value) != 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new BackConversionNotSupportedException();
		}
	}
}
