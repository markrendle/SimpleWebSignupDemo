using AwesomeThing.Login;
using NUnit.Framework;

namespace Tests.LoginConcerns.with_a_login_page_and_a_bad_password
{
	[Scenario]
	class PostingToTheLoginPage : with_a_login_page_and_a_bad_password
	{
		[When]
		public void I_post_to_the_login_page()
		{
			subject.Post();
		}

		[Then]
		public void I_should_be_redirected_back_to_the_login_page()
		{
			subject.Location.should_be_equal_to("/login");
		}
	}

	class with_a_login_page_and_a_bad_password
	{
		public PostLogin subject;

		[Given]
		public void a_login_page_and_a_bad_password()
		{
			subject = new PostLogin {
			          	Input = new Login {
			          	        	Password = "rubbish",
			          	        	User = "junk"
			          	        }
			          };
		}
	}
}
