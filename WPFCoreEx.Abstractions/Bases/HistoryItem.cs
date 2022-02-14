using System.Collections;

namespace WPFCoreEx.Abstractions.Bases
{
	public abstract class HistoryItem
	{
		public virtual bool CanUndo() => true;
		public abstract void Undo();

		public virtual bool CanRedo() => true;
		public abstract void Redo();

		public static HistoryItem FromListRemove<T>(IList<T> source, T removedItem, int index)
			=> new HistoryItemListRemove<T>(source, removedItem, index);
		public static HistoryItem FromListAdd<T>(IList<T> source, T addedItem, int index)
			=> new HistoryItemListAdd<T>(source, addedItem, index);
		public static HistoryItem FromListChange<T>(IList<T> source, T oldItem, T newItem, int index)
			=> new HistoryItemListChange<T>(source, oldItem, newItem, index);
	}

	#region List based history items
	internal class HistoryItemListRemove<T> : HistoryItem
	{
		private readonly IList<T> _source;
		private readonly T _removedItem;
		private readonly int _index;

		public HistoryItemListRemove(IList<T> source, T removedItem, int index)
		{
			_source = source;
			_removedItem = removedItem;
			_index = index;
		}

		public override void Undo() => _source.Insert(_index, _removedItem);
		public override void Redo() => _source.RemoveAt(_index);
	}

	internal class HistoryItemListAdd<T> : HistoryItem
	{
		private readonly IList<T> _source;
		private readonly T _addedItem;
		private readonly int _index;

		public HistoryItemListAdd(IList<T> source, T addedItem, int index)
		{
			_source = source;
			_addedItem = addedItem;
			_index = index;
		}

		public override void Undo() => _source.RemoveAt(_index);
		public override void Redo() => _source.Insert(_index, _addedItem);
	}

	internal class HistoryItemListChange<T> : HistoryItem
	{
		private readonly IList<T> _source;
		private readonly T _oldItem;
		private readonly T _newItem;
		private readonly int _index;

		public HistoryItemListChange(IList<T> source, T oldItem, T newItem, int index)
		{
			_source = source;
			_oldItem = oldItem;
			_newItem = newItem;
			_index = index;
		}

		public override void Undo() => _source[_index] = _oldItem;
		public override void Redo() => _source[_index] = _newItem;
	}
	#endregion //List based history items
}
