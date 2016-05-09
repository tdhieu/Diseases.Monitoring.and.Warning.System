using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Adicom.Web.Code;
using Adicom.Web.DAL;

namespace Adicom.Web.admin
{
    public partial class Login : System.Web.UI.Page
    {
        private UsersController usersController = new UsersController(Adicom.Web.Properties.Settings.Default.webadicomConnectionString);
        private WebAdicom.usersDataTable database = new WebAdicom.usersDataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("mnuAdmin").Visible = false;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string hashedPassword =
                FormsAuthentication.HashPasswordForStoringInConfigFile(Login1.Password, "SHA1");
            if (Login1.UserName != "" && Login1.Password != "")
            {
                WebAdicom.usersRow rows = usersController.GetByUserName(Login1.UserName);
                if (rows != null)
                    if (Login1.UserName == rows.user_name && rows.password.Equals(hashedPassword))
                    {
                        Session["roleName"] = rows.role;
                        Session["Idbenhvien"] = rows.idbenhvien;
                        Session["UserName"] = rows.user_name;
                        Session["NameBenhVien"] = rows.tenbenhvien;
                        e.Authenticated = true;
                    }
            }
        }
    }
}
