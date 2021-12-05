using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFCoreEx.Behaviors
{
	public sealed class ShutdownAppBehavior : Behavior<Control>
	{
		public int ShutdownCode
		{
			get { return (int)GetValue(ShutdownCodeProperty); }
			set { SetValue(ShutdownCodeProperty, value); }
		}
		public static readonly DependencyProperty ShutdownCodeProperty =
			DependencyProperty.Register("ShutdownCode", typeof(int), typeof(ShutdownAppBehavior), new PropertyMetadata(0));

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
			Application.Current.Shutdown(ShutdownCode);
		}
	}
}
