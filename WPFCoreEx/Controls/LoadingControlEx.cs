using System.Windows;
using System.Windows.Controls;

namespace WPFCoreEx.Controls
{
	public class LoadingControlEx : Control
	{
		static LoadingControlEx() =>
			DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingControlEx),
				new FrameworkPropertyMetadata(typeof(LoadingControlEx)));
	}
}
