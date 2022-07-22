using System.Windows;
using System.Windows.Controls.Primitives;

namespace WPFCore.Behaviors
{
	public class MinimizeWindowBehavior : BehaviorBase<ButtonBase>
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
			_window.WindowState = WindowState.Minimized;
		}
	}
}
