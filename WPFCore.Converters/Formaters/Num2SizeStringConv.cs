﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFCore.Converters
{
	[ValueConversion(typeof(double), typeof(string))]
	public class Num2SizeStringConv : StaticConverter<Num2SizeStringConv>, IValueConverter
	{
		const double KB = 1 << 10;
		const double MB = 1 << 20;
		const double GB = 1 << 30;
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value == DependencyProperty.UnsetValue ||
				string.IsNullOrEmpty((string?)value))
			{
				return string.Empty;
			}
			var v = System.Convert.ToDouble(value);
			return v switch
			{
				> GB => $"{v / GB:0.0} GB",
				> MB => $"{v / MB:0.0} MB",
				> KB => $"{v / KB:0.0} KB",
				_ => $"{v} B",
			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}
	}
}
