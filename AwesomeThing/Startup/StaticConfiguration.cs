namespace AwesomeThing.Startup
{
    using Simple.Web;

    public class StaticConfiguration : IStartupTask
    {
        public void Run(IConfiguration configuration, IWebEnvironment environment)
        {
            configuration.PublicFolders.Add("/css");
            configuration.PublicFolders.Add("/images");
            configuration.PublicFolders.Add("/Scripts");
        }
    }
}