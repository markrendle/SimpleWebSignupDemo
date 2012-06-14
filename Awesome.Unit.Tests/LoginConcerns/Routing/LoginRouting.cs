using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AwesomeThing.Login;
using NUnit.Framework;
using Simple.Web;
using Tests.Scaffold;

namespace Tests.LoginConcerns.Routing
{
	[Scenario]
	class LoginRouting
	{
		[Then]
		public void login_post_handled_by_PostLogin()
		{
			var matches = 
				MySite()
				.GetHandlersFor("/login")
				.RespondingTo<IPost>();

			Assert.That(matches.Single().FullName, Is.EqualTo(typeof(PostLogin).FullName)); // gets wrapped in RunTimeType :-(
		}

		[Then]
		public void login_url_should_have_only_one_post_handler()
		{
			var match_count = 
				MySite()
				.GetHandlersFor("/login")
				.RespondingTo<IPost>()
				.Count();

			Assert.That(match_count, Is.EqualTo(1));
		}

		IEnumerable<Assembly> MySite()
		{
			return AppDomain.CurrentDomain.GetAssemblies();
		}
	}
}
