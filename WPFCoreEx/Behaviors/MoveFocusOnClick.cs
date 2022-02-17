using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPFCoreEx.Behaviors
{
	public class MoveFocusOnClick : BehaviorBase<ButtonBase>
	{
		protected override void OnSetup()
		{
			AssociatedObject.Click += OnClick;
		}

		protected override void OnCleanup()
		{
			AssociatedObject.Click -= OnClick;
		}

		private void OnClick(object sender, System.Windows.RoutedEventArgs e)
		{
			var s = (ButtonBase)sender;
			s.MoveFocus(_traversalRequest);
		}

		public FocusNavigationDirection Direction
		{
			set
			{
				_traversalRequest = new(value);
			}
		}

		private TraversalRequest _traversalRequest = new(FocusNavigationDirection.Next);
	}
}
