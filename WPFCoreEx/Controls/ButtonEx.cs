﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCoreEx.Controls
{
	public class ButtonEx : Button
	{
		static ButtonEx() => DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonEx),
			new FrameworkPropertyMetadata(typeof(ButtonEx)));

		#region Backgrounds
		public Brush BackgroundMouseOver
		{
			get => (Brush)GetValue(BackgroundMouseOverProperty);
			set => SetValue(BackgroundMouseOverProperty, value);
		}
		public static readonly DependencyProperty BackgroundMouseOverProperty =
			DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(ButtonEx),
				new PropertyMetadata());

		public Brush BackgroundClick
		{
			get => (Brush)GetValue(BackgroundClickProperty);
			set => SetValue(BackgroundClickProperty, value);
		}
		public static readonly DependencyProperty BackgroundClickProperty =
			DependencyProperty.Register("BackgroundClick", typeof(Brush), typeof(ButtonEx),
				new PropertyMetadata());


		public Brush BackgroundDisabled
		{
			get => (Brush)GetValue(BackgroundDisabledProperty);
			set => SetValue(BackgroundDisabledProperty, value);
		}
		public static readonly DependencyProperty BackgroundDisabledProperty =
			DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(ButtonEx),
				new PropertyMetadata());
		#endregion //Backgrounds

		#region Opacity

		public double OpacityDefault
		{
			get => (double)GetValue(OpacityDefaultProperty);
			set => SetValue(OpacityDefaultProperty, value);
		}
		public static readonly DependencyProperty OpacityDefaultProperty =
			DependencyProperty.Register("OpacityDefault", typeof(double), typeof(ButtonEx),
				new PropertyMetadata());

		public double OpacityMouseOver
		{
			get => (double)GetValue(OpacityMouseOverProperty);
			set => SetValue(OpacityMouseOverProperty, value);
		}
		public static readonly DependencyProperty OpacityMouseOverProperty =
			DependencyProperty.Register("OpacityMouseOver", typeof(double), typeof(ButtonEx),
				new PropertyMetadata());

		public double OpacityClick
		{
			get => (double)GetValue(OpacityClickProperty);
			set => SetValue(OpacityClickProperty, value);
		}
		public static readonly DependencyProperty OpacityClickProperty =
			DependencyProperty.Register("OpacityClick", typeof(double), typeof(ButtonEx),
				new PropertyMetadata());

		#endregion //Opacity

		#region Additional
		public CornerRadius CornerRadius
		{
			get => (CornerRadius)GetValue(CornerRadiusProperty);
			set => SetValue(CornerRadiusProperty, value);
		}
		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ButtonEx),
				new PropertyMetadata());
		#endregion //Additional

		#region Helpers
		public bool OpacityChanging
		{
			get => (bool)GetValue(OpacityChangingProperty);
			set => SetValue(OpacityChangingProperty, value);
		}
		public static readonly DependencyProperty OpacityChangingProperty =
			DependencyProperty.Register("OpacityChanging", typeof(bool), typeof(ButtonEx),
				new PropertyMetadata(OnOpacityChangingChanged));
		private static void OnOpacityChangingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			if (obj is ButtonEx be)
			{
				if (args.NewValue is true)
				{
					be.OpacityDefault = 0.65d;
					be.OpacityMouseOver = 0.85d;
					be.OpacityClick = 1.0d;
				}
				else
				{
					be.OpacityDefault = 1;
					be.OpacityMouseOver = 1;
					be.OpacityClick = 1;
				}
			}
		}

		public bool NoBackground
		{
			get => (bool)GetValue(NoBackgroundProperty);
			set => SetValue(NoBackgroundProperty, value);
		}
		public static readonly DependencyProperty NoBackgroundProperty =
			DependencyProperty.Register("NoBackground", typeof(bool), typeof(ButtonEx),
				new PropertyMetadata(OnNoBackgroundChanged));
		private static void OnNoBackgroundChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			if (obj is ButtonEx be)
			{
				if (args.NewValue is true)
				{
					be.Background = Brushes.Transparent;
					be.BackgroundMouseOver = Brushes.Transparent;
					be.BackgroundClick = Brushes.Transparent;
					be.BackgroundDisabled = Brushes.Transparent;
					be.BorderBrush = null;
					be.BorderThickness = new(0);
				}
				else
				{
					throw new InvalidOperationException("Only true is valid, false do nothing");
				}
			}
		}

		public ImageSource ImgSource
		{
			set
			{
				this.Content = new Image() { Source = value };
			}
		}
		#endregion //Helpers
	}
}
