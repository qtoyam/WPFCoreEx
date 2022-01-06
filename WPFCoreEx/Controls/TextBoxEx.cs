using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WPFCoreEx.Controls
{
	public class TextBoxEx : TextBox
	{
		static TextBoxEx()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxEx), new FrameworkPropertyMetadata(typeof(TextBoxEx)));
			IsReadOnlyProperty.OverrideMetadata(typeof(TextBoxEx), new FrameworkPropertyMetadata(OnIsReadOnlyChanged));
		}

		private static void OnIsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TextBoxEx)d).HandleIsReadonly();
		}

		private Style? _nonReadonlyStyle = null;
		private void HandleIsReadonly()
		{
			if (IsReadOnly)
			{
				_nonReadonlyStyle = Style;
				Style = ReadOnlyStyle;
			}
			else
			{
				Style = _nonReadonlyStyle;
				_nonReadonlyStyle = null;
			}
		}

		public Style? ReadOnlyStyle
		{
			get => (Style?)GetValue(ReadOnlyStyleProperty);
			set => SetValue(ReadOnlyStyleProperty, value);
		}
		public static readonly DependencyProperty ReadOnlyStyleProperty =
			DependencyProperty.Register("ReadOnlyStyle", typeof(Style), typeof(TextBoxEx),
				new PropertyMetadata(defaultValue: null));

		public string? HintText
		{
			get => (string?)GetValue(HintTextProperty);
			set => SetValue(HintTextProperty, value);
		}
		public static readonly DependencyProperty HintTextProperty =
			DependencyProperty.Register("HintText", typeof(string), typeof(TextBoxEx),
				new PropertyMetadata(defaultValue: null));

		public CornerRadius CornerRadius
		{
			get => (CornerRadius)GetValue(CornerRadiusProperty);
			set => SetValue(CornerRadiusProperty, value);
		}
		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TextBoxEx),
			new FrameworkPropertyMetadata(new CornerRadius(0)));

		#region ExtraWidth
		public double ExtraWidth
		{
			get => (double)GetValue(ExtraWidthProperty);
			set => SetValue(ExtraWidthProperty, value);
		}
		public static readonly DependencyProperty ExtraWidthProperty =
			DependencyProperty.Register("ExtraWidth", typeof(double), typeof(TextBoxEx),
				new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure));

		protected override Size MeasureOverride(Size constraint)
		{
			var baseSize = base.MeasureOverride(constraint);
			if (ExtraWidth != 0d)
			{
				baseSize.Width = Math.Min(constraint.Width, baseSize.Width + ExtraWidth);
			}
			return baseSize;
		}
		#endregion //ExtraWidth
	}
}
