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
	public enum MaskType : byte
	{
		OnlyDigits = 1,
		Custom = 128
	}
	public sealed class InputHandleBehavior : Behavior<TextBox>
	{
		public MaskType MaskType
		{
			get { return (MaskType)GetValue(MaskTypeProperty); }
			set { SetValue(MaskTypeProperty, value); }
		}
		public static readonly DependencyProperty MaskTypeProperty =
			DependencyProperty.Register("MaskType", typeof(MaskType), typeof(InputHandleBehavior), new PropertyMetadata(MaskType.Custom));

		public string? CustomRegex
		{
			get { return (string?)GetValue(CustomRegexProperty); }
			set { SetValue(CustomRegexProperty, value); }
		}
		public static readonly DependencyProperty CustomRegexProperty =
			DependencyProperty.Register("CustomRegex", typeof(string), typeof(InputHandleBehavior), new PropertyMetadata(null));

		#region lazy static regex
		private static readonly Lazy<Regex> _numRegex = new(() => new Regex(@"^[0-9]+$", RegexOptions.Compiled), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
		#endregion //lazy static regex


		private Regex _regex = null!;
		protected override void OnAttached()
		{
			base.OnAttached();

			_regex = MaskType switch
			{
				MaskType.OnlyDigits => _numRegex.Value,
				MaskType.Custom => new(CustomRegex ?? throw new ArgumentNullException(nameof(CustomRegex), "No custom regex string.")),
				_ => throw new ArgumentException("No mask type", nameof(MaskType)),
			};
			AssociatedObject.PreviewTextInput += Filter_Input;
			DataObject.AddPastingHandler(AssociatedObject, Filter_paste);
		}


		protected override void OnDetaching()
		{
			base.OnDetaching();

			AssociatedObject.PreviewTextInput -= Filter_Input;
			DataObject.RemovePastingHandler(AssociatedObject, Filter_paste);
		}
		private void Filter_paste(object sender, DataObjectPastingEventArgs e)
		{
			if (e.SourceDataObject.GetData(DataFormats.UnicodeText, false) is string paste_string)
			{
				if (!_regex.IsMatch(paste_string))
				{
					e.CancelCommand();
				}
			}
		}

		private void Filter_Input(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			if (e.Handled) return;
			else if (!_regex.IsMatch(e.Text))
			{
				e.Handled = true;
			}
		}
	}
}
