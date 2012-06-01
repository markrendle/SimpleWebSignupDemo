using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeThing.Startup
{
    using Admin;
    using Ninject.Modules;
    using Simple.Web;
    using Simple.Web.Authentication;

    public class DependencySetup : Simple.Web.Ninject.NinjectStartupBase
    {
        protected override IEnumerable<INinjectModule> CreateModules()
        {
            yield return new Module();
        }

        class Module : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IEmailSender>().To<DummyEmailSender>();
                Kernel.Bind<IAuthenticationProvider>().To<DefaultAuthenticationProvider>();
            }
        }
    }
}