using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LibraryManagement.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Alljs").Include(
                        "~/Script/jquery-3.6.0.js",
                        "~/Script/bootstrap.bundle.js",
                        "~/Script/jquery.validate.js",
                        "~/Script/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new StyleBundle("~/bundles/Allcss").Include(
                        "~/Content/bootstrap.css"));

        }

    }
}