using System;
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


        protected override void Initialize(RequestContext requestContext)
        {
            // Set Services 
            Db = new WishMasterDataContext();
            UserService = new UserService(Db);
            MyUser = UserService.GetUserByNick("system");

            base.Initialize(requestContext);
        }

    }
}