namespace RouteExtreme.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/ui/jquery.datetimepicker.full.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize/materialize.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendojs").Include(
                     "~/Scripts/Kendo/kendo.all.min.js",
                     "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/galleryScripts").Include(
                      "~/Scripts/Gallery/jquery.demo.js",
                      "~/Scripts/Gallery/jquery.elastislide.js",
                      "~/Scripts/Gallery/jquerypp.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerychat").Include(
                    "~/Scripts/ui/jquery.ui.core.js",
                    "~/Scripts/ui/jquery.ui.widget.js",
                    "~/Scripts/ui/jquery.ui.mouse.js",
                    "~/Scripts/ui/jquery.ui.draggable.js",
                    "~/Scripts/ui/jquery.ui.resizable.js",
                    "~/Scripts/jquery.signalR-2.2.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/chatjs").Include(
                   "~/Scripts/Chat/chat.js"));

            bundles.Add(new StyleBundle("~/Content/kendo-css").Include(
                     "~/Content/Kendo/kendo.common.min.css",
                     "~/Content/Kendo/kendo.metro.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize/css/materialize.css",
                      "~/Content/materialize/font/material-design-icons/Material-Design-Icons.svg",
                      "~/Content/site.css",
                      "~/Content/JQueryUI/themes/base/jquery.ui.all.css",
                      "~/Content/ChatStyle.css",
                      "~/Content/JQueryUI/jquery.datetimepicker.css",
                      "~/Content/Gallery/custom.css",
                      "~/Content/Gallery/elastislide.css"));
        }
    }
}
