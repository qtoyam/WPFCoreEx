using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFCore.Converters
{
	// source = from, target = to
	[ValueConversion(typeof(int), typeof(long))]
	public class DoubleMathConv : MarkupExtension, IValueConverter
	{
		public double Operand { get; set; }
		public MathOperation Operation { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double v = (double)value;
			return Operation switch
			{
				MathOperation.Add => v + Operand,
				MathOperation.Subtract => v - Operand,
				MathOperation.Multiply => v * Operand,
				MathOperation.Divide => v / Operand,
				MathOperation.Modulo => v % Operand,
				_ => throw new NotImplementedException(),
			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new ConvertBackNotSupportedExtension();
		}

		public override object ProvideValue(IServiceProvider serviceProvider) => this;
	}
}
