using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFCoreEx.ValidationRules
{
	public class StringNotEmptyValidationRule : ValidationRule
	{
		public string MessageIfEmpty { get; set; } = "Required";

		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			return string.IsNullOrEmpty(value as string) ?
				new(false, MessageIfEmpty)
				:
				new(true, null);
		}
	}
}
