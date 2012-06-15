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

			matches.Single().should_be_of_type<PostLogin>();
			
		}

		[Then]
		public void login_url_should_have_only_one_post_handler()
		{
			var match_count = 
				MySite()
				.GetHandlersFor("/login")
				.RespondingTo<IPost>()
				.Count();

			match_count.should_be_equal_to(1);
		}

		IEnumerable<Assembly> MySite()
		{
			return AppDomain.CurrentDomain.GetAssemblies();
		}
	}
}
