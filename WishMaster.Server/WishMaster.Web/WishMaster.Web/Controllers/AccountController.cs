using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishMaster.Service.ViewModels;

namespace WishMaster.Web.Controllers
{
    public class AccountController : Controller
    {

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var result = new LoginResult() { Success = true };
            if (string.IsNullOrEmpty(model.username) || string.IsNullOrEmpty(model.password))
            {
                result.Success = false;
            }
            return Json(result);
        }

        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult UserInfo()
        {
            return View();
        }
    }
}