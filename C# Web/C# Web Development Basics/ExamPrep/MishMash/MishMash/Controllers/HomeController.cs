using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MishMash.Controllers
{
    public class HomeController:BaseController
    {
        [HttpGet("/Home/Index")]
        public IHttpResponse Index()
        {
            if (this.User!=null)
            {
                return this.View("Home/LoggedInIndex");
            }
            else
            {
                return this.View("Home/Index");
            }
        }

        [HttpGet("/")]
        public IHttpResponse RootIndex()
        {
            return this.Index();
        }
    }
}
