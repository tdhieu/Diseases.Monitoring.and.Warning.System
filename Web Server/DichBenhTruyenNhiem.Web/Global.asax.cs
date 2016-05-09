using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Globalization;
using System.Threading;

namespace Adicom.Web
{
    public class Global : System.Web.HttpApplication
    {
        public static int VisitorsOnline = 0;

        private static string vi_path = "/vi";
        private static string en_path = "/en";
       
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["ActiveVisitor"] = 0;

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

       

        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

            Application.Lock();
            ++VisitorsOnline;
            Application["ActiveVisitor"] = VisitorsOnline;
            Application.UnLock();

        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            Application.Lock();
            --VisitorsOnline;
            Application["ActiveVisitor"] = VisitorsOnline;
            Application.UnLock();
        }
    }
}