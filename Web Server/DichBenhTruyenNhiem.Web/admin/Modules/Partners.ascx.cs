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
using Adicom.Web.Code;
using Adicom.Web.DAL;

namespace Adicom.Web.admin.Modules
{
    public partial class Partners : System.Web.UI.UserControl
    {
        private PartnerController partnerController = new PartnerController(Adicom.Web.Properties.Settings.Default.webadicomConnectionString);
        public int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Id = Convert.ToInt32(e.CommandArgument.ToString());
                if (Id != null)
                    partnerController.deletePartner(Id);
                gvNews.DataBind();
            }
            catch { }
        }

        protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            try
            {
                DropDownList dls = e.Row.FindControl("dlty") as DropDownList;
                dls.SelectedValue = DataBinder.Eval(e.Row.DataItem, "type").ToString();
            }
            catch
            {
            }
        }

        protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            gvNews.DataBind();
        }
    }
}