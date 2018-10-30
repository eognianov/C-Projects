using System;
using System.Collections.Generic;
using System.Text;
using MishMash.Data;
using SIS.MvcFramework;

namespace MishMash.Controllers
{
    public class BaseController:Controller
    {
        public BaseController()
        {
            this.Db = new ApplicationDbContext();
        }

        protected ApplicationDbContext Db { get; }
    }

    
}
