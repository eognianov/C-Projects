using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Responses;

namespace Chuska.Controllers
{
    public class HomeController:BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }
}
