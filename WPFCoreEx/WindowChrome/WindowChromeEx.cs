using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCoreEx.WindowChrome
{
	//TODO: remove useless content such as stackpanel if user defines custom content, set modes on bindings (mb one time)
	public class WindowChromeEx
	{


		[AttachedPropertyBrowsableForType(typeof(Window))]
		public static ImageSource GetTitleImage(DependencyObject obj) => (ImageSource)obj.GetValue(TitleImageProperty);
		public static void SetTitleImage(DependencyObject obj, ImageSource value) => obj.SetValue(TitleImageProperty, value);
		public static readonly DependencyProperty TitleImageProperty =
			DependencyProperty.RegisterAttached("TitleImage", typeof(ImageSource), typeof(WindowChromeEx),
				new PropertyMetadata(null));


		[AttachedPropertyBrowsableForType(typeof(Window))]
		public static string GetTitleText(DependencyObject obj) => (string)obj.GetValue(TitleTextProperty);
		public static void SetTitleText(DependencyObject obj, string value) => obj.SetValue(TitleTextProperty, value);
		public static readonly DependencyProperty TitleTextProperty =
			DependencyProperty.RegisterAttached("TitleText", typeof(string), typeof(WindowChromeEx),
				new PropertyMetadata(null));

		[AttachedPropertyBrowsableForType(typeof(Window))]
		public static Brush GetForeground(DependencyObject obj) => (Brush)obj.GetValue(ForegroundProperty);
		public static void SetForeground(DependencyObject obj, Brush value) => obj.SetValue(ForegroundProperty, value);
		public static readonly DependencyProperty ForegroundProperty =
			DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(WindowChromeEx),
				new PropertyMetadata(Brushes.Gray));


		[AttachedPropertyBrowsableForType(typeof(Window))]
		public static object GetContent(DependencyObject obj) => obj.GetValue(ContentProperty);
		public static void SetContent(DependencyObject obj, object value) => obj.SetValue(ContentProperty, value);
		public static readonly DependencyProperty ContentProperty =
			DependencyProperty.RegisterAttached("Content", typeof(object), typeof(WindowChromeEx),
				new PropertyMetadata(null));



	}
}
