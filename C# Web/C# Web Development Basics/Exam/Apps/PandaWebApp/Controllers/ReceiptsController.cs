using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandaWebApp.ViewModels.Packages;
using PandaWebApp.ViewModels.Receipts;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers
{
    public class ReceiptsController:BaseController
    {
        [Authorize]
        public IHttpResponse Index()
        {
            var receipts = this.Db.Receipts.Where(x => x.Recipient.Username == this.User.Username).Select(x=>new ReceiptViewModel
            {
                Id = x.Id,
                Fee = x.Fee,
                IssuedOn = x.IssuedOn.ToString(),
                Recipient = x.Recipient.Username
            }).ToList();

            var model = new ListOfReceiptsViewModel
            {
                Receipts = receipts
            };

            return this.View(model);
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var receipt = this.Db.Receipts.FirstOrDefault(x => x.Id == id);

            if (receipt==null)
            {
                return this.BadRequestError("Invalid receipt");
            }

            if (receipt.Recipient.Username!=this.User.Username)
            {
                return this.Redirect("/");
            }

            var packageFromDb = this.Db.Packages.FirstOrDefault(x => x.Id == receipt.PackageId);

            var packageViewModel = new PackageDetailsViewModel
            {
                Address = packageFromDb.ShippingAddress,
                Description = packageFromDb.Description,
                Recipient = packageFromDb.Recipient.Username,
                Weight = packageFromDb.Weight
            };

            var receiptViewModel = new DetailsReceiptViewModel
            {
                Id = receipt.Id,
                Fee = receipt.Fee,
                IssuedOn = receipt.IssuedOn.ToString(),
                Package = packageViewModel
            };

            return this.View(receiptViewModel);
        }

        
    }
}
