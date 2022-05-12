using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace WPFCoreEx.Tests
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{

		class TestClass
		{
			public string Aboba { get; set; }
			public string Bboba { get; set; }
		}
		protected override void OnStartup(StartupEventArgs e)
		{
			//TestClass tc = new() { Aboba = "ss", Bboba = "123" };

			//R<TestClass>(x => x.Aboba != null && x.Bboba.Length > 0 && x.Bboba[2] == 'c');

			base.OnStartup(e);
		}

		//void R<VM>(Expression<Func<VM, bool>> expr)
		//	where VM : class
		//{
		//	List<string> members = new();
		//	Find(expr.Body, members);

		//}

		//void Find(System.Linq.Expressions.Expression expr, List<string> found)
		//{
		//	switch (expr)
		//	{
		//		case MemberExpression memberExpression:
		//			if (memberExpression.Expression is MemberExpression nestedMemberExpression)
		//			{
		//				Find(nestedMemberExpression, found);
		//			}
		//			else
		//			{
		//				found.Add(memberExpression.Member.Name);
		//			}
		//			break;
		//		case UnaryExpression unaryExpression:
		//			//found.Add(((MemberExpression)unaryExpression.Operand).Member.Name);
		//			Find(unaryExpression.Operand, found);
		//			break;
		//		case BinaryExpression binaryExpression:
		//			Find(binaryExpression.Left, found);
		//			Find(binaryExpression.Right, found);
		//			break;
		//		case ConstantExpression:
		//			break;
		//		case MethodCallExpression methodCallExpression:
		//			methodCallExpression.
		//			break;
		//		default:
		//			throw new NotSupportedException();
		//	}
		//}
	}
}
