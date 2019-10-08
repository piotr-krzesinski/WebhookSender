using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

namespace WebApplication8.WebHooks
{
	public class ScionFilterProvider : IWebHookFilterProvider
	{
		private readonly Collection<WebHookFilter> filters = new Collection<WebHookFilter>
		{
			new WebHookFilter { Name = "event1", Description = "This event 1 happened foo."},
			new WebHookFilter { Name = "event2", Description = "This event 2 happened boo."},
		};

		public Task<Collection<WebHookFilter>> GetFiltersAsync()
		{
			return Task.FromResult(this.filters);
		}
	}
}