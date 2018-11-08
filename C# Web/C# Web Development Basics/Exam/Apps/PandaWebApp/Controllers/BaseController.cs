using PandaWebApp.Data;

namespace PandaWebApp.Controllers
{
    using SIS.MvcFramework;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new ApplicationDbContext();
        }

        public ApplicationDbContext Db { get; }
    }
}
