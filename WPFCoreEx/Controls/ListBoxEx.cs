using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCoreEx.Controls
{
	public class ListBoxEx : ListBox
	{
		static ListBoxEx() => DefaultStyleKeyProperty.OverrideMetadata(typeof(ListBoxEx), new FrameworkPropertyMetadata(typeof(ListBoxEx)));

		public bool FocusSelectedItem
		{
			get => (bool)GetValue(FocusSelectedItemProperty);
			set => SetValue(FocusSelectedItemProperty, value);
		}
		public static readonly DependencyProperty FocusSelectedItemProperty =
			DependencyProperty.Register("FocusSelectedItem", typeof(bool), typeof(ListBoxEx),
				new PropertyMetadata(defaultValue: false));

		public Brush BackgroundDisabled
		{
			get => (Brush)GetValue(BackgroundDisabledProperty);
			set => SetValue(BackgroundDisabledProperty, value);
		}
		public static readonly DependencyProperty BackgroundDisabledProperty =
			DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(ListBoxEx),
				new PropertyMetadata());
	}
}
