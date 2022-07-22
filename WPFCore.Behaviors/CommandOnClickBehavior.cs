using System.Windows;
using System.Windows.Input;

namespace WPFCore.Behaviors
{
	public sealed class CommandOnClickBehavior : BehaviorBase<FrameworkElement>
	{
		protected override void OnSetup()
		{
			AssociatedObject.MouseLeftButtonDown += OnClick;
		}
		protected override void OnCleanup()
		{
			AssociatedObject.MouseLeftButtonDown -= OnClick;
		}

		public ICommand Command
		{
			get => (ICommand)GetValue(CommandProperty);
			set => SetValue(CommandProperty, value);
		}
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandOnClickBehavior),
			new PropertyMetadata(defaultValue: null));

		/// <summary>
		/// Value set to <see cref="RoutedEventArgs.Handled"/>. Default is <see langword="true"/>.
		/// </summary>
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
