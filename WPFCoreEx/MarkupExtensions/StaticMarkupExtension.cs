﻿using System;
using System.Windows.Markup;

namespace WPFCoreEx.MarkupExtensions
{
	public abstract class StaticMarkupExtension<T> : MarkupExtension
		where T : class, new()
	{
		public sealed override object ProvideValue(IServiceProvider serviceProvider)
		{
			return _converter ??= new();
		}

		private static T? _converter = null;
	}
}
