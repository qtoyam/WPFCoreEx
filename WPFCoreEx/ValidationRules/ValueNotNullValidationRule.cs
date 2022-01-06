using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WPFCoreEx.ValidationRules
{
	public class ValueNotNullValidationRule : ValidationRule
	{
		public string MessageIfNull { get; set; } = "Required";

		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			var t = value == DependencyProperty.UnsetValue;
			return !t && value == null ? new(false, MessageIfNull) : new(true, null);
		}
	}
}
