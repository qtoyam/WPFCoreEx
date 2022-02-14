﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using WPFCoreEx.Exceptions;
using WPFCoreEx.MarkupExtensions;

namespace WPFCoreEx.Converters
{
	/// <summary>
	/// Visible if object null, otherwise collapsed.
	/// </summary>
	[ValueConversion(typeof(object), typeof(Visibility))]
	public class Null2VisConv : StaticMarkupExtension<Null2VisConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new BackConversionNotSupportedException();
		}
	}
}
