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
    public partial class UCServices : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                string c = Request["cat"];
                string t = Request["type"];
                string s = "";
                if (string.IsNullOrEmpty(c)) c = "1";
                if (string.IsNullOrEmpty(t)) t = "1";

                if (t.Equals("1"))
                    s = "productcat";
                else
                    s = "servicecat";
                Page.Title = s + c;
                (Page.Master.FindControl("ltTitleMain") as Literal).Text = ResourceManager.GetString(s + c);
            }
        }

        protected void rptServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
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