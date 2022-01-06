using System.Windows;
using System.Windows.Controls.Primitives;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public sealed class UnselectBehavior : Behavior<UIElement>
	{
		protected override void OnAttached()
		{
			AssociatedObject.PreviewMouseLeftButtonUp += Unselect;
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			AssociatedObject.PreviewMouseLeftButtonUp -= Unselect;
			base.OnDetaching();
		}

		public Selector Selector
		{
			get => (Selector)GetValue(SelectorProperty);
			set => SetValue(SelectorProperty, value);
		}
		public static readonly DependencyProperty SelectorProperty =
			DependencyProperty.Register("Selector", typeof(Selector), typeof(UnselectBehavior),
				new PropertyMetadata(defaultValue: null));

		private void Unselect(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Selector.SetValue(Selector.SelectedIndexProperty, -1);
		}
	}
}
