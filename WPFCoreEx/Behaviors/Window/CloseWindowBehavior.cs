using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFCoreEx.Behaviors
{
	public class CloseWindowBehavior : BehaviorBase<Control>
	{
		private Window _window = null!;
		protected override void OnSetup()
		{
			_window = Window.GetWindow(AssociatedObject);
			if (AssociatedObject is ButtonBase bb)
			{
				bb.Click += AssociatedObject_Click;
			}
			else if (AssociatedObject is MenuItem mi)
			{
				mi.Click += AssociatedObject_Click;
			}
			else
			{
				throw new ArgumentException($"Only {nameof(ButtonBase)} or {nameof(MenuItem)} is available for this behavior", AssociatedObject.ToString());
			}
		}
		protected override void OnCleanup()
		{
			switch (AssociatedObject)
			{
				case ButtonBase bb:
					bb.Click -= AssociatedObject_Click;
					break;
				case MenuItem mi:
					mi.Click -= AssociatedObject_Click;
					break;
				default:
					throw new ArgumentException($"Only {nameof(ButtonBase)} or {nameof(MenuItem)} is available for this behavior", AssociatedObject.ToString());
			}
		}

		private void AssociatedObject_Click(object sender, RoutedEventArgs e)
		{
			_window.Close();
		}
	}
}
