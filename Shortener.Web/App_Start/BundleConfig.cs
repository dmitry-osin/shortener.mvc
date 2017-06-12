namespace Shortener.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            // Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-{version}"));

            bundles.Add(new ScriptBundle("~/bundles/mainjs")
                .Include("~/Scripts/main.js"));

            // Styles
            bundles.Add(new StyleBundle("~/Content/boottheme")
                .Include("~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/style.css"));
        }

        public static class Paths
        {
            public const string JQueryPath = "~/bundles/jquery";
            public const string JQueryValPath = "~/bundles/jqueryval";
            public const string BootstrapPath = "~/bundles/bootstrap";
            public const string ModernizrPath = "~/bundles/modernizr";
            public const string MainJsPath = "~/bundles/mainjs";

            public const string BootstrapThemePath = "~/Content/boottheme";
            public const string CssPath = "~/Content/css";


        }
    }
}