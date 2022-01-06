using System.Windows;
using System.Windows.Controls.Primitives;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public class MaximizeWindowBehavior : Behavior<ButtonBase>
	{
		private Window _window = null!;
		protected override void OnAttached()
		{
			_window = Window.GetWindow(AssociatedObject);
			AssociatedObject.Click += AssociatedObject_Click;
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			AssociatedObject.Click -= AssociatedObject_Click;
			_window = null!;
			base.OnDetaching();
		}

		private void AssociatedObject_Click(object sender, RoutedEventArgs e)
		{
			if (_window.WindowState == WindowState.Maximized)
			{
				_window.WindowState = WindowState.Normal;
			}
			else if (_window.WindowState == WindowState.Normal)
			{
				_window.WindowState = WindowState.Maximized;
			}
		}
	}
}
