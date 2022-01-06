using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCoreEx.Controls
{
    public class ListViewEx : ListView
    {
		static ListViewEx() => DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewEx), new FrameworkPropertyMetadata(typeof(ListViewEx)));



		public bool FocusSelectedItem
		{
			get => (bool)GetValue(FocusSelectedItemProperty);
			set => SetValue(FocusSelectedItemProperty, value);
		}
		public static readonly DependencyProperty FocusSelectedItemProperty =
			DependencyProperty.Register("FocusSelectedItem", typeof(bool), typeof(ListViewEx),
				new PropertyMetadata(OnFocusSelectedItemChanged));
		private static void OnFocusSelectedItemChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{ 
			//TODO: iterating not optimazed
			if(obj is ListViewEx lve)
			{
				if(args.NewValue is true)
				{
					var icg = lve.ItemContainerGenerator;
					for (int i = 0; i < icg.Items.Count; i++)
					{
						((ListViewItem)icg.ContainerFromIndex(i)).IsEnabled = false;
					}
					if(lve.SelectedIndex != -1)
					{
						((ListViewItem)icg.ContainerFromIndex(lve.SelectedIndex)).IsEnabled = true;
					}
				}
				else
				{
					var icg = lve.ItemContainerGenerator;
					for (int i = 0; i < icg.Items.Count; i++)
					{
						((ListViewItem)icg.ContainerFromIndex(i)).IsEnabled = true;
					}
				}
			}
		}




		public Brush BackgroundDisabled
		{
			get => (Brush)GetValue(BackgroundDisabledProperty);
			set => SetValue(BackgroundDisabledProperty, value);
		}
		public static readonly DependencyProperty BackgroundDisabledProperty =
			DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(ListViewEx),
				new PropertyMetadata());


	}
}
