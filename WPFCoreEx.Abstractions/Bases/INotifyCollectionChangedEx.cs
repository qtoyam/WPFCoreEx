using System.ComponentModel;

namespace WPFCoreEx.Abstractions.Bases
{
	public interface IFullObservableEnumerable<T> : IObservableEnumerable<T>
		where T : INotifyPropertyChanged
	{
		/// <summary>
		/// Occurs when a property value changes in item from collection.
		/// </summary>
		event PropertyChangedEventHandler? ItemPropertyChanged;
	}
}
