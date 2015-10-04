using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WishMaster.Service.ViewModels;

namespace WishMaster.Web.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        /// <summary>
        /// This method is for web login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            int LOGIN_DURATION_DAYS = 5;
            var result = UserService.TryLogin(model);
            if (result.Success == true)
            {
                var user = UserService.GetUserById(result.UserId);
                var token = string.Format("{0}~{1}", user.Nick, user.Id);
                var ticket = new FormsAuthenticationTicket(
                      4,
                      token,
                      DateTime.Now,
                      DateTime.Now.AddDays(LOGIN_DURATION_DAYS),
                      false,
                      Request.UserHostAddress,   // some unique data
                      "/");

                var encTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie("wishmaster", encTicket)
                {
                    HttpOnly = true,
                    Secure = FormsAuthentication.RequireSSL,
                    Expires = DateTime.Now.AddDays(LOGIN_DURATION_DAYS)
                };
                Response.Cookies.Remove("wishmaster");
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


        /// <summary>
        /// This method is for mobile login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MobileLogin(LoginModel model)
        {
            var result = UserService.TryLogin(model, true);
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