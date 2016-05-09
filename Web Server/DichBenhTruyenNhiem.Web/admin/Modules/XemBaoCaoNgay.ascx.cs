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
    public partial class XemBaoCaoNgay : System.Web.UI.UserControl
    {
        DataTable dtBaoCao, table, dtSoLieu;
        int idbaocao;
        private BaoCaoNgayController BaoCaoNgayController = new BaoCaoNgayController();
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
                table.Columns.Add(new DataColumn("NgayXuatHienODich", typeof(System.DateTime))); //ngay xuat hien o dich 
                table.Columns.Add(new DataColumn("NgayXuatHienCaNhiem", typeof(System.DateTime))); //ngay xuat hien ca nhiem
                table.Columns.Add(new DataColumn("SoCaNhiem", typeof(System.Int16))); //so ca nhiem
                table.Columns.Add(new DataColumn("SoCaTuVong", typeof(System.Int16))); //so ca tu vong

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
                SqlConnection sqlcon = new SqlConnection(BaoCaoNgayController.connectionString);
                string query = "Select * "
                             + "From BC_BaoCaoNgay "
                             + "Where idbaocao=@idbaocao";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcon.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                adpt.Fill(dtBaoCao);
                sqlcon.Close();
                ViewState["BaoCao"] = dtBaoCao;

                query = "Select * "
                      + "From BC_SolieuBaocaoNgay "
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
                txtMaBaoCao.Text = dtBaoCao.Rows[0][2].ToString();
                txtBenhVien.Text = GetDataController.GetHospitalName(dtBaoCao.Rows[0][11]);
                txtBenhDich.Text = dtBaoCao.Rows[0][1].ToString();
                txtSoTinhBiNhiem.Text = dtBaoCao.Rows[0][3].ToString();
                txtSoHuyenBiNhiem.Text = dtBaoCao.Rows[0][4].ToString();
                txtNgayBaoCao.Text = dtBaoCao.Rows[0][9].ToString();
                txtSoCaNhiem.Text = dtBaoCao.Rows[0][5].ToString();
                txtSoCaTuVong.Text = dtBaoCao.Rows[0][6].ToString();
                txtNguoiLapBaoCao.Text = dtBaoCao.Rows[0][10].ToString();
                ltNhanXet.Text = dtBaoCao.Rows[0][8].ToString();
                ltTrienKhai.Text = dtBaoCao.Rows[0][7].ToString();

                dtSoLieu = (DataTable)ViewState["SoLieu"];
                table = (DataTable)ViewState["GridView"];
                DataRow row;
                for (int i = 0; i < dtSoLieu.Rows.Count; i++)
                {
                    row = table.NewRow();
                    row[0] = GetDataController.GetDistrictName(dtSoLieu.Rows[i][1]);
                    row[1] = Convert.ToDateTime(dtSoLieu.Rows[i][4]);
                    row[2] = Convert.ToDateTime(dtSoLieu.Rows[i][5]);
                    row[3] = Convert.ToInt16(dtSoLieu.Rows[i][2]);
                    row[4] = Convert.ToInt16(dtSoLieu.Rows[i][3]);
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