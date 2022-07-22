using System.Windows;
using System.Windows.Controls.Primitives;

namespace WPFCore.Behaviors
{
	public sealed class UnselectBehavior : BehaviorBase<FrameworkElement>
	{
		protected override void OnSetup()
		{
			AssociatedObject.PreviewMouseLeftButtonUp += Unselect;
		}
		protected override void OnCleanup()
		{
			AssociatedObject.PreviewMouseLeftButtonUp -= Unselect;
		}

		public Selector Selector
		{
			get => (Selector)GetValue(SelectorProperty);
			set => SetValue(SelectorProperty, value);
		}
		public static readonly DependencyProperty SelectorProperty =
			DependencyProperty.Register("Selector", typeof(Selector), typeof(UnselectBehavior),
				new PropertyMetadata(defaultValue: null));

		private void Unselect(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Selector.SetValue(Selector.SelectedIndexProperty, -1);
		}
	}
}
