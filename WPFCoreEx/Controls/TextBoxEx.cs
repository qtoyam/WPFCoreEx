using System.Windows;
using System.Windows.Controls;

namespace WPFCoreEx.Controls
{
	public class TextBoxEx : TextBox
	{
		static TextBoxEx()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxEx), new FrameworkPropertyMetadata(typeof(TextBoxEx)));
		}

		#region Hint Text
		public string HintText
		{
			get { return (string)GetValue(HintTextProperty); }
			set { SetValue(HintTextProperty, value); }
		}
		public static readonly DependencyProperty HintTextProperty =
			DependencyProperty.Register("HintText", typeof(string), typeof(TextBoxEx), new PropertyMetadata(string.Empty));




		public Visibility HintTextVisibility
		{
			get { return (Visibility)GetValue(HintTextVisibilityProperty); }
			set { SetValue(HintTextVisibilityProperty, value); }
		}
		internal static readonly DependencyProperty HintTextVisibilityProperty =
			DependencyProperty.Register("HintTextVisibility", typeof(Visibility), typeof(TextBoxEx), new PropertyMetadata(Visibility.Visible));

		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			HintTextVisibility = string.IsNullOrEmpty(this.Text) ? Visibility.Visible : Visibility.Hidden;
			base.OnTextChanged(e);
		}
		#endregion //Hint

		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TextBoxEx), new PropertyMetadata());
	}
}
