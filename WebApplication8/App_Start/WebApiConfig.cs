using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Config;
using Microsoft.AspNet.WebHooks.Diagnostics;
using WebApplication8.WebHooks;

namespace WebApplication8
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
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
			IWebHookManager manager = new MyWebhookManager(store, logger, new TimeSpan[] { }, null);

			// Register WebHookManager with Autofac 
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterInstance(manager).As<IWebHookManager>().SingleInstance();

			// Register MVC and Web API controllers with Autofac
			Assembly currentAssembly = Assembly.GetExecutingAssembly();
			builder.RegisterApiControllers(currentAssembly);
			builder.RegisterControllers(currentAssembly);

			// Build the Autofac container and set it as the dependency resolver for both MVC and Web API
			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

		}
    }
}
