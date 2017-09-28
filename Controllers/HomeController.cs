using jsreport.MVC;
using jsreport.Types;
using NetWebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [EnableJsReport()]
        public ActionResult Invoice()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.PhantomPdf);

            return View(InvoiceModel.Example());
        }

        [EnableJsReport()]
        public ActionResult InvoiceDownload()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.PhantomPdf)
                .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = "attachment; filename=\"myReport.pdf\"");

            return View("Invoice", InvoiceModel.Example());
        }

        [EnableJsReport()]
        public ActionResult InvoiceWithHeader()
        {
            HttpContext.JsReportFeature()
                .Recipe(Recipe.PhantomPdf)
                .Configure((r) => r.Template.Phantom = new Phantom { Header = this.RenderViewToString("Header", new { }) });

            return View("Invoice", InvoiceModel.Example());
        }

        [EnableJsReport()]
        public ActionResult Items()
        {
            HttpContext.JsReportFeature()
                .Recipe(Recipe.HtmlToXlsx);

            return View(InvoiceModel.Example());
        }

        [EnableJsReport()]
        public ActionResult ItemsExcelOnline()
        {
            HttpContext.JsReportFeature()
                .Configure(req => req.Options.Preview = true)
                .Recipe(Recipe.HtmlToXlsx);

            return View("Items", InvoiceModel.Example());
        }

        [EnableJsReport()]
        public ActionResult InvoiceDebugLogs()
        {
            HttpContext.JsReportFeature()
                .DebugLogsToResponse()
                .Recipe(Recipe.PhantomPdf);

            return View("Invoice", InvoiceModel.Example());
        }
    }
}