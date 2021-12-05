using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace WPFCoreEx.Behaviors
{
	public class MinimizeAppBehavior : Behavior<ButtonBase>
	{
		private Window parent = null!;
		protected override void OnAttached()
		{
			parent = Window.GetWindow(AssociatedObject);
			AssociatedObject.Click += AssociatedObject_Click;
		}
		protected override void OnDetaching()
		{
			AssociatedObject.Click -= AssociatedObject_Click;
			parent = null!;
		}

		private void AssociatedObject_Click(object sender, RoutedEventArgs e)
		{
			parent.WindowState = WindowState.Minimized;
		}
	}
}
