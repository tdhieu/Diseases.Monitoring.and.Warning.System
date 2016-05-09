using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Localization;

namespace Adicom.Web
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string title = string.Format(ResourceManager.GetString("title"), ResourceManager.GetString(Page.Header.Title));
            Page.Header.Title = title;
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

    }
}
