using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

using WPFCoreEx.Abstractions.Bases;
using WPFCoreEx.Helpers;

namespace WPFCoreEx.Bases
{
	public class FullObservableCollection<T> : Collection<T>, IFullObservableEnumerable<T>
		where T : INotifyPropertyChanged
	{
		public FullObservableCollection() : base() { }
		public FullObservableCollection(IList<T> list) : base(list)
		{
			foreach (var item in list)
			{
				SubItem(item);
			}
		}

		#region INotifyPropertyChanged implementation
		private event PropertyChangedEventHandler? PropertyChanged;
		event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
		{
			add => PropertyChanged += value;
			remove => PropertyChanged -= value;
		}
		#endregion //INotifyPropertyChanged implementation

		#region INotifyCollectionChanged implementation
		public event NotifyCollectionChangedEventHandler? CollectionChanged;
		#endregion //INotifyCollectionChanged implementation

		#region INotifyCollectionChangedEx implementation
		public event PropertyChangedEventHandler? ItemPropertyChanged;
		public event EventHandler? CountChanged;
		#endregion //INotifyCollectionChangedEx implementation

		#region Collection<T> overrides
		protected override void InsertItem(int index, T item)
		{
			base.InsertItem(index, item);
			OnCountChanged();
			OnCollectionChanged(new(NotifyCollectionChangedAction.Add, item, index));
			SubItem(item);
		}
		protected override void RemoveItem(int index)
		{
			T removedItem = this[index];
			UnsubItem(removedItem);
			base.RemoveItem(index);
			OnCountChanged();
			OnCollectionChanged(new(NotifyCollectionChangedAction.Remove, removedItem, index));
		}
		protected override void SetItem(int index, T item)
		{
			T oldItem = this[index];
			UnsubItem(oldItem);
			base.SetItem(index, item);
			OnCountChanged();
			OnCollectionChanged(new(NotifyCollectionChangedAction.Replace, item, oldItem, index));
			SubItem(item);
		}
		protected override void ClearItems()
		{
			foreach (T item in this)
			{
				UnsubItem(item);
			}
			base.ClearItems();
			OnCountChanged();
			OnCollectionChanged(new(NotifyCollectionChangedAction.Reset));
		}
		#endregion //Collection<T> overrides

		private void OnItemChanged(object? sender, PropertyChangedEventArgs e)
		{
			ItemPropertyChanged?.Invoke(sender, e);
		}
		protected void SubItem(T item)
		{
			item.PropertyChanged += OnItemChanged;
		}
		protected void UnsubItem(T item)
		{
			item.PropertyChanged -= OnItemChanged;
		}

		protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
		{
			CollectionChanged?.Invoke(this, args);
		}

		protected void OnPropertyChanged(PropertyChangedEventArgs args)
		{
			PropertyChanged?.Invoke(this, args);
		}
		protected void OnCountChanged()
		{
			OnPropertyChanged(EventArgsCache.CountProperty);
			CountChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
