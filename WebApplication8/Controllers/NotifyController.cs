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
	        await this.NotifyAllAsync("event1", new {P1 = "p1"}, Predicate);

	        return new EmptyResult();
        }

        private string[] arr = new[] {"piotrk@dip.co.uk", "tomekh@dip.co.uk"};

        private bool Predicate(WebHook arg1, string user)
        {
	        return arr.Contains(user);
        }
    }
}