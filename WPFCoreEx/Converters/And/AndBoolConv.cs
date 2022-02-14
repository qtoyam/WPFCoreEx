using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using WPFCoreEx.Exceptions;
using WPFCoreEx.MarkupExtensions;

namespace WPFCoreEx.Converters
{
	[ValueConversion(typeof(bool), typeof(bool))]
	public class AndBoolConv : StaticMarkupExtension<AndBoolConv>, IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i] == DependencyProperty.UnsetValue || values[i] is false) return false;
			}
			return true;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new BackConversionNotSupportedException();
		}
	}
}
