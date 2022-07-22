using System.Windows;

namespace WPFCore.Behaviors
{
	public class FocusOnClickBehavior : BehaviorBase<FrameworkElement>
	{
		protected override void OnSetup()
		{
			AssociatedObject.PreviewMouseLeftButtonUp += Click;
		}
		protected override void OnCleanup()
		{
			AssociatedObject.PreviewMouseLeftButtonUp -= Click;
		}

		private static void Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var s = (FrameworkElement)sender;
			s.Focus();
		}
	}
}
