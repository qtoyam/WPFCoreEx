using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFCore.Controls
{
	public class TextBoxEx : TextBox
	{
		static TextBoxEx()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxEx), new FrameworkPropertyMetadata(typeof(TextBoxEx)));
		}

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
