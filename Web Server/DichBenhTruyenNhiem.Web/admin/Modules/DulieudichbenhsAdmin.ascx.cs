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
    public partial class DulieudichbenhsAdmin : System.Web.UI.UserControl
    {
        private BenhVienController benhVienController = new BenhVienController();
        WebAdicom.DulieuDichbenhDataTable datatable;
        private Adicom.Web.Code.DulieuDichbenhController dulieuDichbenhController = new Adicom.Web.Code.DulieuDichbenhController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Loadata();
                this.LoadCombo();
            }
        }
        public void Loadata()
        {
            datatable = dulieuDichbenhController.GetData();
            gvNews.DataSource = datatable;
            gvNews.DataBind();
        }
        public void LoadCombo()
        {
            try
            {
                WebAdicom.BenhvienDataTable Databasebenhvien = new WebAdicom.BenhvienDataTable();
                Databasebenhvien = benhVienController.GetData();
                DropDownList1.DataSource = Databasebenhvien;
                DropDownList1.DataValueField = "Idbenhvien";
                DropDownList1.DataTextField = "Tenbenhvien";
                DropDownList1.DataBind();

                //WebAdicom.rolesDataTable DataPhanQuyen = new WebAdicom.rolesDataTable();
                //DataPhanQuyen = roleControl.GetData();
                //drlrole.DataSource = DataPhanQuyen;
                //drlrole.DataValueField = "id";
                //drlrole.DataTextField = "names";
                //drlrole.DataBind();
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
        protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            gvNews.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idbenhvien = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
            datatable = dulieuDichbenhController.GetDataByIdbenhvien(idbenhvien);
            if (datatable.Count > 0)
            {
                gvNews.DataSource = datatable;
                gvNews.DataBind();
            }
        }
    }
}