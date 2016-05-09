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
    public partial class Users : System.Web.UI.UserControl
    {
        public WebAdicom.usersDataTable database = new WebAdicom.usersDataTable();
        private BenhVienController benhVienController = new BenhVienController();
        private Adicom.Web.Code.UsersController usersController = new Adicom.Web.Code.UsersController();
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
            database = usersController.GetData();
            gvNews.DataSource = database;
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
                string Name = e.CommandArgument.ToString();
                if (Name != null)
                {
                    WebAdicom.usersRow row = usersController.GetByUserName(Name);
                    usersController.DeleteById(row.id);
                }
                gvNews.DataBind();
            }
            catch { }
        }

        protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DropDownList dl = e.Row.FindControl("dlquyen") as DropDownList;
                dl.SelectedValue = DataBinder.Eval(e.Row.DataItem, "role").ToString();
            }
            catch { }
        }

        protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            gvNews.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String Name = DropDownList1.SelectedItem.Text.ToString();
            database = usersController.GetByTenBenhVien(Name);
            if (database.Count > 0)
            {
                gvNews.DataSource = database;
                gvNews.DataBind();
            }
        }
    }
}