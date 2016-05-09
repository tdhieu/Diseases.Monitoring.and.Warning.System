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
    public partial class UCPartner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                string t = Request["type"];
                string s = "";
                if (string.IsNullOrEmpty(t)) t = "1";

                if (t.Equals("1"))
                    s = "partnertitle";
                else
                    s = "client";
                Page.Title = s;
                (Page.Master.FindControl("ltTitleMain") as Literal).Text = ResourceManager.GetString(s);
            }
        }

        protected void rptPartner_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
            }
        }
    }
}