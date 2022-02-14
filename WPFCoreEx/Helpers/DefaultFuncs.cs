namespace WPFCoreEx.Helpers
{
#pragma warning disable IDE0060 // Remove unused parameter
	internal static class DefaultFuncs
	{
		internal static bool True() => true;
	}

	internal static class DefaultFuncs<T>
	{
		internal static bool True(T? ignored) => true;

		internal static bool NotNull(T? parameter) => parameter != null;
	}
#pragma warning restore IDE0060 // Remove unused parameter
}
