using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WPFCoreEx.Controls
{
	//TODO: throw if trying to set content
	public class ToggleButtonImg : ToggleButton
	{
		static ToggleButtonImg() => DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonImg),
			new FrameworkPropertyMetadata(typeof(ToggleButtonImg)));

		#region Backgrounds
		public Brush BackgroundMouseOver
		{
			get => (Brush)GetValue(BackgroundMouseOverProperty);
			set => SetValue(BackgroundMouseOverProperty, value);
		}
		public static readonly DependencyProperty BackgroundMouseOverProperty =
			DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(ToggleButtonImg),
				new PropertyMetadata());

		public Brush BackgroundClick
		{
			get => (Brush)GetValue(BackgroundClickProperty);
			set => SetValue(BackgroundClickProperty, value);
		}
		public static readonly DependencyProperty BackgroundClickProperty =
			DependencyProperty.Register("BackgroundClick", typeof(Brush), typeof(ToggleButtonImg),
				new PropertyMetadata());


		public Brush BackgroundDisabled
		{
			get => (Brush)GetValue(BackgroundDisabledProperty);
			set => SetValue(BackgroundDisabledProperty, value);
		}
		public static readonly DependencyProperty BackgroundDisabledProperty =
			DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(ToggleButtonImg),
				new PropertyMetadata());
		#endregion //Backgrounds

		#region Opacity
		public double OpacityDefault
		{
			get => (double)GetValue(OpacityDefaultProperty);
			set => SetValue(OpacityDefaultProperty, value);
		}
		public static readonly DependencyProperty OpacityDefaultProperty =
			DependencyProperty.Register("OpacityDefault", typeof(double), typeof(ToggleButtonImg),
				new PropertyMetadata());

		public double OpacityMouseOver
		{
			get => (double)GetValue(OpacityMouseOverProperty);
			set => SetValue(OpacityMouseOverProperty, value);
		}
		public static readonly DependencyProperty OpacityMouseOverProperty =
			DependencyProperty.Register("OpacityMouseOver", typeof(double), typeof(ToggleButtonImg),
				 new PropertyMetadata());

		public double OpacityClick
		{
			get => (double)GetValue(OpacityClickProperty);
			set => SetValue(OpacityClickProperty, value);
		}
		public static readonly DependencyProperty OpacityClickProperty =
			DependencyProperty.Register("OpacityClick", typeof(double), typeof(ToggleButtonImg),
				 new PropertyMetadata());
		#endregion //Opacity

		#region Images
		public ImageSource UncheckedImage
		{
			get => (ImageSource)GetValue(UncheckedImageProperty);
			set => SetValue(UncheckedImageProperty, value);
		}
		public static readonly DependencyProperty UncheckedImageProperty =
			DependencyProperty.Register("UncheckedImage", typeof(ImageSource), typeof(ToggleButtonImg),
				new PropertyMetadata());

		public ImageSource CheckedImage
		{
			get => (ImageSource)GetValue(CheckedImageProperty);
			set => SetValue(CheckedImageProperty, value);
		}
		public static readonly DependencyProperty CheckedImageProperty =
			DependencyProperty.Register("CheckedImage", typeof(ImageSource), typeof(ToggleButtonImg),
				new PropertyMetadata());
		#endregion //Images

		#region Additional
		public CornerRadius CornerRadius
		{
			get => (CornerRadius)GetValue(CornerRadiusProperty);
			set => SetValue(CornerRadiusProperty, value);
		}
		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ToggleButtonImg),
				new PropertyMetadata());
		#endregion //Additional

		#region Helpers
		public bool OpacityChanging
		{
			get => (bool)GetValue(OpacityChangingProperty);
			set => SetValue(OpacityChangingProperty, value);
		}
		public static readonly DependencyProperty OpacityChangingProperty =
			DependencyProperty.Register("OpacityChanging", typeof(bool), typeof(ToggleButtonImg),
				new PropertyMetadata(OnOpacityChangingChanged));
		private static void OnOpacityChangingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			if (obj is ToggleButtonImg tbe)
			{
				if (args.NewValue is true)
				{
					tbe.OpacityDefault = 0.65d;
					tbe.OpacityMouseOver = 0.85d;
					tbe.OpacityClick = 1.0d;
				}
				else
				{
					tbe.OpacityDefault = 1;
					tbe.OpacityMouseOver = 1;
					tbe.OpacityClick = 1;
				}
			}
		}

		public bool NoBackground
		{
			get => (bool)GetValue(NoBackgroundProperty);
			set => SetValue(NoBackgroundProperty, value);
		}
		public static readonly DependencyProperty NoBackgroundProperty =
			DependencyProperty.Register("NoBackground", typeof(bool), typeof(ToggleButtonImg),
				new PropertyMetadata(OnNoBackgroundChanged));
		private static void OnNoBackgroundChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			if (obj is ToggleButtonImg tbe)
			{
				if (args.NewValue is true)
				{
					tbe.Background = Brushes.Transparent;
					tbe.BackgroundMouseOver = Brushes.Transparent;
					tbe.BackgroundClick = Brushes.Transparent;
					tbe.BackgroundDisabled = Brushes.Transparent;
					tbe.BorderBrush = null;
					tbe.BorderThickness = new(0);
				}
				else
				{
					throw new InvalidOperationException("Only true is valid, false do nothing");
				}
			}
		}
		#endregion //Helpers

		protected override void OnContentChanged(object oldContent, object newContent)
		{
			throw new InvalidOperationException($"Use {nameof(UncheckedImage)} and {nameof(CheckedImage)} instead.");
		}
	}
}
