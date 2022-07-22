using System.Windows;
using System.Windows.Controls.Primitives;

namespace WPFCore.Behaviors
{
	public class MaximizeWindowBehavior : BehaviorBase<ButtonBase>
	{
		private Window _window = null!;
		protected override void OnSetup()
		{
			_window = Window.GetWindow(AssociatedObject);
			AssociatedObject.Click += AssociatedObject_Click;
		}
		protected override void OnCleanup()
		{
			AssociatedObject.Click -= AssociatedObject_Click;
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
