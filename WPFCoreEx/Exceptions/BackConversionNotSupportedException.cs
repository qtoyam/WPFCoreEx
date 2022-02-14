using System;

namespace WPFCoreEx.Exceptions
{
	public class BackConversionNotSupportedException : Exception
	{
		public BackConversionNotSupportedException() : base("Back conversion not supported by this converter.") { }
	}
}
