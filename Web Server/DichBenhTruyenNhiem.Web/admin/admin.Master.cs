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
namespace Adicom.Web.admin
{
    public partial class admin_master : System.Web.UI.MasterPage
    {
        public int role = 0;
        public int roleLogin = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = string.Format(ResourceManager.GetString("title"), ResourceManager.GetString(Page.Header.Title));
            Page.Header.Title = title;
            if (Session["roleName"] != null)
                roleLogin =Convert.ToInt32(Session["roleName"].ToString());
           
        }
        protected void mnuAdmin_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            try
            {
                e.Item.ImageUrl = ((SiteMapNode)e.Item.DataItem)["IconUrl"];
                if (((SiteMapNode)e.Item.DataItem).Roles.Count > 0)
                {
                    role = Convert.ToInt32(((SiteMapNode)e.Item.DataItem).Roles[0]);
                  //  if (roleLogin > role)
                    if (roleLogin != role)
                    {
                        if (roleLogin != 1)
                            e.Item.Enabled = false;
                            //((SiteMapNode)e.Item.DataItem).Url = "";
                            //e.Item.NavigateUrl = "";
                            
                    }
                }
            }
            catch { }
        }
    }
}
