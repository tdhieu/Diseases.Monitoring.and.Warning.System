using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;

namespace Adicom.Web.Controls
{
    public class BasePage:Page
    {
        public BasePage()
        {
            //

            // TODO: Add constructor logic here

            //
        }

        protected override void InitializeCulture()
        {

            string lang = string.Empty;//default to the invariant culture

            HttpCookie cookie = Request.Cookies["language"];

            if (cookie != null && cookie.Value != null)
            {

                lang = cookie.Value;

                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);

            }

            base.InitializeCulture();

        }
    }
}
