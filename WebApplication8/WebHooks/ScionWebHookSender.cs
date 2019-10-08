using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Diagnostics;

namespace WebApplication8.WebHooks
{
	public class ScionWebHookSender : DataflowWebHookSender
	{
		public ScionWebHookSender(ILogger logger) : base(logger)
		{
		}

		public override Task SendWebHookWorkItemsAsync(IEnumerable<WebHookWorkItem> workItems)
		{
			return base.SendWebHookWorkItemsAsync(workItems);
		}
	}
}