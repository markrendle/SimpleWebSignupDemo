using AwesomeThing.Login;// ReSharper disable UseObjectOrCollectionInitializer
using NUnit.Framework;

namespace Tests.LoginConcerns.with_a_login_page_and_the_correct_password
{
	[Scenario]
	class PostingToTheLoginPage : with_a_login_page_and_the_correct_password
	{
		[When]
		public void I_post_to_the_login_page()
		{
			subject.Post();
		}

		[Then]
		public void I_should_be_redirected_back_to_where_I_was_headed()
		{
			Assert.That(subject.Location, Is.EqualTo("/login"));
		}
	}

	class with_a_login_page_and_the_correct_password
	{
		public PostLogin subject;
		const string target = "/woot";

		[Given]
		public void a_login_page_and_a_bad_password()
		{
			subject = new PostLogin();
			subject.Input = new Login{
				Password = "mark",
				User="password",
				ReturnUrl = target
			};
		}
	}
}
