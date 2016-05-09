using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Localization;

namespace Adicom.Web.Controls
{
    public partial class UCNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                string s = Request["type"];
                if (string.IsNullOrEmpty(s)) s = "1";
                Page.Title = "type" + s;
                (Page.Master.FindControl("ltTitleMain") as Literal).Text = ResourceManager.GetString("type" + s);
            }
        }

        protected void rptNew_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HyperLink hpl1 = (e.Item.FindControl("hplMore") as HyperLink);
                HyperLink hpl2 = (e.Item.FindControl("hplImg") as HyperLink);
                hpl1.NavigateUrl = string.Format(hpl1.NavigateUrl, DataBinder.Eval(e.Item.DataItem, "id"));
                hpl2.NavigateUrl = string.Format(hpl2.NavigateUrl, DataBinder.Eval(e.Item.DataItem, "id"));
            }
        }
    }
}