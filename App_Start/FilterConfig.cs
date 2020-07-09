using jsreport.Binary;
using jsreport.Local;
using jsreport.MVC;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace NetWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            var rs = new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .TempDirectory(Path.Combine((string)AppDomain.CurrentDomain.GetData("DataDirectory"), "jsreport-temp"))
                .AsUtility()
                .Create();

            filters.Add(new JsReportFilterAttribute(rs));
            filters.Add(new HandleErrorAttribute());
        }
    }
}
