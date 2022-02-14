using System.Windows.Controls.Primitives;

namespace WPFCoreEx.Behaviors
{
	public sealed class SelectAllTextOnFocusBehavior : BehaviorBase<TextBoxBase>
	{
		protected override void OnSetup()
		{
			AssociatedObject.PreviewGotKeyboardFocus += GotKeyboardFocus;
			AssociatedObject.PreviewMouseLeftButtonDown += MouseLBClick;
		}
		protected override void OnCleanup()
		{
			AssociatedObject.PreviewGotKeyboardFocus -= GotKeyboardFocus;
			AssociatedObject.PreviewMouseLeftButtonDown -= MouseLBClick;
		}

		private static void MouseLBClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var tb = (TextBoxBase)sender;
			if (!tb.IsKeyboardFocused)
			{
				tb.Focus();
				e.Handled = true;
			}
		}

		private static void GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			((TextBoxBase)sender).SelectAll();
		}
	}
}
