﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

using WPFCoreEx.Abstractions.Bases;
using WPFCoreEx.Helpers;

namespace WPFCoreEx.Bases
{
	public class ObservableLinkedList<T> : IObservableEnumerable<T>
	{
		private readonly LinkedList<T> _linkedList;

		public int Count => _linkedList.Count;

		public ObservableLinkedList()
		{
			_linkedList = new();
		}

		public ObservableLinkedList(IEnumerable<T> enumerable)
		{
			_linkedList = new(enumerable);
		}

		public void Clear()
		{
			_linkedList.Clear();
			OnCountChanged();
			OnListChanged(new(NotifyCollectionChangedAction.Reset));
		}

		public void AddLast(T value)
		{
			_linkedList.AddLast(value);
			OnCountChanged();
			OnListChanged(new(NotifyCollectionChangedAction.Add, value, Count));
		}

		public void AddFirst(T value)
		{
			_linkedList.AddFirst(value);
			OnCountChanged();
			OnListChanged(new(NotifyCollectionChangedAction.Add, value, 0));
		}

		public T RemoveFirst()
		{
			T value = _linkedList.First!.Value;
			_linkedList.RemoveFirst();
			OnCountChanged();
			OnListChanged(new(NotifyCollectionChangedAction.Remove, value, 0));
			return value;
		}

		public T RemoveLast()
		{
			T value = _linkedList.Last!.Value; //will throw
			_linkedList.RemoveLast();
			OnCountChanged();
			OnListChanged(new(NotifyCollectionChangedAction.Remove, value, Count+1));
			return value;
		}

		public T First => _linkedList.First!.Value;
		public T Last => _linkedList.Last!.Value;

		#region IEnumerable<T>
		public IEnumerator<T> GetEnumerator() => _linkedList.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		#endregion //IEnumerable<T>

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
		public event EventHandler? CountChanged;
		#endregion //INotifyCollectionChangedEx implementation

		private void OnListChanged(NotifyCollectionChangedEventArgs args)
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
