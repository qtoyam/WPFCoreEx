using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPFCore.Behaviors
{
	public sealed class UnfocusOnReadonlyChanged : BehaviorBase<TextBoxBase>
	{
		protected override void OnSetup()
		{
			DependencyPropertyDescriptor.FromProperty(TextBoxBase.IsReadOnlyProperty, typeof(TextBoxBase))
				.AddValueChanged(AssociatedObject, OnIsReadonlyChanged);

			OnIsReadonlyChanged(AssociatedObject, EventArgs.Empty);
		}
		protected override void OnCleanup()
		{
			DependencyPropertyDescriptor.FromProperty(TextBoxBase.IsReadOnlyProperty, typeof(TextBoxBase))
				.RemoveValueChanged(AssociatedObject, OnIsReadonlyChanged);
		}

		public FocusNavigationDirection MoveFocusDirection
		{
			get => (FocusNavigationDirection)GetValue(MoveFocusDirectionProperty);
			set => SetValue(MoveFocusDirectionProperty, value);
		}
		public static readonly DependencyProperty MoveFocusDirectionProperty =
			DependencyProperty.Register("MoveFocusDirection", typeof(FocusNavigationDirection), typeof(UnfocusOnReadonlyChanged),
				new PropertyMetadata(defaultValue: FocusNavigationDirection.Next));

		private void OnIsReadonlyChanged(object? sender, EventArgs e)
		{
			var s = (TextBoxBase)sender!;
			if (s.IsReadOnly && s.IsKeyboardFocused)
			{
				s.MoveFocus(new(MoveFocusDirection));
			}
		}
	}
}
