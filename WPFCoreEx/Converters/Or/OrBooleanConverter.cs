using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFCoreEx.Converters
{
	[ValueConversion(typeof(bool), typeof(bool))]
	public class OrBooleanConverter : MarkupExtension, IMultiValueConverter
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
			throw new NotSupportedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider) => this;
	}
}
