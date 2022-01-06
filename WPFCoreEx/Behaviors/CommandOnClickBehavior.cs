using System.Windows;
using System.Windows.Input;

using Microsoft.Xaml.Behaviors;

namespace WPFCoreEx.Behaviors
{
	public sealed class CommandOnClickBehavior : Behavior<UIElement>
	{
		protected override void OnAttached()
		{
			AssociatedObject.MouseLeftButtonDown += OnClick;
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			AssociatedObject.MouseLeftButtonDown -= OnClick;
			base.OnDetaching();
		}

		public ICommand Command
		{
			get => (ICommand)GetValue(CommandProperty);
			set => SetValue(CommandProperty, value);
		}
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandOnClickBehavior),
			new PropertyMetadata(defaultValue: null));

		public bool ClickHandled
		{
			get => (bool)GetValue(ClickHandledProperty);
			set => SetValue(ClickHandledProperty, value);
		}
		public static readonly DependencyProperty ClickHandledProperty = DependencyProperty.Register("ClickHandled", typeof(bool), typeof(CommandOnClickBehavior),
			new PropertyMetadata(true));

		private void OnClick(object sender, MouseButtonEventArgs e)
		{
			if (Command.CanExecute(null))
			{
				Command.Execute(null);
			}
			e.Handled = ClickHandled;
		}
	}
}
