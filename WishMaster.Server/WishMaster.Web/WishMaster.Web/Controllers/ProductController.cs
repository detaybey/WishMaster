using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishMaster.Service.ViewModels;

namespace WishMaster.Web.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product

        [HttpPost]
        public ActionResult Add(ProductAddModel model)
        {
            var result = new ProductAddResult();
            if (Request.Files.Count > 0)
            {
                model.file = Request.Files[0];
                var mediaRoot = HttpContext.Server.MapPath("~/Content/products");
                var product = ProductService.Add(MyUser, model, mediaRoot);
                if (product != null)
                {
                    result.Success = true; 
                }
            }
            return Json(result);
        }
    }
}