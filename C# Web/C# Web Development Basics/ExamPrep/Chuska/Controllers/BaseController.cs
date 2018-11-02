using Chuska.Data;
using SIS.MvcFramework;

namespace Chuska.Controllers
{
    public abstract class BaseController:Controller
    {
        protected BaseController()
        {
            this.Db = new ApplicationDbContext();  
        }

        public ApplicationDbContext Db { get; set; }
    }
}