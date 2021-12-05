using Microsoft.Xaml.Behaviors.Core;

using System;
using System.Collections.Generic;
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
		
	}
}
