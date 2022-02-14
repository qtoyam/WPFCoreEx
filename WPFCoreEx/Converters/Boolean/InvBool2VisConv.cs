using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using WPFCoreEx.Exceptions;
using WPFCoreEx.MarkupExtensions;

namespace WPFCoreEx.Converters
{
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class InvBool2VisConv : StaticMarkupExtension<InvBool2VisConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new BackConversionNotSupportedException();
		}
	}
}
