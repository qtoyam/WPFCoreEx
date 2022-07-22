using System;

namespace WPFCore.Converters
{
	public class ConvertBackNotSupportedExtension : Exception
	{
		public ConvertBackNotSupportedExtension() : base("Back conversion not supported by this converter.") { }
	}
}
