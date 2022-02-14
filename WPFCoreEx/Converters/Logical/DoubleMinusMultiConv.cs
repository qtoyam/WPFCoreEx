using System;
using System.Globalization;
using System.Windows.Data;

using WPFCoreEx.Exceptions;
using WPFCoreEx.MarkupExtensions;

namespace WPFCoreEx.Converters
{
	[ValueConversion(typeof(double), typeof(double))]
	public class DoubleMinusMultiConv : StaticMarkupExtension<DoubleMinusMultiConv>, IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			double v = (double)values[0];
			for (int i = 1; i < values.Length; i++)
			{
				v -= (double)values[i];
			}
			return v;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new BackConversionNotSupportedException();
		}
	}
}
