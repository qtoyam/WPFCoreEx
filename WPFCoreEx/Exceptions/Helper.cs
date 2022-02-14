using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoreEx.Exceptions
{
	internal static class Helper
	{
		internal static void ThrowIfNull(object? obj)
		{
			if (obj == null) throw new NullReferenceException();
		}
	}
}
