using System.Web.Optimization;

namespace IE_Clinics
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Start/jquery.min.js",
                        "~/Scripts/Start/popper.js",
                        "~/Scripts/Start/jquery.blockui.min.js",
                        "~/Scripts/Start/jquery.slimscroll.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                        "~/Scripts/DataTable/jquery.dataTables.min.js",
                        "~/Scripts/DataTable/dataTables.bootstrap4.min.js",
                        "~/Scripts/DataTable/table_data.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/common").IncludeDirectory(
                        "~/Scripts/Common", "*.js", false
                        ));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                        "~/Scripts/material.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-switch.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                      "~/Scripts/Fullcalendar/moment.min.js",
                      "~/Scripts/Fullcalendar/fullcalendar.min.js",
                      "~/Scripts/Fullcalendar/fullcalendarSettings.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/simple-line-icons.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/DataTable/dataTables.bootstrap4.min.css",
                "~/Content/Material/material.min.css",
                "~/Content/Material/material_style.css",
                "~/Content/Fullcalendar/fullcalendar.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Theme-Styles").Include(
                "~/Content/Theme/theme_style.css",
                "~/Content/Theme/style.css",
                "~/Content/Theme/plugins.min.css",
                "~/Content/Theme/responsive.css",
                "~/Content/Theme/theme-color.css"
                ));

            //bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
            //    "~/Content/Fullcalendar/fullcalendar.css"
            //    ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
