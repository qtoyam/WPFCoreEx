using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(string), typeof(Visibility))]
	public class StringNotNullEmpty2VisConv : StaticConverter<StringNotNullEmpty2VisConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.IsNullOrEmpty((string?)value) ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
