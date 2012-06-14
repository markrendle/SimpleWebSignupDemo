namespace AwesomeThing.Startup
{
	using Admin;
	using Ninject.Modules;
	using Simple.Web.Authentication;
	using System.Collections.Generic;

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