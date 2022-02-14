using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WPFCoreEx.Bases
{
	public class ObservableCollectionEx<T> : ObservableCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
		where T : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? ItemPropertyChanged;

		public ObservableCollectionEx() : base() { }

		public ObservableCollectionEx(IEnumerable<T> collection) : base(collection)
		{
			foreach (var item in collection)
			{
				item.PropertyChanged += OnItemChanged;
			}
		}

		public ObservableCollectionEx(List<T> list) : base(list)
		{
			foreach (var item in list)
			{
				item.PropertyChanged += OnItemChanged;
			}
		}

		protected override void InsertItem(int index, T item)
		{
			item.PropertyChanged += OnItemChanged;
			base.InsertItem(index, item);
		}

		protected override void ClearItems()
		{
			foreach(var item in base.Items)
			{
				item.PropertyChanged -= OnItemChanged;
			}
			base.ClearItems();
		}

		protected override void RemoveItem(int index)
		{
			base.Items[index].PropertyChanged -= OnItemChanged;
			base.RemoveItem(index);
		}

		protected override void SetItem(int index, T item)
		{
			T oldValue = base.Items[index];
			oldValue.PropertyChanged -= OnItemChanged;
			item.PropertyChanged += OnItemChanged;
			base.SetItem(index, item);
		}

		protected void OnItemChanged(object? sender, PropertyChangedEventArgs e)
		{
			ItemPropertyChanged?.Invoke(sender, e);
		}
	}
}
