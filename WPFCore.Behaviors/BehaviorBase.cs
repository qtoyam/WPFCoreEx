using System;
using System.Windows;

using Microsoft.Xaml.Behaviors;

namespace WPFCore.Behaviors
{
	public abstract class BehaviorBase<T> : Behavior<T>
		where T : FrameworkElement
	{
		private bool _disposed = false;

		protected abstract void OnSetup();
		protected virtual void OnCleanup() { }

		[Obsolete($"Use {nameof(OnSetup)} instead.")]
		protected override void OnAttached() => Setup();
		[Obsolete($"Use {nameof(OnCleanup)} instead.")]
		protected override void OnDetaching() => Cleanup(false);

		private void Setup()
		{
			AssociatedObject.Unloaded += AssociatedObject_Unloaded;
			OnSetup();
		}
		private void Cleanup(bool shouldDetach)
		{
			if (!_disposed)
			{
				_disposed = true;
				AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
				OnCleanup();
				if(shouldDetach) Detach();
			}
		}

		private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
		{
			Cleanup(true);
		}
	}
}
