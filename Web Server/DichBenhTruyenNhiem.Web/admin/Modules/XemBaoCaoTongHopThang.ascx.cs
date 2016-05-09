using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;
using Adicom.Web.Code;
using DevExpress.Web.ASPxEditors;
using System.Drawing;

namespace Adicom.Web.admin.Modules
{
    public partial class XemBaoCaoTongHopThang : System.Web.UI.UserControl
    {
        DataTable dtBaoCao, table, dtSoLieu;
        int idbaocao;
        private BaoCaoTongHopThangController BaoCaoTongHopThangController = new BaoCaoTongHopThangController();
        private GetDataController GetDataController = new GetDataController();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    idbaocao = int.Parse(Request.QueryString["id"]);
                    InitGridView();
                    LoadDataSource();
                    LoadReport();
                }
            }
            catch { }
        }

        protected void InitGridView()
        {
            try
            {
                table = new DataTable();
                table.Columns.Add(new DataColumn("TenDiaPhuong", typeof(System.String))); //ten dia phuong
                table.Columns.Add(new DataColumn("TenDichBenh", typeof(System.String))); //ten dich benh
                table.Columns.Add(new DataColumn("SoCaMac", typeof(System.Int16))); //so ca mac
                table.Columns.Add(new DataColumn("SoCaChet", typeof(System.Int16))); //so ca tu vong

                grvDuLieu.HorizontalAlign = HorizontalAlign.Center;

                grvDuLieu.DataSource = table;
                grvDuLieu.DataBind();
                ViewState["GridView"] = table;
            }
            catch { }
        }

        protected void LoadDataSource()
        {
            dtBaoCao = new DataTable();
            dtSoLieu = new DataTable();
            try
            {
                SqlConnection sqlcon = new SqlConnection(BaoCaoTongHopThangController.connectionString);
                string query = "Select * "
                             + "From BC_BaoCaoThangTongHop "
                             + "Where idbaocao=@idbaocao";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcon.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                adpt.Fill(dtBaoCao);
                sqlcon.Close();
                ViewState["BaoCao"] = dtBaoCao;

                query = "Select * "
                      + "From BC_SolieuBaoCaoThangTongHop "
                      + "Where idbaocao=@idbaocao "
                      + "Order by iddiaphuong ";
                sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcon.Open();
                adpt = new SqlDataAdapter(sqlcmd);
                adpt.Fill(dtSoLieu);
                sqlcon.Close();
                ViewState["SoLieu"] = dtSoLieu;
            }
            catch { }
        }

        protected void LoadReport()
        {
            try
            {
                dtBaoCao = (DataTable)ViewState["BaoCao"];
                txtThang.Text = dtBaoCao.Rows[0][2].ToString();
                txtNam.Text = dtBaoCao.Rows[0][3].ToString();
                txtNgayBaoCao.Text = dtBaoCao.Rows[0][4].ToString();
                txtMaBaoCao.Text = dtBaoCao.Rows[0][1].ToString();
                txtNoiBaoCao.Text = GetDataController.GetHospitalName(dtBaoCao.Rows[0][8]);
                txtNguoiBaoCao.Text = dtBaoCao.Rows[0][5].ToString();
                ltNhanXet.Text = dtBaoCao.Rows[0][6].ToString();
                ltTrienKhai.Text = dtBaoCao.Rows[0][7].ToString();

                dtSoLieu = (DataTable)ViewState["SoLieu"];
                table = (DataTable)ViewState["GridView"];
                DataRow row;
                for (int i = 0; i < dtSoLieu.Rows.Count; i++)
                {
                    row = table.NewRow();
                    row[0] = GetDataController.GetDistrictName(dtSoLieu.Rows[i][2]);
                    row[1] = GetDataController.GetDiseaseName(dtSoLieu.Rows[i][1]);
                    row[2] = Convert.ToInt16(dtSoLieu.Rows[i][3]);
                    row[3] = Convert.ToInt16(dtSoLieu.Rows[i][4]);
                    table.Rows.Add(row);
                }
                ViewState["GridView"] = table;
                grvDuLieu.DataSource = table;
                grvDuLieu.DataBind();
            }
            catch { }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("XemDanhSachBaoCao.aspx");
        }
    }
}