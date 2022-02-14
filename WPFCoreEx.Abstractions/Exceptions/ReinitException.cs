namespace WPFCoreEx.Abstractions.Exceptions
{
	[Serializable]
	public sealed class ReinitException : Exception
	{
		public ReinitException(string reinitObj) : base($"Cannot call again '{reinitObj}'.") { }
	}
}
