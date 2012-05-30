namespace AwesomeThing.Admin
{
    using System;
    using Simple.Data;
    using Simple.Web;
    using Simple.Web.Links;

    [UriTemplate("/sendemail")]
    [LinksFrom(typeof(Signup), "/admin/sendemail/{Id}", Rel = "send.invitation", Title = "Send invitation email")]
    public class SendEmail : AdminBase, IPost, IInput<Signup>
    {
        private readonly IEmailSender _emailSender;

        public SendEmail(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Status Post()
        {
            var db = Database.OpenNamedConnection("AwesomeThing");
            Signup signup = db.Signups.FindById(Input.Id);
            if (signup == null)
            {
                return 404;
            }
            if (db.Invitations.Exists(db.Invitations.SignupId == Input.Id))
            {
                return new Status(409, "Email already sent.");
            }

            Invitation invitation = db.Invitations.Insert(SignupId: Input.Id);
            var body = string.Format("You're in the beta!\nYour invitation code is: {0}\n\nLots of love,\n{1}",
                                     invitation.Id, CurrentUser.Name);
            _emailSender.Send(new Email {To = signup.Email, Subject = "Your AwesomeThing Beta Invitation", Body = body});
            return 201;
        }

        public Signup Input { get; set; }
    }

    public class Invitation
    {
        public Guid Id { get; set; }
        public Guid SignupId { get; set; }
    }
}