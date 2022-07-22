using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCore.Converters
{
	// source = from, target = to
	// StaticMarkupExtension = NO DEPENDENCY PROPS!!!
	[ValueConversion(typeof(int), typeof(long))]
	class ExampleConv : StaticConverter<ExampleConv>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}

		//Only for MarkupExtension
		//public override object ProvideValue(IServiceProvider serviceProvider) => this;
	}
}
