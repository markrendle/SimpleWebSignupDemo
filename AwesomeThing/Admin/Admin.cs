namespace AwesomeThing.Admin
{
    using System;
    using System.Collections.Generic;
    using Simple.Data;
    using Simple.Web;

    [UriTemplate("/admin", false)]
    [UriTemplate("/signups")]
    public class Admin : AdminBase, IGet, IOutput<List<Signup>>//, ICacheability
    {
        public Status Get()
        {
            var db = Database.OpenNamedConnection("AwesomeThing");
            Output = db.Signups.All().ToList<Signup>();

            return 200;
        }

        public List<Signup> Output { get; set; }

        public CacheOptions CacheOptions
        {
            get { return CacheOptions.DisableCaching; }
        }
    }
}