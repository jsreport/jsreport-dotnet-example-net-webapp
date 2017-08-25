using jsreport.Binary;
using jsreport.Local;
using jsreport.MVC;
using System.Web;
using System.Web.Mvc;

namespace NetWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new JsReportFilterAttribute(new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .AsUtility()
                .Create()));
            filters.Add(new HandleErrorAttribute());
        }
    }
}
