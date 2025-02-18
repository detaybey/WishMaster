﻿using System.Web;
using System.Web.Optimization;

namespace WishMaster.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*")); 

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/JSlibraries").Include(
                       //"~/Scripts/angular.js",
                       //"~/Scripts/angular-signalr-hub.js",
                       "~/Scripts/semantic.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/js").Include(
            //          "~/js/app.js",
            //          "~/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/semantic.css",
                      "~/Content/site.css"));
        }
    }
}
