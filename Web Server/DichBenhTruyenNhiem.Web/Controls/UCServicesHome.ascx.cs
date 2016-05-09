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

namespace Adicom.Web.Controls
{
    public partial class UCServicesHome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rptRandomServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HyperLink hpl = (e.Item.FindControl("hplMore") as HyperLink);
                hpl.NavigateUrl = string.Format(hpl.NavigateUrl, DataBinder.Eval(e.Item.DataItem, "id"));
            }
        }
    }
}