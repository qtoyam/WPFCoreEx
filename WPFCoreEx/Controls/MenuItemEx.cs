using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCoreEx.Controls
{
	public sealed class MenuItemEx : MenuItem
	{
		static MenuItemEx()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuItemEx), new FrameworkPropertyMetadata(typeof(MenuItemEx)));
		}

		public Brush BackgroundMouseOver
		{
			get => (Brush)GetValue(BackgroundMouseOverProperty);
			set => SetValue(BackgroundMouseOverProperty, value);
		}
		public static readonly DependencyProperty BackgroundMouseOverProperty =
			DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(MenuItemEx),
				new PropertyMetadata());
	}
}
