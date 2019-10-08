using System;
using System.Web.Http;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Services;
using Newtonsoft.Json.Linq;

namespace WebApplication8.Controllers
{
    public class WebhooksController : ApiController
    {
	    [HttpPost]
		public IHttpActionResult Register([FromBody] JObject registration)
        {
	        dynamic obj = registration;
			
			var webHook = new WebHook()
	        {
		        Description = "Foo",
		        Id = Guid.NewGuid().ToString(),
		        Filters = { "event1" },
				WebHookUri = new Uri("https://localhost:44354/api/values/incoming/scion")
			};

	        var _store = CustomServices.GetStore();

			_store.InsertWebHookAsync(obj.user ?? RequestContext.Principal.Identity.Name, webHook);

	        return CreatedAtRoute("Get", new {id = webHook.Id}, webHook);
        }

		[HttpDelete]
		public void Register()
		{
			var _store = CustomServices.GetStore();
			
			_store.DeleteAllWebHooksAsync(RequestContext.Principal.Identity.Name);
		}

		[Route("{id}", Name = "Get")]
        public IHttpActionResult Get(string id)
        {
	        var webHook = new WebHook()
	        {
		        Description = "Foo",
		        Id = Guid.NewGuid().ToString(),
		        Filters = {"event1", "event2"},
		        WebHookUri = new Uri("http://localhost:63090/api/webhooks/incoming/scion"),
		        Secret = "12345678901234567890123456789012"
	        };

	        return Ok(webHook);
        }
    }
}
