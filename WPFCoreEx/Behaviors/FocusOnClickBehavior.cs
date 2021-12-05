using System.Windows;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public class FocusOnClickBehavior : Behavior<UIElement>
	{
		protected override void OnAttached() => AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;

		private void AssociatedObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) => AssociatedObject.Focus();

		protected override void OnDetaching() => AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
	}
}
