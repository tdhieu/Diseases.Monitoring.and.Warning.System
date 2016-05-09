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
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string s = ResourceManager.GetString(Page.Header.Title);
            string title = string.Format(ResourceManager.GetString("title"), string.IsNullOrEmpty(s)?Page.Header.Title:s);
            Page.Header.Title = title;
          
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string s = ResourceManager.GetString(Page.Header.Title);
            ltTitleMain.Text = string.IsNullOrEmpty(s) ? Page.Header.Title : s;
            
        }

    }
}
