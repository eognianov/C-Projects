using Chuska.Data;
using SIS.MvcFramework;

namespace Chuska.Controllers
{
    public class BaseController:Controller
    {
        public BaseController()
        {
            this.Db = new ApplicationDbContext();  
        }

        public ApplicationDbContext Db { get; set; }
    }
}