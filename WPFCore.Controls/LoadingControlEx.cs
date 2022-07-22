using System.Windows;
using System.Windows.Controls;

namespace WPFCore.Controls
{
	public class LoadingControlEx : Control
	{
		static LoadingControlEx() =>
			DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingControlEx),
				new FrameworkPropertyMetadata(typeof(LoadingControlEx)));
	}
}
