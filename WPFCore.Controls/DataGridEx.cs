using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFCore.Controls
{
	//TODO: finish, add brushes
	public sealed class DataGridEx : DataGrid
	{
		//static DataGridEx()
		//{
		//	DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridEx), new FrameworkPropertyMetadata(typeof(DataGridEx)));
		//}



		public Brush ForegroundHeader
		{
			get => (Brush)GetValue(ForegroundHeaderProperty);
			set => SetValue(ForegroundHeaderProperty, value);
		}
		public static readonly DependencyProperty ForegroundHeaderProperty = DependencyProperty.Register("ForegroundHeader", typeof(Brush), typeof(DataGridEx), new PropertyMetadata());



		public Brush ForegroundCell
		{
			get => (Brush)GetValue(ForegroundCellProperty);
			set => SetValue(ForegroundCellProperty, value);
		}
		public static readonly DependencyProperty ForegroundCellProperty = DependencyProperty.Register("ForegroundCell", typeof(Brush), typeof(DataGridEx), new PropertyMetadata());


	}
}
