using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using Microsoft.AspNet.WebHooks;

namespace WebApplication8.Controllers
{
	[Authorize]
	public class NotifyController : Controller
    {

        // GET: Notify
        public ActionResult Index()
        {
	        return new JsonResult();
        }

        [HttpPost]
        public async Task<ActionResult> Submit()
        {
	        // Create an event with action 'event1' and additional data
	        await this.NotifyAsync("event1", new { P1 = "p1" });

	        return new EmptyResult();
        }
	}
}