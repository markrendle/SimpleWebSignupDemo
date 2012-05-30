using System.Linq;
using System.Web;

namespace AwesomeThing.Admin
{
    using Simple.Web;

    [UriTemplate("/admin")]
    public abstract class AdminBase : IRequireAuthentication
    {
        public IUser CurrentUser { get; set; }
    }
}