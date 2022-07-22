using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(bool), typeof(bool))]
	public class Or2BoolConv : StaticConverter<Or2BoolConv>, IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i] is true) return true;
			}
			return false;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
