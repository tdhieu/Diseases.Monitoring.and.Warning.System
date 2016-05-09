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
    public partial class news : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                UCNewsDetail1.Visible = false;
                UCNews1.Visible = true;
            }
            else
            {
                UCNewsDetail1.Visible = true;
                UCNews1.Visible = false;
            }
        }
    }
}
