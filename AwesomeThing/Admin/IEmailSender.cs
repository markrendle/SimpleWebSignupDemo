namespace AwesomeThing.Admin
{
    public interface IEmailSender
    {
        void Send(Email email);
    }

    public class DummyEmailSender : IEmailSender
    {
        public void Send(Email email)
        {
        }
    }
}