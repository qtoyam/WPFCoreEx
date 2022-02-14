namespace WPFCoreEx.Abstractions.Exceptions
{
	[Serializable]
	public sealed class ReregException : Exception
	{
		public ReregException(string reregName) : base($"{reregName} already registered.") { }
	}
}
