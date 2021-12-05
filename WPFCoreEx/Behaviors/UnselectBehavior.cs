using System.Windows;
using System.Windows.Controls.Primitives;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public sealed class UnselectBehavior : Behavior<UIElement>
	{
		public Selector Selector
		{
			get => (Selector)GetValue(SelectorProperty);
			set => SetValue(SelectorProperty, value);
		}
		public static readonly DependencyProperty SelectorProperty =
			DependencyProperty.Register("Selector", typeof(Selector), typeof(UnselectBehavior), new PropertyMetadata(null));





		protected override void OnAttached()
		{
			AssociatedObject.MouseLeftButtonDown += Unselect;
			base.OnAttached();
		}

		private void Unselect(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Selector.SetValue(System.Windows.Controls.Primitives.Selector.SelectedIndexProperty, -1);
		}

		protected override void OnDetaching()
		{
			AssociatedObject.MouseLeftButtonUp -= Unselect;
			base.OnDetaching();
		}
	}
}
