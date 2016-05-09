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
    public partial class UsersContro : System.Web.UI.UserControl
    {
        private UsersController usersController = new UsersController();
        private RoleControl roleControl = new RoleControl();
        private BenhVienController benhVienController = new BenhVienController();
        public WebAdicom.usersDataTable database = new WebAdicom.usersDataTable();
        public WebAdicom.usersRow row = null;
        public WebAdicom.usersRow rowtam = null;
        public string UserName = "";
        public int IdUser = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LtrEror.Visible = false;
                this.LoadCombo();
                drlrole.SelectedIndex = 0;
                drlBenhvien.SelectedIndex = 0;
                this.LoadData();
            }
        }
        public void GetRows()
        {
            try
            {
                if (Request.QueryString["Name"] != null)
                {
                    UserName = Request.QueryString["Name"].ToString();
                    row = usersController.GetByUserName(UserName);
                    IdUser = row.id;
                }
            }
            catch
            { }
        }
        public void LoadCombo()
        {
            try
            {
                WebAdicom.BenhvienDataTable Databasebenhvien = new WebAdicom.BenhvienDataTable();
                Databasebenhvien = benhVienController.GetData();
                drlBenhvien.DataSource = Databasebenhvien;
                drlBenhvien.DataValueField = "Idbenhvien";
                drlBenhvien.DataTextField = "Tenbenhvien";
                drlBenhvien.DataBind();

                WebAdicom.rolesDataTable DataPhanQuyen = new WebAdicom.rolesDataTable();
                DataPhanQuyen = roleControl.GetData();
                drlrole.DataSource = DataPhanQuyen;
                drlrole.DataValueField = "id";
                drlrole.DataTextField = "names";
                drlrole.DataBind();
            }
            catch { }
        }
        public void LoadData()
        {
           
                String MahoaPass = "";
                this.GetRows();
                if (row != null)
                {
                    txtUser.Text = row.user_name;
                    try
                    {
                        drlBenhvien.SelectedValue = row.idbenhvien.ToString();
                    }
                    catch { }
                    try
                    {
                        drlrole.SelectedValue = row.role.ToString();
                    }
                    catch { }
                }
        }
        public void Fefresh()
        {
            txtUser.Text = "";
            txtPass.Text = "";
            drlrole.SelectedIndex = 0;
            drlBenhvien.SelectedIndex = 0;
        }
        public bool GetUserNam(string name)
        {
            rowtam = usersController.GetByUserName(name);
            if (rowtam == null)
                return true;
            else return false;

        }
        public void Save()
        {
            try
            {
                this.GetRows();
                if (IdUser == 0)
                    row = database.NewusersRow();
                row.user_name = txtUser.Text;
                if (txtPass.Text != "")
                    row.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPass.Text, "SHA1");
                else
                    if (txtPass.Text == "" && IdUser == 0)
                    {
                        LtrEror.Visible = true;
                        return;
                    }
                row.role = Convert.ToInt32(drlrole.SelectedValue);
                row.idbenhvien = Convert.ToInt32(drlBenhvien.SelectedValue);
                row.tenbenhvien = drlBenhvien.SelectedItem.Text.ToString();
                usersController.SaveUser(row);
                this.Fefresh();
                Response.Redirect("~/admin/Users.aspx");
            }
            catch { }
        }
    }
}