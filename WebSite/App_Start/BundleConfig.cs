using System.Web;
using System.Web.Optimization;

namespace WebSite
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                                                                 "~/Content/jqx.base.css"
                                                                 ));



            bundles.Add(new ScriptBundle("~/bundles/jqwidgets").Include(
                                  "~/Scripts/jqxcore.js",
                                  "~/Scripts/jqxtabs.js",
                                  "~/Scripts/jqxdata.js",
                                  "~/Scripts/jqxgrid.js",
                                  "~/Scripts/jqxgrid.selection.js",
                                  "~/Scripts/jqxgrid.pager.js",
                                  "~/Scripts/jqxlistbox.js",
                                  "~/Scripts/jqxbuttons.js",
                                  "~/Scripts/jqxscrollbar.js",
                                  "~/Scripts/jqxdatatable.js",
                                  "~/Scripts/jqxtreegrid.js",
                                  "~/Scripts/jqxmenu.js",
                                  "~/Scripts/jqxcalendar.js",
                                  "~/Scripts/jqxgrid.sort.js",
                                  "~/Scripts/jqxgrid.filter.js",
                                  "~/Scripts/jqxdatetimeinput.js",
                                  "~/Scripts/jqxdropdownlist.js",
                                  "~/Scripts/jqxslider.js",
                                  "~/Scripts/jqxeditor.js",
                                  "~/Scripts/jqxinput.js",
                                  "~/Scripts/jqxdraw.js",
                                  "~/Scripts/jqxchart.core.js",
                                  "~/Scripts/jqxchart.rangeselector.js",
                                  "~/Scripts/jqxtree.js",
                                  "~/Scripts/globalize.js",
                                  "~/Scripts/jqxbulletchart.js",
                                  "~/Scripts/jqxcheckbox.js",
                                  "~/Scripts/jqxradiobutton.js",
                                  "~/Scripts/jqxvalidator.js",
                                  "~/Scripts/jqxpanel.js",
                                  "~/Scripts/jqxpasswordinput.js",
                                  "~/Scripts/jqxnumberinput.js",
                                  "~/Scripts/jqxcombobox.js"
                                  ));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


        }
    }
}