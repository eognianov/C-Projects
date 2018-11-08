using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PandaWebApp.Models;
using PandaWebApp.ViewModels.Packages;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers
{
    public class PackagesController:BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package==null)
            {
                return this.BadRequestError("Invalid package id");
            }
            if (package.Recipient.Username!=this.User.Username)
            {
                return this.Redirect("/");
            }

            var packageModel = new PackageDetailsViewModel
            {
                Description = package.Description,
                Status = package.Status.ToString(),
                Weight = package.Weight,
                Recipient = package.Recipient.Username,
                Address = package.ShippingAddress
            };

            if (package.Status==PackageStatus.Shipped)
            {
                packageModel.EstimatedDeliveryDate = package.EstimatedDeliveryDate.ToString();
            }

            if (package.Status==PackageStatus.Pending)
            {
                packageModel.EstimatedDeliveryDate = "N/A";
            }

            if (package.Status == PackageStatus.Delivered)
            {
                packageModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(packageModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            var users = this.Db.Users.Select(x => new CreatePackageUserViewModel
            {
                Id = x.Id,
                Username = x.Username
            }).ToList();

            var model = new ListOfUsersViewModel{Users = users};

            return this.View(model);
        }


        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(DoCreateViewModel model)
        {
            var package = new Package
            {
                Description = model.Description,
                UserId = int.Parse(model.userId),
                ShippingAddress = model.ShippingAddress,
                Status = PackageStatus.Pending,
                Weight = double.Parse(model.Weight)
            };

            this.Db.Packages.Add(package);
            this.Db.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Pending()
        {
            var packages = this.Db.Packages.Where(x => x.Status == PackageStatus.Pending).Select(x =>
                new PackageDetailsViewModel
                {
                    Id = x.Id,
                    Address = x.ShippingAddress,
                    Description = x.Description,
                    Recipient = x.Recipient.Username,
                    Weight = x.Weight
                }).ToList();

            var model = new ListOfPackagesViewModel{Packages = packages};
            return this.View(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Shipped()
        {
            var packages = this.Db.Packages.Where(x => x.Status == PackageStatus.Shipped).Select(x =>
                new PackageDetailsViewModel
                {
                    Id = x.Id,
                    EstimatedDeliveryDate = x.EstimatedDeliveryDate.ToString(),
                    Description = x.Description,
                    Recipient = x.Recipient.Username,
                    Weight = x.Weight
                }).ToList();

            var model = new ListOfPackagesViewModel{Packages = packages};
            return this.View(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Delivered()
        {
            var packages = this.Db.Packages.Where(x => x.Status == PackageStatus.Delivered).Select(x =>
                new PackageDetailsViewModel
                {
                    Id = x.Id,
                    EstimatedDeliveryDate = x.EstimatedDeliveryDate.ToString(),
                    Description = x.Description,
                    Recipient = x.Recipient.Username,
                    Address = x.ShippingAddress,
                    Weight = x.Weight
                }).ToList();

            var model = new ListOfPackagesViewModel{Packages = packages};
            return this.View(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Ship(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package==null)
            {
                return this.BadRequestError("invalid package");
            }

            package.Status = PackageStatus.Shipped;

            Random rand = new Random();
            var rndDays = rand.Next(minValue: 20, maxValue: 40);

            package.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(rndDays);

            this.Db.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Deliver(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package==null)
            {
                return this.BadRequestError("invalid package");
            }

            package.Status = PackageStatus.Delivered;


            this.Db.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse Acquire(int id)
        {
            decimal FEE_CONSTAT = decimal.Parse("2.57");
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package==null)
            {
                return this.BadRequestError("invalid package");
            }

            if (package.Recipient.Username!=this.User.Username)
            {
                return this.Redirect("/");
            }

            package.Status = PackageStatus.Acquired;

            var resipiet = new Receipt
            {
                Fee = decimal.Parse(package.Weight.ToString())*FEE_CONSTAT,
                PackageId = package.Id,
                IssuedOn = DateTime.UtcNow,
                UserId = package.UserId
            };

            this.Db.Receipts.Add(resipiet);
            this.Db.SaveChanges();

            return this.Redirect("/");
        }
    }
}
