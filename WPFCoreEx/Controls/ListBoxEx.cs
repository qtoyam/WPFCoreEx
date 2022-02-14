using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCoreEx.Controls
{
	public class ListBoxEx : ListBox
	{
		static ListBoxEx() => DefaultStyleKeyProperty.OverrideMetadata(typeof(ListBoxEx), new FrameworkPropertyMetadata(typeof(ListBoxEx)));

		public bool FocusSelectedItem
		{
			get => (bool)GetValue(FocusSelectedItemProperty);
			set => SetValue(FocusSelectedItemProperty, value);
		}
		public static readonly DependencyProperty FocusSelectedItemProperty =
			DependencyProperty.Register("FocusSelectedItem", typeof(bool), typeof(ListBoxEx),
				new PropertyMetadata(false, OnFocusSelectedItemChanged));
		private static void OnFocusSelectedItemChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			//TODO: iterating not optimazed, mb fix: trigger on IsSelected = false, FocusSelected = true => !enabled
			//if (args.OldValue == args.NewValue) return;
			//var lve = (ListBoxEx)obj;
			//var icg = lve.ItemContainerGenerator;
			//var enabled = !(bool)args.NewValue;
			//var focusedIndex = lve.SelectedIndex;
			//if (focusedIndex < 0) throw new InvalidOperationException("No selected item.");
			//int currentIndex;
			//for (currentIndex = 0; currentIndex < focusedIndex; currentIndex++)
			//{
			//	((ListBoxItem)icg.ContainerFromIndex(currentIndex)).IsEnabled = enabled;
			//}
			//// i = focused
			//((ListBoxItem)icg.ContainerFromIndex(currentIndex)).IsTabStop = enabled;
			//for (currentIndex++; currentIndex < icg.Items.Count; currentIndex++)
			//{
			//	((ListBoxItem)icg.ContainerFromIndex(currentIndex)).IsEnabled = enabled;
			//}
		}

		public Brush BackgroundDisabled
		{
			get => (Brush)GetValue(BackgroundDisabledProperty);
			set => SetValue(BackgroundDisabledProperty, value);
		}
		public static readonly DependencyProperty BackgroundDisabledProperty =
			DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(ListBoxEx),
				new PropertyMetadata());

		//protected override void OnKeyDown(KeyEventArgs e)
		//{
		//	bool handled = false;
		//	int newIndex;
		//	switch (e.Key)
		//	{
		//		case Key.Down:
		//			newIndex = SelectedIndex;
		//			if (newIndex != -1) // == selected
		//			{
		//				SelectedIndex = ++newIndex == Items.Count ? 0 : newIndex; //set 0 if was selected last index, otherwise +1 index
		//				handled = true;
		//			}
		//			break;
		//		case Key.Up:
		//			newIndex = SelectedIndex;
		//			if (newIndex != -1) // == selected
		//			{
		//				SelectedIndex = --newIndex == -1 ? Items.Count - 1 : newIndex; //set last index if was selected first, otherwise -1 index
		//				handled = true;
		//			}
		//			break;
		//	}
		//	Debug.WriteLine($"Handled: {handled}");
		//	e.Handled = handled;
		//}
	}
}
