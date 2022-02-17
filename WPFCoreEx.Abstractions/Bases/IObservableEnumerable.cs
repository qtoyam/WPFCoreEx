using System.Collections.Specialized;
using System.ComponentModel;

namespace WPFCoreEx.Abstractions.Bases
{
	public interface IObservableEnumerable<T> : IEnumerable<T>, IReadOnlyCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
	{
		/// <summary>
		/// Occurs when count value changes.
		/// </summary>
		event EventHandler? CountChanged;
	}
}
