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
    public partial class XemBaoCaoNam : System.Web.UI.UserControl
    {
        DataTable dtBaoCao, table, dtDiaPhuong;
        int idbaocao, nRows;
        private BaoCaoNamController BaoCaoNamController = new BaoCaoNamController();
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
                table.Columns.Add(new DataColumn("DiaPhuong", typeof(System.String)));
                table.Columns.Add(new DataColumn("DichBenh", typeof(System.String)));
                table.Columns.Add(new DataColumn("T1_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T1_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T2_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T2_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T3_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T3_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T4_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T4_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T5_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T5_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T6_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T6_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T7_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T7_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T8_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T8_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T9_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T9_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T10_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T10_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T11_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T11_C", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T12_M", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("T12_C", typeof(System.Int16))); 

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
            dtDiaPhuong = new DataTable();
            try
            {
                SqlConnection sqlcon = new SqlConnection(BaoCaoNamController.connectionString);
                string query = "Select * "
                             + "From BC_BaoCaoNam "
                             + "Where idbaocao=@idbaocao";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcon.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                adpt.Fill(dtBaoCao);
                sqlcon.Close();
                ViewState["BaoCao"] = dtBaoCao;

                query = "Select iddiaphuong, iddichbenh, thang, socamacbenh, socatuvong "
                      + "From BC_SolieuBaocaoNam "
                      + "Where idbaocao=@idbaocao "                      
                      + "Order by iddiaphuong, thang";
                sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcon.Open();
                adpt = new SqlDataAdapter(sqlcmd);
                adpt.Fill(dtDiaPhuong);
                sqlcon.Close();

                query = "Select count(distinct iddiaphuong) "
                      + "From BC_SolieuBaocaoNam "
                      + "Where idbaocao=@idbaocao";
                sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcon.Open();
                nRows = Convert.ToInt16(sqlcmd.ExecuteScalar());
                sqlcon.Close();
                ViewState["DiaPhuong"] = dtDiaPhuong;
                ViewState["nSoLieu"] = nRows;
            }
            catch { }
        }

        protected void LoadReport()
        {
            try
            {
                dtBaoCao = (DataTable)ViewState["BaoCao"];
                txtMaBaoCao.Text = dtBaoCao.Rows[0][1].ToString();
                txtNamBaoCao.Text = dtBaoCao.Rows[0][2].ToString(); 
                txtNgayBaoCao.Text = dtBaoCao.Rows[0][3].ToString();
                txtNguoiBaoCao.Text = dtBaoCao.Rows[0][4].ToString();
                txtNoiBaoCao.Text = dtBaoCao.Rows[0][7].ToString();
                ltNhanXet.Text = dtBaoCao.Rows[0][5].ToString();
                ltTrienKhai.Text = dtBaoCao.Rows[0][6].ToString();

                dtDiaPhuong = (DataTable)ViewState["DiaPhuong"];
                table = (DataTable)ViewState["GridView"];

                nRows = Convert.ToInt16(ViewState["nSoLieu"]);
                SqlConnection sqlcon = new SqlConnection(BaoCaoNamController.connectionString);
                string query = "Select iddiaphuong, iddichbenh, thang, socamacbenh, socatuvong "
                             + "from BC_SolieuBaoCaoNam "
                             + "where idbaocao=@idbaocao and iddiaphuong=@iddiaphuong";
                SqlCommand sqlcmd;
                SqlDataAdapter adpt;
                DataTable myDataSet;
                for (int i = 0; i < nRows; i++)
                {
                    sqlcmd = new SqlCommand(query, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@idbaocao", idbaocao);
                    sqlcmd.Parameters.AddWithValue("@iddiaphuong", Convert.ToInt16(dtDiaPhuong.Rows[i][0]));
                    adpt = new SqlDataAdapter(sqlcmd);
                    myDataSet = new DataTable();
                    adpt.Fill(myDataSet);
                    DataRow row;
                    row = table.NewRow();
                    row[0] = GetDataController.GetDistrictName(myDataSet.Rows[0][0]);
                    row[1] = GetDataController.GetDiseaseName(myDataSet.Rows[0][1]);
                    int k = 1;
                    for (int j = 0; j < myDataSet.Rows.Count; j++)
                    {
                        row[++k] = Convert.ToInt16(myDataSet.Rows[j][3]);
                        row[++k] = Convert.ToInt16(myDataSet.Rows[j][4]);
                    }
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