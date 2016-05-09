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
    public partial class DuLieuDichBenhs : System.Web.UI.UserControl
    {
        WebAdicom.DulieuDichbenhDataTable datatable;
        private Adicom.Web.Code.DulieuDichbenhController dulieuDichbenhController = new Adicom.Web.Code.DulieuDichbenhController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadData();
            }
        }
        public void LoadData()
        {
            try
            {
                if (Session["Idbenhvien"] != null)
                    datatable = dulieuDichbenhController.GetDataByIdbenhvien(Convert.ToInt32(Session["Idbenhvien"].ToString()));
                if (datatable.Count > 0)
                {
                    gvNews.DataSource = datatable;
                    gvNews.DataBind();
                }
            }
            catch { }
        }
        protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(e.CommandArgument.ToString());
                if (Id != null)
                {
                    WebAdicom.DulieuDichbenhRow row = dulieuDichbenhController.GetDataById(Id);
                    //WebUtils.deleImage(row.picture);
                    dulieuDichbenhController.DeleteId(Id);
                }
                gvNews.DataBind();
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