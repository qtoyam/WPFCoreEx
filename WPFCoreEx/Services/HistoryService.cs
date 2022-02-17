using System;

using WPFCoreEx.Abstractions.Bases;
using WPFCoreEx.Abstractions.Services;
using WPFCoreEx.Bases;
using WPFCoreEx.Commands;

namespace WPFCoreEx.Services
{
	public sealed class HistoryService : IHistoryService
	{
		private readonly ObservableLinkedList<HistoryItem> _undoItems = new();
		private readonly ObservableLinkedList<HistoryItem> _redoItems = new();

		public IObservableEnumerable<HistoryItem> UndoItems { get; }
		public IObservableEnumerable<HistoryItem> RedoItems { get; }

		public int Capacity { get; }

		public HistoryService(int capacity)
		{
			Capacity = capacity;
			UndoItems = _undoItems;
			RedoItems = _redoItems;
			UndoCommand = new(UndoInternal, CanUndoInternal, false);
			RedoCommand = new(RedoInternal, CanRedoInternal, false);

			_undoItems.CountChanged += OnUndoCountChanged;
			_redoItems.CountChanged += OnRedoCountChanged;
		}

		public void Add(HistoryItem item)
		{
			_redoItems.Clear();
			if (_undoItems.Count == Capacity)
			{
				_undoItems.RemoveFirst();
			}
			_undoItems.AddLast(item);
		}
		public void Clear()
		{
			_redoItems.Clear();
			_undoItems.Clear();
		}

		public bool Undo()
		{
			if (CanUndoInternal())
			{
				UndoInternal();
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool Redo()
		{
			if (CanRedoInternal())
			{
				RedoInternal();
				return true;
			}
			else
			{
				return false;
			}
		}

		#region Commands
		public CommandEx UndoCommand { get; }
		public CommandEx RedoCommand { get; }

		private void OnUndoCountChanged(object? sender, EventArgs e) => UndoCommand.Update();
		private void OnRedoCountChanged(object? sender, EventArgs e) => RedoCommand.Update();
		#endregion //Commands

		public int Undo(int undoCount)
		{
			for (int i = 0; i < undoCount; i++)
			{
				if (!Undo())
				{
					return i;
				}
			}
			return undoCount;
		}
		public int Redo(int redoCount)
		{
			for (int i = 0; i < redoCount; i++)
			{
				if (!Redo())
				{
					return i;
				}
			}
			return redoCount;
		}

		private bool CanUndoInternal() => _undoItems.Count > 0 && _undoItems.Last.CanUndo();
		private void UndoInternal()
		{
			var historyItem = _undoItems.RemoveFirst();
			historyItem.Undo();
			_redoItems.AddLast(historyItem);
		}

		private bool CanRedoInternal() => _redoItems.Count > 0 && _redoItems.Last.CanRedo();
		private void RedoInternal()
		{
			var historyItem = _redoItems.RemoveFirst();
			historyItem.Redo();
			_undoItems.AddLast(historyItem);
		}
	}
}
