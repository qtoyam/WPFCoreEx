using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public enum MaskType
	{
		None = 0,
		OnlyDigits = 1,
		Custom = 128
	}
	public sealed class InputMaskBehavior : Behavior<TextBox>
	{




		public MaskType MaskType
		{
			get { return (MaskType)GetValue(MaskTypeProperty); }
			set { SetValue(MaskTypeProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MaskType.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MaskTypeProperty =
			DependencyProperty.Register("MaskType", typeof(MaskType), typeof(InputMaskBehavior), new PropertyMetadata(0));





		public string? CustomRegex
		{
			get { return (string?)GetValue(CustomRegexProperty); }
			set { SetValue(CustomRegexProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CustomRegex.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CustomRegexProperty =
			DependencyProperty.Register("CustomRegex", typeof(string), typeof(InputMaskBehavior), new PropertyMetadata(null));





		private static readonly Lazy<Regex> _numRegex = new(() =>
		new Regex("ss"),
			System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

		private Regex _regex;
		protected override void OnAttached()
		{
			base.OnAttached();
			AssociatedObject.PreviewTextInput += Filter_Input;
			_regex = MaskType switch
			{
				MaskType.OnlyDigits => _numRegex.Value,
				_ => throw new ArgumentException("No mask type", nameof(MaskType)),
			};
		}

		private void Filter_Input(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = _regex.IsMatch(e.Text);
		}
	}
}
