using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFCoreEx
{
	//idk trash
	
	//public sealed class Appearance
	//{
	//	#region CornerRadius
	//	//[AttachedPropertyBrowsableForType(typeof(Control))]
	//	//public static CornerRadius GetCornerRadius(DependencyObject obj)
	//	//{
	//	//	return (CornerRadius)obj.GetValue(CornerRadiusProperty);
	//	//}
	//	//public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
	//	//{
	//	//	obj.SetValue(CornerRadiusProperty, value);
	//	//}
	//	//public static readonly DependencyProperty CornerRadiusProperty =
	//	//	DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(Appearance), new PropertyMetadata(default(CornerRadius), RoundCornerChanged));
	//	//private static void RoundCornerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	//	//{
	//	//	if ((d as Control).IsInitialized) return;
	//	//	RoutedEventHandler eh = null;
	//	//	(d as FrameworkElement).Loaded += eh = (s, e) =>
	//	//	{
	//	//		var c = s as Control;
	//	//		c.Loaded -= eh;
	//	//		BindingOperations.SetBinding((Border)c.Template.FindName("border", c), Border.CornerRadiusProperty, new Binding { Path = new PropertyPath(Appearance.CornerRadiusProperty), RelativeSource = RelativeSource.TemplatedParent, Mode = BindingMode.OneWay });
	//	//	};
	//	//}
	//	#endregion //CornerRadius


	//	#region HintText
	//	//[AttachedPropertyBrowsableForType(typeof(TextBox))]
	//	//[Bindable(false)]
	//	//public static string GetStaticHintText(DependencyObject obj)
	//	//{
	//	//	return (string)obj.GetValue(StaticHintTextProperty);
	//	//}
	//	//public static void SetStaticHintText(DependencyObject obj, string value)
	//	//{
	//	//	obj.SetValue(StaticHintTextProperty, value);
	//	//}
	//	//public static readonly DependencyProperty StaticHintTextProperty =
	//	//	DependencyProperty.RegisterAttached("StaticHintText", typeof(string), typeof(Appearance), new PropertyMetadata(string.Empty, StaticHintTextChanged));



	//	//private static void StaticHintTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	//	//{
	//	//	var control = d as Control;
	//	//	if (control.IsInitialized)
	//	//	{
	//	//		throw new NotImplementedException("Only before init!");
	//	//	}
	//	//	else //not inited
	//	//	{
	//	//		RoutedEventHandler eh = null;
	//	//		control.Loaded += eh = (s, e) =>
	//	//		{
	//	//			var c = s as TextBox;
	//	//			c.Loaded -= eh;
	//	//			AdornerLayer.GetAdornerLayer(c).Add(new StaticHintAdorner(c, GetStaticHintText(c)));
	//	//		};
	//	//		control.Unloaded += (s, e) =>
	//	//		{
	//	//			var c = s as TextBox;
	//	//			var al = AdornerLayer.GetAdornerLayer(c);
	//	//			var ads = al.GetAdorners(c);
	//	//			for (int i = 0; i < ads.Length; i++)
	//	//			{
	//	//				if (ads[i] is StaticHintAdorner sha)
	//	//				{
	//	//					al.Remove(sha);
	//	//					return;
	//	//				}
	//	//			}
	//	//		};
	//	//	}
	//	//}
	//	//private class StaticHintAdorner : Adorner
	//	//{
	//	//	private FormattedText _hint;
	//	//	private TextBox _textBox;
	//	//	private readonly Point _renderPoint;

	//	//	public StaticHintAdorner(TextBox adornedElement, string hint) : base(adornedElement)
	//	//	{
	//	//		#region DEFAULTS
	//	//		_textBox = adornedElement;
	//	//		_renderPoint = new Point(_textBox.Padding.Left + 2, _textBox.Padding.Top + 1);
	//	//		IsHitTestVisible = false;
	//	//		Opacity = 0.5d;
	//	//		//Visibility = string.IsNullOrEmpty(_textBox.Text) && _textBox.IsVisible ? Visibility.Visible : Visibility.Collapsed;
	//	//		_hint = new FormattedText(hint, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface(adornedElement.FontFamily, adornedElement.FontStyle, adornedElement.FontWeight, adornedElement.FontStretch), adornedElement.FontSize, adornedElement.Foreground, 1.0);
	//	//		#endregion //DEFAULTS
	//	//		this.Unloaded += HintAdorner_Unloaded;
	//	//		_textBox.TextChanged += _textBox_TextChanged;
	//	//		_textBox.IsVisibleChanged += _textBox_IsVisibleChanged;
	//	//	}

	//	//	private void _textBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	//	//	{
	//	//		if (!_textBox.IsVisible)
	//	//		{
	//	//			this.Visibility = Visibility.Collapsed;
	//	//		}
	//	//	}

	//	//	private void _textBox_TextChanged(object sender, TextChangedEventArgs e)
	//	//	{
	//	//		if (!string.IsNullOrEmpty(_textBox.Text))
	//	//		{
	//	//			//this.Visibility = Visibility.Collapsed;
	//	//		}
	//	//		else if (_textBox.IsVisible)
	//	//		{
	//	//			this.Visibility = Visibility.Visible;
	//	//		}
	//	//	}

	//	//	private void HintAdorner_Unloaded(object sender, RoutedEventArgs e)
	//	//	{
	//	//		this.Unloaded -= HintAdorner_Unloaded;
	//	//		_textBox.TextChanged -= _textBox_TextChanged;
	//	//		_textBox.IsVisibleChanged -= _textBox_IsVisibleChanged;
	//	//		_textBox = null;
	//	//		_hint = null;
	//	//	}

	//	//	protected override void OnRender(DrawingContext drawingContext)
	//	//	{
	//	//		drawingContext.DrawText(_hint, _renderPoint);
	//	//	}
	//	//	//public void ChangeHintText(string newHintText)
	//	//	//{
	//	//	//	_hint = new FormattedText(newHintText, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface(_TextBox.FontFamily, _TextBox.FontStyle, _TextBox.FontWeight, _TextBox.FontStretch), _TextBox.FontSize, _TextBox.Foreground, 1.0);
	//	//	//	InvalidateVisual();
	//	//	//}
	//	//}
	//	#endregion //HintText
	//}
}
