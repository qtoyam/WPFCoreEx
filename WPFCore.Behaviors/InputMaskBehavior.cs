using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPFCore.Behaviors
{
	public enum MaskType : byte
	{
		OnlyDigits = 1,
		Custom = 128
	}
	public sealed class InputHandleBehavior : BehaviorBase<TextBox>
	{
		protected override void OnSetup()
		{
			_regex = MaskType switch
			{
				MaskType.OnlyDigits => _numRegex.Value,
				MaskType.Custom => new(CustomRegex ?? throw new ArgumentNullException(nameof(CustomRegex), "No custom regex string.")),
				_ => throw new ArgumentException("No mask type", nameof(MaskType)),
			};
			AssociatedObject.PreviewTextInput += Filter_Input;
			DataObject.AddPastingHandler(AssociatedObject, Filter_paste);
		}
		protected override void OnCleanup()
		{
			AssociatedObject.PreviewTextInput -= Filter_Input;
			DataObject.RemovePastingHandler(AssociatedObject, Filter_paste);
		}

		private Regex _regex = null!;

		public MaskType MaskType
		{
			get => (MaskType)GetValue(MaskTypeProperty);
			set => SetValue(MaskTypeProperty, value);
		}
		public static readonly DependencyProperty MaskTypeProperty =
			DependencyProperty.Register("MaskType", typeof(MaskType), typeof(InputHandleBehavior),
				new PropertyMetadata(MaskType.Custom));

		public string? CustomRegex
		{
			get => (string?)GetValue(CustomRegexProperty);
			set => SetValue(CustomRegexProperty, value);
		}
		public static readonly DependencyProperty CustomRegexProperty =
			DependencyProperty.Register("CustomRegex", typeof(string), typeof(InputHandleBehavior),
				new PropertyMetadata(null));

		#region lazy static regex
		private static readonly Lazy<Regex> _numRegex = new(() => new Regex(@"^[0-9]+$", RegexOptions.Compiled), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
		#endregion //lazy static regex


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
