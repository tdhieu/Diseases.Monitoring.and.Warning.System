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
using Adicom.Web.Controls;
namespace Adicom.Web
{
    public partial class callcenter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request["name"];
            if (string.IsNullOrEmpty(s)) s = "callcenter";
            this.Title = s;
        }
    }
}
