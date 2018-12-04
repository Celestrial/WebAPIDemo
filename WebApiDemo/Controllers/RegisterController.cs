using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class RegisterController : ApiController
    {
        // GET: api/todo
        public IQueryable<Register> Get()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity("sean.celestrial@gmail.com"), null);
            return null;
        }
    }
}
