using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WishMaster.Service.Entities;
using WishMaster.Service.ViewModels;

namespace WishMaster.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(long categoryId = 0)
        {
            var productQuery = Db.Products.Include(p => p.Category).Include(p => p.Seller).Include(x=>x.Seller.Cards).AsQueryable();
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

        [HttpGet]
        public ActionResult ProductDetail(long id)
        {
            var productQuery = Db.Products.Include(p => p.Category).Include(p => p.Seller).Include(x => x.Seller.Cards).AsQueryable();
            var product = productQuery.FirstOrDefault(x=>x.Id == id);
            return View(product);
        }

    }
}