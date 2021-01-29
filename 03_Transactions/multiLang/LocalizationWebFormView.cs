using System.Web.Mvc;
using System.IO;

namespace _03_Transactions.multiLang
{
    public class LocalizationWebFormView:WebFormView
    {
        internal const string ViewPathKey = "~/App_GlobalResources/";

        public LocalizationWebFormView(string viewPath)
            : base(new ControllerContext(),viewPath)
        {
        }

        public LocalizationWebFormView(string viewPath, string masterPath)
            : base(new ControllerContext(),viewPath, masterPath)
        {
        }

        protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
        {
            // there seems to be a bug with RenderPartial tainting the page's view data
            // so we should capture the current view path, and revert back after rendering
            string originalViewPath = (string)viewContext.ViewData[ViewPathKey];

            viewContext.ViewData[ViewPathKey] = ViewPath;
            base.Render(viewContext, writer);

            viewContext.ViewData[ViewPathKey] = originalViewPath;
        }

        //public override void Render(ViewContext viewContext, TextWriter writer)
        //{
        //    // there seems to be a bug with RenderPartial tainting the page's view data
        //    // so we should capture the current view path, and revert back after rendering
        //    string originalViewPath = (string)viewContext.ViewData[ViewPathKey];

        //    viewContext.ViewData[ViewPathKey] = ViewPath;
        //    base.Render(viewContext, writer);

        //    viewContext.ViewData[ViewPathKey] = originalViewPath;
        //}
    }
}