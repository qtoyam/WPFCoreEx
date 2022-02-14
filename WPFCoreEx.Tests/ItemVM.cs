using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFCoreEx.Tests
{
	public class ItemVM
	{
		public string Name { get; }

		public ItemVM(string name)
		{
			Name = name;
		}

		public override string ToString() => Name;
	}
}
