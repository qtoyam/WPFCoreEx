using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFCoreEx.Bases
{
	public class NotifyPropBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// If new value equals field's value return <see langword="false"/>, otherwise sets new value to field, calls <see cref="OnPropertyChanged(string)"/> and return <see langword="true"/>
		/// </summary>
		/// <typeparam name="P">Property type</typeparam>
		/// <param name="field">Property backing field</param>
		/// <param name="newValue">New value of property</param>
		/// <param name="propName">Property name</param>
		/// <returns><see langword="true"/> if new value assigned, otherwise <see langword="false"/></returns>
		protected virtual bool Set<P>(ref P field, P newValue, [CallerMemberName] string propName = "")
		{
			if (Equals(field, newValue))
			{
				return false;
			}
			else //new value != old value
			{
				field = newValue;
				OnPropertyChanged(propName);
				return true;
			}
		}
		protected virtual void OnPropertyChanged([CallerMemberName] string propName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}
	}
}

