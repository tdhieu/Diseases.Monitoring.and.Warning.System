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
using Adicom.Web.DAL;
using Adicom.Web.Code;

namespace Adicom.Web.admin.Modules
{
    public partial class Catalogs : System.Web.UI.UserControl
    {
        private ProductController productController = new ProductController(Adicom.Web.Properties.Settings.Default.webadicomConnectionString);
        public int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCatalogs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Id = Convert.ToInt32(e.CommandArgument.ToString());
                if (Id != null)
                    productController.deleteProduct(Id);
                gvCatalogs.DataBind();
            }
            catch { }

        }

        protected void gvCatalogs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DropDownList dls = e.Row.FindControl("dlCategorys") as DropDownList;
                dls.SelectedValue = DataBinder.Eval(e.Row.DataItem, "type").ToString();
            }
            catch
            {
            }
            try
            {
                 DropDownList tam = e.Row.FindControl("dlCategorys") as DropDownList;
                DropDownList dl = e.Row.FindControl("dlCategory") as DropDownList;
                dl.SelectedValue = DataBinder.Eval(e.Row.DataItem, "category").ToString();
                if (DataBinder.Eval(e.Row.DataItem, "category").ToString() == "1" && tam.SelectedValue=="2")
                    dl.SelectedValue = "3";
                if (DataBinder.Eval(e.Row.DataItem, "category").ToString() == "2" && tam.SelectedValue=="2")
                    dl.SelectedValue = "4";
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