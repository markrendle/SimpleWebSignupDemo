using System.Linq;
using System.Web;

namespace AwesomeThing.Admin
{
    using Simple.Web;
    using Simple.Web.Authentication;
    using Simple.Web.Behaviors;

    [UriTemplate("/admin")]
    public abstract class AdminBase : IRequireAuthentication
    {
        public IUser CurrentUser { get; set; }
    }
}