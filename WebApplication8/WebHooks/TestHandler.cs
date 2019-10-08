using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.WebHooks;

namespace WebApplication8.WebHooks
{
	public class TestHandler : WebHookHandler
	{
		public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
		{
			CustomNotifications data = context.GetDataOrDefault<CustomNotifications>();

			// Get data from each notification in this WebHook
			foreach (IDictionary<string, object> notification in data.Notifications)
			{
				// Process data
				Console.WriteLine(notification.Values.ToString());
			}

			return Task.FromResult(true);
		}
	}
}