using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WishMaster.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        [HttpPost]
        public void Add()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var tempPath = @"O:/Temp/KaanGonderdi.jpg";

                    if (System.IO.File.Exists(tempPath))
                    {
                        System.IO.File.Delete(tempPath);
                    }

                    file.SaveAs(tempPath);
                }
            }
        }
    }
}