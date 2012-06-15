using System.Linq;
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
		public void login__post__handled_by__PostLogin__only()
		{
			My.site()
				.GetHandlersFor("/login")
				.RespondingTo<IPost>()
				.Single()
				.should_be_of_type<PostLogin>();
		}

		[Then]
		public void login__get__handled_by__LoginPage__only()
		{
			My.site()
				.GetHandlersFor("/login")
				.RespondingTo<IGet>()
				.Single()
				.should_be_of_type<LoginPage>();
		}

	}
}
