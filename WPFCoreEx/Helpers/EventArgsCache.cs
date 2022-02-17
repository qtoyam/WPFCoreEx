using System.Collections.Specialized;
using System.ComponentModel;

namespace WPFCoreEx.Helpers
{
	internal static class EventArgsCache
	{
		internal static PropertyChangedEventArgs CountProperty = new("Count");
		internal static PropertyChangedEventArgs ItemIndexerProperty = new("Item[]");
	}
}
