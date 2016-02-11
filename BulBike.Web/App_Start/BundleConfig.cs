using System.Web;
using System.Web.Optimization;

namespace BulBike.Web
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize/materialize.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/chat").Include(
                    "~/Scripts/ui/jquery.ui.core.js",
                    "~/Scripts/ui/jquery.ui.widget.js",
                    "~/Scripts/ui/jquery.ui.mouse.js",
                    "~/Scripts/ui/jquery.ui.draggable.js",
                    "~/Scripts/ui/jquery.ui.resizable.js",
                    "~/Scripts/jquery.signalR-2.2.0.js",
                    "~/signalr/hubs"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize/css/materialize.css",
                       "~/Content/materialize/font/material-design-icons/Material-Design-Icons.svg",
                      "~/Content/site.css",
                      "~/Content/JQueryUI/themes/base/jquery.ui.all.css",
                      "~/Content/ChatStyle.css"));
        }
    }
}
