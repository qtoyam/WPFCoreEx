using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPFCore.Behaviors
{
	public sealed class FocusOnReadonlyChanged : BehaviorBase<TextBoxBase>
	{
		protected override void OnSetup()
		{
			DependencyPropertyDescriptor.FromProperty(TextBoxBase.IsReadOnlyProperty, typeof(TextBoxBase))
				.AddValueChanged(AssociatedObject, OnIsReadonlyChanged);

			if (!AssociatedObject.IsReadOnly) //first init-check
			{
				AssociatedObject.Focus();
			}
		}
		protected override void OnCleanup()
		{
			DependencyPropertyDescriptor.FromProperty(TextBoxBase.IsReadOnlyProperty, typeof(TextBoxBase))
				.RemoveValueChanged(AssociatedObject, OnIsReadonlyChanged);
		}

		private static void OnIsReadonlyChanged(object? sender, EventArgs e)
		{
			var s = (TextBoxBase)sender!;
			if (!s.IsReadOnly)
			{
				Keyboard.Focus(s);
			}
		}
	}
}
