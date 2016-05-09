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
using Adicom.Web.DAL;
using Adicom.Web.Code;

namespace Adicom.Web.admin.Modules
{
    public partial class News : System.Web.UI.UserControl
    {
        private Adicom.Web.Code.NewsController Newscontroler = new Adicom.Web.Code.NewsController();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int Id = Convert.ToInt32(e.CommandArgument.ToString());
                if (Id != null)
                {
                    WebAdicom.newsRow row = Newscontroler.getNewsById(Id);
                    WebUtils.deleImage(row.picture);
                    Newscontroler.deleteNews(Id);
                }
                gvNews.DataBind();
            }
            catch { }

        }

        protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DropDownList dl = e.Row.FindControl("dlCategory") as DropDownList;
                dl.SelectedValue = DataBinder.Eval(e.Row.DataItem, "category").ToString();
            }
            catch { }
        }

        protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            gvNews.DataBind();
        }

         
    }
}