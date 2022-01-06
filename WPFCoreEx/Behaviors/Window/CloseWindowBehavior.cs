using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public class CloseWindowBehavior : Behavior<Control>
	{
		private Window _window = null!;
		protected override void OnAttached()
		{
			_window = Window.GetWindow(AssociatedObject);
			if (AssociatedObject is ButtonBase bb)
				bb.Click += AssociatedObject_Click;
			else if (AssociatedObject is MenuItem mi)
				mi.Click += AssociatedObject_Click;
			else throw new ArgumentException($"Only {nameof(ButtonBase)} or {nameof(MenuItem)} is available for this behavior", AssociatedObject.ToString());
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			if (AssociatedObject is ButtonBase bb)
				bb.Click -= AssociatedObject_Click;
			else if (AssociatedObject is MenuItem mi)
				mi.Click -= AssociatedObject_Click;
			_window = null!;
			base.OnDetaching();
		}

		private void AssociatedObject_Click(object sender, RoutedEventArgs e)
		{
			_window.Close();
		}
	}
}
