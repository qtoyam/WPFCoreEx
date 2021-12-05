using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFCoreEx.Behaviors
{
	public class CloseWindowBehavior : Behavior<Control>
	{
		protected override void OnAttached()
		{
			if (AssociatedObject is ButtonBase bb)
				bb.Click += AssociatedObject_Click;
			else if (AssociatedObject is MenuItem mi)
				mi.Click += AssociatedObject_Click;
			else throw new ArgumentException("Only buttonbase or menuitem is available for this behavior", AssociatedObject.Name);
		}
		protected override void OnDetaching()
		{
			if (AssociatedObject is ButtonBase bb)
				bb.Click -= AssociatedObject_Click;
			else if (AssociatedObject is MenuItem mi)
				mi.Click -= AssociatedObject_Click;
		}

		private void AssociatedObject_Click(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(AssociatedObject).Close();
		}
	}
}
