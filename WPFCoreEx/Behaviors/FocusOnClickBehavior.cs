using System.Windows;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public class FocusOnClickBehavior : Behavior<UIElement>
	{
		protected override void OnAttached()
		{
			AssociatedObject.PreviewMouseLeftButtonUp += Click;
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			AssociatedObject.PreviewMouseLeftButtonUp -= Click;
			base.OnDetaching();
		}

		private void Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			AssociatedObject.Focus();
		}
	}
}
