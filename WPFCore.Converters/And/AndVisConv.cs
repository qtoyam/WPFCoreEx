using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class AndVisConv : StaticConverter<AndVisConv>, IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i] == DependencyProperty.UnsetValue || values[i] is false)
				{
					return Visibility.Collapsed;
				}
			}
			return Visibility.Visible;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
