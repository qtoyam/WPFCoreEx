using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCoreEx.Controls
{
	public sealed class ButtonEx : Button
	{
		static ButtonEx()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonEx), new FrameworkPropertyMetadata(typeof(ButtonEx)));
		}
		#region Backgrounds
		public Brush BackgroundMouseOver
		{
			get { return (Brush)GetValue(BackgroundMouseOverProperty); }
			set { SetValue(BackgroundMouseOverProperty, value); }
		}
		public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(ButtonEx), new PropertyMetadata());

		public Brush BackgroundClick
		{
			get { return (Brush)GetValue(BackgroundClickProperty); }
			set { SetValue(BackgroundClickProperty, value); }
		}
		public static readonly DependencyProperty BackgroundClickProperty = DependencyProperty.Register("BackgroundClick", typeof(Brush), typeof(ButtonEx), new PropertyMetadata());


		public Brush BackgroundDisabled
		{
			get { return (Brush)GetValue(BackgroundDisabledProperty); }
			set { SetValue(BackgroundDisabledProperty, value); }
		}
		public static readonly DependencyProperty BackgroundDisabledProperty = DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(ButtonEx), new PropertyMetadata());
		#endregion //Backgrounds

		#region Additional
		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ButtonEx), new PropertyMetadata());

		[DesignOnly(true)]
		public ButtonBehavior ButtonBehavior
		{
			get { return (ButtonBehavior)GetValue(ButtonBehaviorProperty); }
			set { SetValue(ButtonBehaviorProperty, value); }
		}
		public static readonly DependencyProperty ButtonBehaviorProperty = DependencyProperty.Register("ButtonBehavior", typeof(ButtonBehavior), typeof(ButtonEx), new PropertyMetadata(OnButtonBehaviorChanged));
		private static void OnButtonBehaviorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			ButtonBehavior bb = (ButtonBehavior)args.NewValue;
			ButtonEx btnex = (ButtonEx)obj;
			if ((bb & ButtonBehavior.NoBackground) != 0)
			{
				btnex.Background = null;
				btnex.BackgroundMouseOver = null!;
				btnex.BackgroundClick = null!;
				btnex.BackgroundDisabled = null!;
				btnex.BorderBrush = null;
				btnex.BorderThickness = new Thickness(0);
				btnex.CornerRadius = new CornerRadius(0);
				btnex.Padding = new Thickness(0);
			}
			if ((bb & ButtonBehavior.OpacityChanging) != 0)
			{
				btnex.OpacityDefault = 0.65d;
				btnex.OpacityMouseOver = 0.85d;
				btnex.OpacityClick = 1.0d;
			}
		}
		#endregion //Additional

		#region Opacity
		public double OpacityDefault
		{
			get { return (double)GetValue(OpacityDefaultProperty); }
			set { SetValue(OpacityDefaultProperty, value); }
		}
		public static readonly DependencyProperty OpacityDefaultProperty = DependencyProperty.Register("OpacityDefault", typeof(double), typeof(ButtonEx), new PropertyMetadata());

		public double OpacityMouseOver
		{
			get { return (double)GetValue(OpacityMouseOverProperty); }
			set { SetValue(OpacityMouseOverProperty, value); }
		}
		public static readonly DependencyProperty OpacityMouseOverProperty = DependencyProperty.Register("OpacityMouseOver", typeof(double), typeof(ButtonEx), new PropertyMetadata());

		public double OpacityClick
		{
			get { return (double)GetValue(OpacityClickProperty); }
			set { SetValue(OpacityClickProperty, value); }
		}
		public static readonly DependencyProperty OpacityClickProperty = DependencyProperty.Register("OpacityClick", typeof(double), typeof(ButtonEx), new PropertyMetadata());
		#endregion //Opacity
	}

	[Flags]
	public enum ButtonBehavior : byte
	{
		None = 0,
		NoBackground = 1,
		OpacityChanging = 2,
		ImageWithOpacity = NoBackground | OpacityChanging
	}
}
