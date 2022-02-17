using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

using WPFCoreEx.Abstractions.Bases;

namespace WPFCoreEx.Bases
{
	public class ReadOnlyObservableCollectionEx<T> : ReadOnlyCollection<T>, IFullObservableEnumerable<T>
		where T : INotifyPropertyChanged
	{
		protected FullObservableCollection<T> ItemsObservable { get; }

		public ReadOnlyObservableCollectionEx(FullObservableCollection<T> observableCollectionEx) : base(observableCollectionEx)
		{
			ItemsObservable = observableCollectionEx;
		}

		#region INotifyPropertyChanged implementation
		event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
		{
			add => ((INotifyPropertyChanged)ItemsObservable).PropertyChanged += value;
			remove => ((INotifyPropertyChanged)ItemsObservable).PropertyChanged -= value;
		}
		#endregion //INotifyPropertyChanged implementation

		#region INotifyCollectionChanged implementation
		public event NotifyCollectionChangedEventHandler? CollectionChanged
		{
			add => ItemsObservable.CollectionChanged += value;
			remove => ItemsObservable.CollectionChanged -= value;
		}
		#endregion //INotifyCollectionChanged implementation

		#region INotifyCollectionChangedEx implementation
		public event PropertyChangedEventHandler? ItemPropertyChanged
		{
			add => ItemsObservable.ItemPropertyChanged += value;
			remove => ItemsObservable.ItemPropertyChanged -= value;
		}
		public event EventHandler? CountChanged
		{
			add => ItemsObservable.CountChanged += value;
			remove => ItemsObservable.CountChanged -= value;
		}
		#endregion //INotifyCollectionChangedEx implementation
	}
}
