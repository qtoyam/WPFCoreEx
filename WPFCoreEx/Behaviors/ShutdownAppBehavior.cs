using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public sealed class ShutdownAppBehavior : Behavior<Control>
	{
		protected override void OnAttached()
		{
			if (AssociatedObject is ButtonBase bb)
				bb.Click += AssociatedObject_Click;
			else if (AssociatedObject is MenuItem mi)
				mi.Click += AssociatedObject_Click;
			else throw new ArgumentException("Only buttonbase or menuitem is available for this behavior", AssociatedObject.Name);
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			if (AssociatedObject is ButtonBase bb)
				bb.Click -= AssociatedObject_Click;
			else if (AssociatedObject is MenuItem mi)
				mi.Click -= AssociatedObject_Click;
			base.OnDetaching();
		}

		public int ShutdownCode
		{
			get => (int)GetValue(ShutdownCodeProperty);
			set => SetValue(ShutdownCodeProperty, value);
		}
		public static readonly DependencyProperty ShutdownCodeProperty =
			DependencyProperty.Register("ShutdownCode", typeof(int), typeof(ShutdownAppBehavior),
				new PropertyMetadata(0));

		private void AssociatedObject_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown(ShutdownCode);
		}
	}
}
