namespace AwesomeThing
{
    using Simple.Web;

    [UriTemplate("/")]
    public class Index : IGet
    {
        public Status Get()
        {
            return 200;
        }
    }
}