using System;
using System.Linq.Expressions;

namespace WPFCoreEx.Helpers
{
	internal static class ExpressionHelper
	{
		internal static string GetPropertyName(LambdaExpression expr)
		{
			return ((MemberExpression)expr.Body).Member.Name;
		}

		internal static string GetPropertyName<TDelegate>(Expression<TDelegate> expr, out TDelegate compiledDelegate)
		{
			compiledDelegate = expr.Compile();
			return expr.Body switch
			{
				MemberExpression me => me.Member.Name, //default
				UnaryExpression ue => ((MemberExpression)ue.Operand).Member.Name, //for expressions like !IsBlocked (to handle '!')
				_ => throw new NotSupportedException("Expression type not supported!"),
			};
		}
	}
}
