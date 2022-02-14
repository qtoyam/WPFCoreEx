﻿using System;
using System.Globalization;
using System.Windows.Data;

using WPFCoreEx.Exceptions;
using WPFCoreEx.MarkupExtensions;

namespace WPFCoreEx.Converters
{
	/// <summary>
	/// Return <see langword="false"/> if enum value == 0, otherwise <see langword="true"/>
	/// </summary>
	[ValueConversion(sourceType: typeof(System.Enum), targetType: typeof(bool))]
	public class EnumIsZero2Bool : StaticMarkupExtension<EnumIsZero2Bool>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt32(value) == 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new BackConversionNotSupportedException();
		}
	}
}