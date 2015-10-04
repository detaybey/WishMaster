using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WishMaster.Service.Entities;
using WishMaster.Service.Services;

namespace WishMaster.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var migratorConfig = new WishMaster.Service.Migrations.Configuration();
            var dbMigrator = new System.Data.Entity.Migrations.DbMigrator(migratorConfig);
            dbMigrator.Update();

            using(var db = new WishMasterDataContext())
            {
                var userService = new UserService(db);
                userService.Init();
                var cardService = new CardService(db, userService);
                cardService.Init();
                var scoreService = new ScoreService(db, userService);
                scoreService.Init();
            }
        }
    }
}
