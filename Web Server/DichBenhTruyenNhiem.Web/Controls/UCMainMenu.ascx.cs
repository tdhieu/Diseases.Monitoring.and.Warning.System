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
    public partial class UCMainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void mnuMain_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            e.Item.ImageUrl = ((SiteMapNode)e.Item.DataItem)["url"];
            e.Item.Text = ResourceManager.GetString(((SiteMapNode)e.Item.DataItem)["tag"]);
            e.Item.ToolTip = ResourceManager.GetString(((SiteMapNode)e.Item.DataItem)["tag"]);
        }
    }
}