using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishMaster.Service.ViewModels;

namespace WishMaster.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(long categoryId = 0)
        {
            var productQuery = Db.Products.AsQueryable();
            if (categoryId > 0)
            {
                productQuery = productQuery.Where(x => x.CategoryId == categoryId);
            }
            productQuery = productQuery.OrderByDescending(x => x.Id);

            var model = new HomePageModel()
            {
                Categories = Db.Categories.ToList(),
                Products = productQuery.ToList(),
                TopUsers = Db.Users.OrderByDescending(x => x.Scores.Sum(y => y.Value)).Take(10).ToList(),
                SelectedCategoryId = categoryId
            };
            return View(model);
        }

        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult ProductDetail()
        {
            return View();
        }

    }
}