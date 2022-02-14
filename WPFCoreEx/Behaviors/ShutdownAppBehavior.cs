using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFCoreEx.Behaviors
{
	public sealed class ShutdownAppBehavior : BehaviorBase<Control>
	{
		protected override void OnSetup()
		{
			switch (AssociatedObject)
			{
				case ButtonBase bb:
					bb.Click += AssociatedObject_Click;
					break;
				case MenuItem mi:
					mi.Click += AssociatedObject_Click;
					break;
				default:
					throw new ArgumentException("Only buttonbase or menuitem is available for this behavior", AssociatedObject.Name);
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
					throw new InvalidOperationException($"{nameof(AssociatedObject)} wrong type");
			}
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
