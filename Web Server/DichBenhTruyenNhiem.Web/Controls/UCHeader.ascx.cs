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

namespace Adicom.Web.Controls
{
    public partial class UCHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltHeaderSiteName.Text = ResourceManager.GetString("sitename");
            ltHeaderSlogan.Text = ResourceManager.GetString("slogan");
        }
    }
}