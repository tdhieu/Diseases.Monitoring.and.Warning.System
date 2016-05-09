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
using Adicom.Web.DAL;
using Adicom.Web.Code;

namespace Adicom.Web.admin.Modules
{
    public partial class PhoBiens : System.Web.UI.UserControl
    {
        private Adicom.Web.Code.PhoBienController phoBienController = new Adicom.Web.Code.PhoBienController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCatalogs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (id != null)
                {
                    WebAdicom.PhobienRow row = phoBienController.GetDataBayId(id);
                    phoBienController.DeleteId(row.id);
                }
                gvCatalogs.DataBind();
            }
            catch { }
        }

        protected void gvCatalogs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DropDownList dl = e.Row.FindControl("dlCategory") as DropDownList;
                dl.SelectedValue = DataBinder.Eval(e.Row.DataItem, "type").ToString();
            }
            catch { }
        }


        protected void gvCatalogs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCatalogs.PageIndex = e.NewPageIndex;
            gvCatalogs.DataBind();
        }
    }
}