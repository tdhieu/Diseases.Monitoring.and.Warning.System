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
using System.Data;
using System.Data.SqlClient;
using Adicom.Web;
using Adicom.Web.Code;

namespace Adicom.Web.admin.Modules
{
    public partial class MailContent : System.Web.UI.UserControl
    {
        int idthongbao;
        BaseController baseController = new BaseController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                idthongbao = int.Parse(Request.QueryString["id"]);
                ViewState["CurrentAnnounce"] = idthongbao;
                LoadReport();
                UpdateStatus();
            }
        }

        protected void UpdateStatus()
        {
            try
            {
                idthongbao = Convert.ToInt16(ViewState["CurrentAnnounce"]);
                SqlConnection sqlcon = new SqlConnection(baseController.connectionString);
                string query = "Update BC_ThongBao Set trangthai=@trangthai Where idthongbao=@idthongbao";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idthongbao", idthongbao);
                sqlcmd.Parameters.AddWithValue("@trangthai", 1);
                sqlcon.Open();
                int rowEffect = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch { }
        }

        protected void LoadReport()
        {
            try
            {
                idthongbao = Convert.ToInt16(ViewState["CurrentAnnounce"]);
                SqlConnection sqlcon = new SqlConnection(baseController.connectionString);
                string query = "Select * from BC_ThongBao where idthongbao=@idthongbao";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idthongbao", idthongbao);
                SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                DataTable myDataSet = new DataTable();
                adpt.Fill(myDataSet);
                txtSubject.Text = myDataSet.Rows[0]["tieude"].ToString();
                txtNgayThongBao.Text = myDataSet.Rows[0]["ngaygui"].ToString();
                txtDoUuTien.Text = myDataSet.Rows[0]["mucdo"].ToString();
                txtNoiGui.Text = myDataSet.Rows[0]["tennoigui"].ToString();
                txtNoiNhan.Text = myDataSet.Rows[0]["tennoinhan"].ToString();
                ltContent.Text = WebUtils.GetLanguageValue(myDataSet.Rows[0]["noidung"].ToString(), myDataSet.Rows[0]["noidung"].ToString());
            }
            catch { }
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {

        }
    }
}