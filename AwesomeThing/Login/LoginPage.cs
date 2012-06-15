namespace AwesomeThing.Login
{
    using System;
    using Simple.Web;
    using Simple.Web.Authentication;
    using Simple.Web.Behaviors;

    [UriTemplate("/login")]
    public class LoginPage : IGet, ILoginPage
    {
        public Status Get()
        {
            return 200;
        }

        public string ReturnUrl { get; set; }
    }

    [UriTemplate("/login")]
    public class PostLogin : IPost, ILogin, IInput<Login>, IMayRedirect
    {
    	public static readonly Guid mark = new Guid("{BA49D759-1C6D-48E9-8181-76FBF24985FF}");
        public Status Post()
        {
            if (Input.User == "mark" && Input.Password == "password")
            {
                LoggedInUser = new User(mark, "Mark");
                Location = Input.ReturnUrl;
                return Status.SeeOther;
            }

            Location = "/login";
            return Status.SeeOther;
        }

        public IUser LoggedInUser { get; private set; }

        public Login Input { get; set; }

        public string Location { get; private set; }
    }

    public class Login
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}