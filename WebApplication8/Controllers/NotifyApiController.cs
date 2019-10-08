using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Services;
using WebApplication8.WebHooks;

namespace WebApplication8.Controllers
{
	[System.Web.Http.Authorize]
	public class NotifyApiController : ApiController
    {
	    public async Task<int> Post()
	    {
		    return await this.NotifyAllAsync("event2", new {P1 = "p1"});
	    }
    }
}
