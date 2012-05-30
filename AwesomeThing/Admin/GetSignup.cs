namespace AwesomeThing.Admin
{
    using System;
    using System.Collections.Generic;
    using Simple.Data;
    using Simple.Web;
    using Simple.Web.Links;

    [UriTemplate("/signup/{Id}")]
    [Canonical(typeof(Signup), "/signup/{Id}", Title = "Signup Details", Type = "application/vnd.signup")]
    public class GetSignup : IGet, IOutput<Signup>
    {
        public Status Get()
        {
            var db = Database.OpenNamedConnection("AwesomeThing");
            Output = db.Signups.FindById(Id);

            if (Output == null) return 404;

            return 200;
        }

        public Signup Output { get; set; }

        public Guid Id { get; set; }
    }

    public class Signup
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
    }
}