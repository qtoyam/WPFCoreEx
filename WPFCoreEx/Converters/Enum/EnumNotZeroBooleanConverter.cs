using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFCoreEx.Converters
{
	/// <summary>
	/// Converts <see cref="Enum"/> to <see langword="bool"/>. If <see cref="Enum"/> value is 0 return <see langword="true"/>, otherwise <see langword="false"/>.
	/// </summary>
	[ValueConversion(typeof(Enum), typeof(bool))]
	public class EnumNotZeroBooleanConverter : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToInt32(value) != 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider) => this;
	}
}
