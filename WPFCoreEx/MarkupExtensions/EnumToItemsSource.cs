using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;

namespace WPFCoreEx.MarkupExtensions
{
	public class EnumDescriptionsToItemsSource : MarkupExtension
	{
		private readonly Type _type;

		public EnumDescriptionsToItemsSource(Type type)
		{
			_type = type;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return _type.GetMembers()
				.SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true)
				.Cast<DescriptionAttribute>())
				.Select(x => x.Description)
				.ToList();
		}
	}
}
