using AwesomeThing.Login;// ReSharper disable UseObjectOrCollectionInitializer
using NUnit.Framework;
using Simple.Web;

namespace Tests.LoginConcerns.with_a_login_page_and_the_correct_password
{
	[Scenario]
	class PostingToTheLoginPage : with_a_login_page_and_the_correct_password
	{
		[When]
		public void I_post_to_the_login_page()
		{
			result = subject.Post();
		}

		[Then]
		public void I_should_be_redirected_back_to_where_I_was_headed()
		{
			result.should_be_equal_to(Status.SeeOther);
			subject.Location.should_be_equal_to(target);
		}

		[Then]
		public void The_current_logged_in_user_should_be_Mark()
		{
			subject.LoggedInUser.Guid.should_be_equal_to(PostLogin.mark);
		}
	}

	class with_a_login_page_and_the_correct_password
	{
		public PostLogin subject;
		public Status result;
		public const string target = "/woot";

		[Given]
		public void a_login_page_and_a_bad_password()
		{
			subject = new PostLogin();
			subject.Input = new Login
			{
				Password = "password",
				User = "mark",
				ReturnUrl = target
			};
		}
	}
}
