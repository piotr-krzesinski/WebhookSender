using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Web;
using System.Web.Http.Tracing;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Diagnostics;

namespace WebApplication8.WebHooks
{
	public class MyWebHookSender : DataflowWebHookSender
	{
		public MyWebHookSender(ILogger logger) : base(logger)
		{
		}

		public MyWebHookSender(ILogger logger, IEnumerable<TimeSpan> retryDelays, ExecutionDataflowBlockOptions options) : base(logger, retryDelays, options)
		{
		}

		public override Task SendWebHookWorkItemsAsync(IEnumerable<WebHookWorkItem> workItems)
		{
			return base.SendWebHookWorkItemsAsync(workItems);
		}
	}


	public class MyWebhookManager : IWebHookManager
	{
		public Task VerifyWebHookAsync(WebHook webHook)
		{
			throw new NotImplementedException();
		}

		public Task<int> NotifyAsync(string user, IEnumerable<NotificationDictionary> notifications, Func<WebHook, string, bool> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<int> NotifyAllAsync(IEnumerable<NotificationDictionary> notifications, Func<WebHook, string, bool> predicate)
		{
			throw new NotImplementedException();
		}
	}
	public class MyFilterProvider : IWebHookFilterProvider
	{
		private readonly Collection<WebHookFilter> filters = new Collection<WebHookFilter>
		{
			new WebHookFilter { Name = "event1", Description = "This event 1 happened."},
			new WebHookFilter { Name = "event2", Description = "This event 2 happened."},
		};

		public Task<Collection<WebHookFilter>> GetFiltersAsync()
		{
			return Task.FromResult(this.filters);
		}
	}
}