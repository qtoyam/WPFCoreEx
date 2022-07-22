using System.Windows;
using System.Windows.Controls.Primitives;

using Microsoft.Win32;

namespace WPFCore.Behaviors
{
	public sealed class OpenFileBehavior : BehaviorBase<ButtonBase>
	{
		private Window _owner = null!;

		protected override void OnSetup()
		{
			_owner = Window.GetWindow(AssociatedObject);
			AssociatedObject.Click += ChooseFile;
		}

		protected override void OnCleanup()
		{
			AssociatedObject.Click -= ChooseFile;
		}

		private void ChooseFile(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new()
			{
				Filter = this.Filter
			};
			var res = ofd.ShowDialog(_owner);
			if (res == true)
			{
				PathTarget = ofd.FileName;
			}
		}

		public string PathTarget
		{
			get => (string)GetValue(PathTargetProperty);
			set => SetValue(PathTargetProperty, value);
		}
		public static readonly DependencyProperty PathTargetProperty =
			DependencyProperty.Register("PathTarget", typeof(string), typeof(OpenFileBehavior),
				new PropertyMetadata());

		public string Filter
		{
			get => (string)GetValue(FilterProperty);
			set => SetValue(FilterProperty, value);
		}
		public static readonly DependencyProperty FilterProperty =
			DependencyProperty.Register("Filter", typeof(string), typeof(OpenFileBehavior),
				new PropertyMetadata(defaultValue: string.Empty));
	}
}
