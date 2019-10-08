using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Diagnostics;
using WebApplication8.WebHooks;


namespace WebApplication8
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			config.InitializeCustomWebHooks();
			config.InitializeCustomWebHooksSqlStorage();
			config.InitializeCustomWebHooksApis();
			
			ILogger logger = config.DependencyResolver.GetLogger();
			IWebHookStore store = config.DependencyResolver.GetStore();
			IWebHookSender sender = new ScionWebHookSender(logger);

			IWebHookManager manager = new ScionWebhookManager(store, sender, logger);
			
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterInstance(manager).As<IWebHookManager>().SingleInstance();
			builder.RegisterInstance(sender).As<IWebHookSender>().SingleInstance();
			
			Assembly currentAssembly = Assembly.GetExecutingAssembly();
			builder.RegisterApiControllers(currentAssembly);
			builder.RegisterControllers(currentAssembly);
			
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
    }
}
