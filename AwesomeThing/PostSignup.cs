using System;

namespace AwesomeThing
{
    using Simple.Data;
    using Simple.Web;
    using Simple.Web.Behaviors;

    [UriTemplate("/signup")]
    public class PostSignup : IPost, IInput<Signup>
    {
        public Status Post()
        {
            var db = Database.OpenNamedConnection("AwesomeThing");
            var inserted = db.Signups.Insert(
				Id: Guid.NewGuid(),
				Email: Input.Email,
				CreatedAt: DateTime.Now
			);
            Number = inserted.Number;
            return 200;
        }

        public Signup Input { get; set; }

        public int Number { get; set; }
    }

    public class Signup
    {
        public string Email { get; set; }
    }
}