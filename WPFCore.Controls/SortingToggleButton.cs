using System.Windows;
using System.Windows.Controls.Primitives;

namespace WPFCore.Controls
{
	public class SortingToggleButton : ToggleButton
	{
		static SortingToggleButton() => DefaultStyleKeyProperty.OverrideMetadata(typeof(SortingToggleButton),
				   new FrameworkPropertyMetadata(typeof(SortingToggleButton)));
	}
}
