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
    public partial class BenhViens : System.Web.UI.UserControl
    {
        WebAdicom.BenhvienDataTable datatable;
        private Adicom.Web.Code.BenhVienController benhVienController = new Adicom.Web.Code.BenhVienController();
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
            datatable = benhVienController.GetData();
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
            int id =Convert.ToInt32(e.CommandArgument.ToString());
            if (id != null)
                benhVienController.DeleteById(id);
            gvNews.DataBind();
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
            datatable = benhVienController.GetDataByList(idbenhvien);
            if (datatable.Count > 0)
            {
                gvNews.DataSource = datatable;
                gvNews.DataBind();
            }
        }
    }
}