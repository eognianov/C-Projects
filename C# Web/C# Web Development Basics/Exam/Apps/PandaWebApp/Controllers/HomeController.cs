namespace PandaWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                //var products = this.Db.Products.Select(
                //    x => new ProductViewModel
                //    {
                //        Id = x.Id,
                //        Name = x.Name,
                //        Price = x.Price,
                //        Description = x.Description,
                //    }).ToList();
                //var model = new IndexViewModel
                //{
                //    Products = products,
                //};

                if (this.User.Role=="Admin")
                {
                    return this.View("Home/IndexAdmin");
                }

                return this.View("Home/IndexLoggedIn");
            }

            return this.View();
        }
    }
}
