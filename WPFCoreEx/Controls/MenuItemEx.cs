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

		#region Backgrounds
		public Brush BackgroundPopup
		{
			get { return (Brush)GetValue(BackgroundPopupProperty); }
			set { SetValue(BackgroundPopupProperty, value); }
		}
		public static readonly DependencyProperty BackgroundPopupProperty =
			DependencyProperty.Register("BackgroundPopup", typeof(Brush), typeof(MenuItemEx), new PropertyMetadata(SystemColors.MenuBrush));

		public Brush BackgroundHighlighted
		{
			get { return (Brush)GetValue(BackgroundHighlightedProperty); }
			set { SetValue(BackgroundHighlightedProperty, value); }
		}
		public static readonly DependencyProperty BackgroundHighlightedProperty =
			DependencyProperty.Register("BackgroundHighlighted", typeof(Brush), typeof(MenuItemEx), new PropertyMetadata(SystemColors.MenuHighlightBrush));

		public Brush BackgroundHighlightedBorder
		{
			get { return (Brush)GetValue(BackgroundHighlightedBorderProperty); }
			set { SetValue(BackgroundHighlightedBorderProperty, value); }
		}
		public static readonly DependencyProperty BackgroundHighlightedBorderProperty =
			DependencyProperty.Register("BackgroundHighlightedBorder", typeof(Brush), typeof(MenuItemEx), new PropertyMetadata(null));
		#endregion //Backgrounds

		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MenuItemEx), new PropertyMetadata());
	}
}
