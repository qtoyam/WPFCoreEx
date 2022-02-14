using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPFCoreEx.Abstractions.Bases;

namespace WPFCoreEx.Abstractions.Services
{
	public interface IHistoryService
	{
		IReadOnlyCollection<HistoryItem> UndoItems { get; }
		IReadOnlyCollection<HistoryItem> RedoItems { get; }
		int Capacity { get; }

		void Add(HistoryItem item);

		bool Undo();
		int Undo(int undoCount);

		bool Redo();
		int Redo(int redoCount);
	}
}
