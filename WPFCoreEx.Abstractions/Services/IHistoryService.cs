
using WPFCoreEx.Abstractions.Bases;

namespace WPFCoreEx.Abstractions.Services
{
	public interface IHistoryService
	{
		IObservableEnumerable<HistoryItem> UndoItems { get; }
		IObservableEnumerable<HistoryItem> RedoItems { get; }
		int Capacity { get; }

		void Add(HistoryItem item);

		void Clear();

		bool Undo();
		int Undo(int undoCount);

		bool Redo();
		int Redo(int redoCount);
	}
}
