using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TicketPurchasingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
            Session["AvailableS_ChairTicket"] = 1000;
            Session["AvailableACTicket"] = 100;
            Session["NumberOfS_ChairPendingTicket"] = 0;
            Session["NumberOfS_ChairSoldTicket"] = 0;
            Session["NumberOfACPendingTicket"] = 0;
            Session["NumberOfACSoldTicket"] = 0;
            Session["Persons"] = null;
            Session["ID"] = 0;
            Session["TicketConfirmField"] = null;
            Session["CreateToken"] = null;
        }
    }
}
