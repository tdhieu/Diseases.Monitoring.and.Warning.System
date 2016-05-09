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
    public partial class XemBaoCaoChiTietThang : System.Web.UI.UserControl
    {
        DataTable dtBaoCao, table, dtSoLieu;
        int idbaocao;
        private BaoCaoChiTietThangController BaoCaoChiTietThangController = new BaoCaoChiTietThangController();
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
                table.Columns.Add(new DataColumn("SoBenhNhanNhiem", typeof(System.Int16))); //so benh nhan nhiem
                table.Columns.Add(new DataColumn("SoCaAcTinh", typeof(System.Int16))); //so ca ac tinh
                table.Columns.Add(new DataColumn("SoCaTuVong", typeof(System.Int16))); //so ca tu vong
                table.Columns.Add(new DataColumn("SoCaXetNghiem", typeof(System.Int16))); //so ca xet nghiem
                table.Columns.Add(new DataColumn("SoCaDuongTinh", typeof(System.Int16))); //so ca duong tinh

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
                SqlConnection sqlcon = new SqlConnection(BaoCaoChiTietThangController.connectionString);
                string query = "Select * "
                             + "From BC_BaoCaoThangChiTiet "
                             + "Where idbaocao=@idbaocao";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcon.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                adpt.Fill(dtBaoCao);
                sqlcon.Close();
                ViewState["BaoCao"] = dtBaoCao;

                query = "Select * "
                      + "From BC_SolieuBaocaoThangChiTiet "
                      + "Where idbaocao=@idbaocao";
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
                txtNgayBaoCao.Text = dtBaoCao.Rows[0][4].ToString();
                txtNgayBatDau.Text = dtBaoCao.Rows[0][2].ToString();
                txtNgayKetThuc.Text = dtBaoCao.Rows[0][3].ToString();
                txtMaBaoCao.Text = dtBaoCao.Rows[0][1].ToString();
                txtNoiBaoCao.Text = GetDataController.GetHospitalName(dtBaoCao.Rows[0][8]);
                txtNguoiBaoCao.Text = dtBaoCao.Rows[0][5].ToString();
                txtDichBenh.Text = GetDataController.GetHospitalName(dtBaoCao.Rows[0][9]);
                ltNhanXet.Text = dtBaoCao.Rows[0][6].ToString();
                ltTrienKhai.Text = dtBaoCao.Rows[0][7].ToString();

                dtSoLieu = (DataTable)ViewState["SoLieu"];
                table = (DataTable)ViewState["GridView"];
                DataRow row;
                for (int i = 0; i < dtSoLieu.Rows.Count; i++)
                {
                    row = table.NewRow();
                    row[0] = GetDataController.GetDistrictName(dtSoLieu.Rows[i][1]);
                    row[1] = Convert.ToInt16(dtSoLieu.Rows[i][2]);
                    row[2] = Convert.ToInt16(dtSoLieu.Rows[i][4]);
                    row[3] = Convert.ToInt16(dtSoLieu.Rows[i][3]);
                    row[4] = Convert.ToInt16(dtSoLieu.Rows[i][5]);
                    row[5] = Convert.ToInt16(dtSoLieu.Rows[i][6]);
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