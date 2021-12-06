using Microsoft.Xaml.Behaviors.Core;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

using WPFCoreEx.Bases;

namespace WPFCoreEx.Tests
{
	public enum ContentType : int
	{
		None = 0b_0,
		Image = 0b_1,
		NotSupported = 0b_1000_0000_0000_0000
	}

	public class VM : NotifyPropBase
	{
		public ObservableCollection<Person> Persons { get; } = new();

		public VM()
		{
			Persons.Add(new("Sad", "Boba"));
			Persons.Add(new("ASDad", "Boba"));
			Persons.Add(new("Gbcc", "Rossd"));
			Persons.Add(new("Fsdgt", "Rossd"));
		}
	}

	public class Person
	{
#nullable disable
		public string Name { get; set; }
		public string FirstName { get; set; }

		public Person(string name, string firstName)
		{
			Name = name;
			FirstName = firstName;
		}
	}
}
