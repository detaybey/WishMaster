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
                var user = UserService.GetUserBySessionId(model.sessionid);
                var product = ProductService.Add(user, model);
                if (product != null)
                {
                    result.Success = true;

                    var mediaRoot = HttpContext.Server.MapPath("~/Content/products");
                    var savePath = System.IO.Path.Combine(mediaRoot, product.Id.ToString() + ".jpg");
                    if (System.IO.File.Exists(savePath))
                    {
                        System.IO.File.Delete(savePath);
                    }
                    Request.Files[0].SaveAs(savePath);
                }
            }
            return Json(result);
        }
    }
}