﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WishMaster.Service.Entities;
using WishMaster.Service.Services;

namespace WishMaster.Web.Controllers
{
    public class BaseController : Controller
    {
        public User MyUser { get; set; }
        public WishMasterDataContext Db { get; set; }

        //Services // Todo: Use a dependency injection library
        public UserService UserService { get; set; }
        public ProductService ProductService { get; set; }
        public CardService CardService { get; set; }

        public BaseController()
        {
            Db = new WishMasterDataContext();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            // Set Services 
            UserService = new UserService(Db);
            CardService = new CardService(Db, UserService);
            ProductService = new ProductService(Db, CardService);

            // demo buyer account
            MyUser = UserService.GetUserByNick("emre");
            ViewBag.User = MyUser;

            base.Initialize(requestContext);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}