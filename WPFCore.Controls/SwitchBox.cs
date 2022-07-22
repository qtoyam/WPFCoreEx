using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WPFCore.Controls
{
	public sealed class SwitchBox : CheckBox
	{
		private static Duration GetAnimationDuration() => new(TimeSpan.FromMilliseconds(300));
		private static readonly DoubleAnimation _borderAnimOff;
		static SwitchBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchBox),
				 new FrameworkPropertyMetadata(typeof(SwitchBox)));
			_borderAnimOff = new(0, GetAnimationDuration());
			_borderAnimOff.Freeze();
		}

		private Border? _border = null!;
		private Border? _mainBorder = null!;

		private DoubleAnimation? _borderAnimOn;

		private double CalculateNewX() => _border!.Width - (_mainBorder!.BorderThickness.Right * 2);
		private void SetStaticPropsOn()
		{
			_border!.Background = SwitchBackgroundOn;
			CurrentStatus = StatusOn;
		}
		private void SetStaticPropsOff()
		{
			_border!.Background = SwitchBackgroundOff;
			CurrentStatus = StatusOff;
		}

		private void OnWidthUpdated()
		{
			_mainBorder!.Width = _mainBorder.ActualWidth;
			_border!.Width = _mainBorder!.ActualWidth / 2;
			_borderAnimOn = new(CalculateNewX(), GetAnimationDuration());
			_borderAnimOn.Freeze();
		}

		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			base.OnRenderSizeChanged(sizeInfo);
			if (_border == null)
			{
				_border = (Border?)Template.FindName("PART_movableBorder", this)!;
				_mainBorder = (Border?)Template.FindName("PART_staticBorder", this)!;
				OnWidthUpdated();
				if (IsChecked == true)
				{
					_border.RenderTransform = new TranslateTransform(CalculateNewX(), 0);
					SetStaticPropsOn();
				}
				else
				{
					_border.RenderTransform = new TranslateTransform(0, 0);
					SetStaticPropsOff();
				}
			}
			else if (sizeInfo.WidthChanged)
			{
				OnWidthUpdated();
			}
		}

		protected override void OnChecked(RoutedEventArgs e)
		{
			base.OnChecked(e);
			if (_border != null)
			{
				_border.RenderTransform.BeginAnimation(TranslateTransform.XProperty, _borderAnimOn, HandoffBehavior.SnapshotAndReplace);
				SetStaticPropsOn();
			}
		}
		protected override void OnUnchecked(RoutedEventArgs e)
		{
			base.OnUnchecked(e);
			if (_border != null)
			{
				_border.RenderTransform.BeginAnimation(TranslateTransform.XProperty, _borderAnimOff, HandoffBehavior.SnapshotAndReplace);
				SetStaticPropsOff();
			}
		}

		#region SwitchBackgroundProps
		public Brush SwitchBackground
		{
			get => (Brush)GetValue(SwitchBackgroundProperty);
			private set => SetValue(SwitchBackgroundProperty, value);
		}
		public static readonly DependencyProperty SwitchBackgroundProperty =
			DependencyProperty.Register(nameof(SwitchBackground), typeof(Brush), typeof(SwitchBox),
				new PropertyMetadata(defaultValue: null));
		public Brush SwitchBackgroundOff
		{
			get => (Brush)GetValue(SwitchBackgroundOffProperty);
			set => SetValue(SwitchBackgroundOffProperty, value);
		}
		public static readonly DependencyProperty SwitchBackgroundOffProperty =
			DependencyProperty.Register(nameof(SwitchBackgroundOff), typeof(Brush), typeof(SwitchBox),
				new PropertyMetadata(defaultValue: null));
		public Brush SwitchBackgroundOn
		{
			get => (Brush)GetValue(SwitchBackgroundOnProperty);
			set => SetValue(SwitchBackgroundOnProperty, value);
		}
		public static readonly DependencyProperty SwitchBackgroundOnProperty =
			DependencyProperty.Register(nameof(SwitchBackgroundOn), typeof(Brush), typeof(SwitchBox),
				new PropertyMetadata(defaultValue: null));
		#endregion //SwitchBackgroundProps

		#region StatusProps
		public object CurrentStatus
		{
			get => GetValue(CurrentStatusProperty);
			private set => SetValue(CurrentStatusProperty, value);
		}
		public static readonly DependencyProperty CurrentStatusProperty =
			DependencyProperty.Register(nameof(CurrentStatus), typeof(object), typeof(SwitchBox),
				new PropertyMetadata(defaultValue: null));
		public object StatusOff
		{
			get => GetValue(StatusOffProperty);
			set => SetValue(StatusOffProperty, value);
		}
		public static readonly DependencyProperty StatusOffProperty =
			DependencyProperty.Register(nameof(StatusOff), typeof(object), typeof(SwitchBox),
				new PropertyMetadata(defaultValue: null));
		public object StatusOn
		{
			get => GetValue(StatusOnProperty);
			set => SetValue(StatusOnProperty, value);
		}
		public static readonly DependencyProperty StatusOnProperty =
			DependencyProperty.Register(nameof(StatusOn), typeof(object), typeof(SwitchBox),
				new PropertyMetadata(defaultValue: null));
		#endregion //StatusProps
	}
}
