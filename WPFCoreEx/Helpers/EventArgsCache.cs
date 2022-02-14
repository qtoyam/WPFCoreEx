using System.Collections.Specialized;
using System.ComponentModel;

namespace WPFCoreEx.Helpers
{
	internal static class EventArgsCache
	{
		internal static NotifyCollectionChangedEventArgs CollectionReset = new(NotifyCollectionChangedAction.Reset);
		internal static PropertyChangedEventArgs CountProperty = new("Count");
	}
}
