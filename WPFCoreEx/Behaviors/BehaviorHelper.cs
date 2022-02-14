using System.Windows;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public static class BehaviorHelper
	{
		public static Behavior GetAttachedBehavior(DependencyObject obj) => (Behavior)obj.GetValue(AttachedBehaviorProperty);
		public static void SetAttachedBehavior(DependencyObject obj, Behavior value) => obj.SetValue(AttachedBehaviorProperty, value);
		public static readonly DependencyProperty AttachedBehaviorProperty =
			DependencyProperty.RegisterAttached("AttachedBehavior", typeof(Behavior), typeof(BehaviorHelper),
				new PropertyMetadata(defaultValue: null, OnAttachedBehaviorChanged));

		public static void OnAttachedBehaviorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var unfrozenCopy = (Behavior)((Freezable)e.NewValue).Clone(); //get as unfrozen
			Interaction.GetBehaviors(d).Add(unfrozenCopy);
		}
	}
}
