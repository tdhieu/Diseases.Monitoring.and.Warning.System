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
using Adicom.Web;
using System.Data;
using System.Data.SqlClient;

namespace Adicom.Web.admin.Modules
{
    public partial class GuiThongBao : System.Web.UI.UserControl
    {
        BenhVienController benhvienController = new BenhVienController();
        int idbenhvien;
        string tenbenhvien;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataSource();
                GetAccount();
            }
        }

        protected void LoadDataSource()
        {
            try
            {
                ListItem iadd = new ListItem("Chọn dữ liệu", "-1");

                WebAdicom.BenhvienDataTable benhvienDataTable = new WebAdicom.BenhvienDataTable();
                benhvienDataTable = benhvienController.GetData();
                ddlBenhVien.DataSource = benhvienDataTable;
                ddlBenhVien.DataValueField = "Idbenhvien";
                ddlBenhVien.DataTextField = "Tenbenhvien";
                ddlBenhVien.DataBind();
                ddlBenhVien.Items.Insert(0, iadd);

                ListItem item;
                for (int i = 1; i < 6; i++)
                {
                    item = new ListItem();
                    item.Value = i.ToString();
                    item.Text = "Cấp " + i;
                    ddlPriority.Items.Add(item);
                }
                ddlPriority.Items.Insert(0, iadd);
            }
            catch { }
        }

        protected void GetAccount()
        {
            idbenhvien = Convert.ToInt16(Session["Idbenhvien"]);
            tenbenhvien = Session["NameBenhVien"].ToString();
            txtNoiGui.Text = tenbenhvien;
            ViewState["NoiGui"] = idbenhvien;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                idbenhvien = Convert.ToInt16(ViewState["NoiGui"]);
                SqlConnection sqlcon = new SqlConnection(benhvienController.connectionString);
                string query = "Insert Into BC_ThongBao(idnoigui,ngaygui,trangthai,noidung,"
                             + "mucdo,idnoinhan,tieude,tennoigui,tennoinhan) "
                             + "Values (@idnoigui,@ngaygui,@trangthai,@noidung,@mucdo,"
                             + "@idnoinhan,@tieude,@tennoigui,@tennoinhan)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idnoigui", idbenhvien);
                sqlcmd.Parameters.AddWithValue("@ngaygui", Convert.ToDateTime(cldNgayThongBao.Value));
                sqlcmd.Parameters.AddWithValue("@trangthai", 0);
                sqlcmd.Parameters.AddWithValue("@noidung", txtNoiDung.Value);
                sqlcmd.Parameters.AddWithValue("@mucdo", Convert.ToInt16(ddlPriority.SelectedItem.Value));
                sqlcmd.Parameters.AddWithValue("@idnoinhan", Convert.ToInt16(ddlBenhVien.SelectedItem.Value));
                sqlcmd.Parameters.AddWithValue("@tieude", txtSubject.Text);
                sqlcmd.Parameters.AddWithValue("@tennoigui", txtNoiGui.Text);
                sqlcmd.Parameters.AddWithValue("@tennoinhan", ddlBenhVien.SelectedItem.Text);

                sqlcon.Open();
                int rows = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                //Response.Redirect();
            }
            catch { }
        }
    }
}