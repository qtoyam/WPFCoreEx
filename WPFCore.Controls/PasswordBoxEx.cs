using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFCore.Controls
{
	//TODO: IDK WHAT IS THIS

	//public sealed class PasswordBoxEx : TextBoxEx
	//{
	//	public PasswordBoxEx()
	//	{
	//		_pass = new Memory<byte>(new byte[MaxLength * 4]);
	//	}
	//	private Memory<byte> _pass;
	//	private Encoding _encoding;

	//	protected override void OnPreviewKeyDown(KeyEventArgs keyEventArgs)
	//	{
	//		if (IsReadOnly) return;
	//		Key pressedKey = keyEventArgs.Key == Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
	//		switch (pressedKey)
	//		{
	//			case Key.Space:
	//				AddChars(" ");
	//				keyEventArgs.Handled = true;
	//				break;
	//			case Key.Back:
	//			case Key.Delete:
	//				if (SelectionLength > 0)
	//					RemoveChars(SelectionStart, SelectionLength);
	//				else if (pressedKey == Key.Delete && CaretIndex < Text.Length)
	//					RemoveChars(CaretIndex, 1);
	//				else if (pressedKey == Key.Back && CaretIndex > 0)
	//				{
	//					int caretIndex = CaretIndex;
	//					RemoveChars(CaretIndex - 1, 1);
	//					CaretIndex = caretIndex - 1;
	//				}
	//				keyEventArgs.Handled = true;
	//				break;
	//		}
	//		base.OnPreviewKeyDown(keyEventArgs);
	//	}
	//	private void QPassbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
	//	{
	//		if (IsReadOnly) return;
	//		AddChars(e.Text);
	//		e.Handled = true;
	//	}

	//	private void AddChars(string text)
	//	{
	//		if (SelectionLength > 0)
	//		{
	//			RemoveChars(SelectionStart, SelectionLength);
	//		}

	//		int caretIndex = CaretIndex;
	//		using (var cr = new Crypter())
	//		{
	//			foreach (char c in text)
	//			{
	//				if (!IsPassVisible)
	//				{
	//					try
	//					{
	//						MovePassword(caretIndex + 1);
	//					}
	//					catch { break; }
	//					_qpassd[caretIndex + 1] = CryptChar(c, cr);
	//				}
	//				Text = Text.Insert(caretIndex, IsPassVisible == true ? c.ToString() : PassChar.ToString());
	//				caretIndex++;
	//			}
	//		}
	//		CaretIndex = caretIndex;
	//	}

	//	private void RemoveChars(int startIndex, int trimLength)
	//	{
			
	//	}



	//	public bool IsPassVisible
	//	{
	//		get { return (bool)GetValue(IsPassVisibleProperty); }
	//		set { SetValue(IsPassVisibleProperty, value); }
	//	}

	//	// Using a DependencyProperty as the backing store for IsPassVisible.  This enables animation, styling, binding, etc...
	//	public static readonly DependencyProperty IsPassVisibleProperty =
	//		DependencyProperty.Register("IsPassVisible", typeof(bool), typeof(PasswordBoxEx), new PropertyMetadata());



	//	public new int MaxLength
	//	{
	//		get { return (int)GetValue(MaxLengthProperty); }
	//		set { SetValue(MaxLengthProperty, value); }
	//	}
	//	public static new readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(PasswordBoxEx), new PropertyMetadata(MaxLengthChanged));

	//	private static void MaxLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	//	{
	//		PasswordBoxEx pbe = (PasswordBoxEx)d;
	//		pbe.Text = string.Empty;
	//		pbe._pass.Span.Clear();
	//		pbe._pass = new Memory<byte>(new byte[(int)e.NewValue * 4]);
	//	}


	//}
}
