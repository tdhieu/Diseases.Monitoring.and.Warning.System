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

namespace Adicom.Web.admin.Modules
{
    public partial class BaoCaoDichBenhTheoNam : System.Web.UI.UserControl
    {
        DataRow row;
        DataTable table;
        private DistrictsController districtsController = new DistrictsController();
        private DichBenhController dichBenhController = new DichBenhController();
        private BenhVienController benhVienController = new BenhVienController();
        private BaoCaoNamController BaocaoNamController = new BaoCaoNamController();
        private GetDataController GetDataController = new GetDataController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCombo();
                InitDataSource();
            }
        }

        private void LoadCombo()
        {
            try
            {
                ListItem iadd = new ListItem("Chọn dữ liệu", null);

                // Load địa phương
                WebAdicom.DistrictsDataTable districtsDataTable = new WebAdicom.DistrictsDataTable();
                districtsDataTable = districtsController.GetData();
                ddlDiaPhuong.DataSource = districtsDataTable;
                ddlDiaPhuong.DataValueField = "DistrictID";
                ddlDiaPhuong.DataTextField = "DistrictName";
                ddlDiaPhuong.DataBind();
                ddlDiaPhuong.Items.Insert(0, iadd);

                // Load bệnh viện
                WebAdicom.BenhvienDataTable benhvienDataTable = new WebAdicom.BenhvienDataTable();
                benhvienDataTable = benhVienController.GetData();
                ddlBenhVien.DataSource = benhvienDataTable;
                ddlBenhVien.DataValueField = "Idbenhvien";
                ddlBenhVien.DataTextField = "Tenbenhvien";
                ddlBenhVien.DataBind();
                ddlBenhVien.Items.Insert(0, iadd);

                // Load dịch bệnh
                WebAdicom.DichBenhDataTable dichbenhDataTable = new WebAdicom.DichBenhDataTable();
                dichbenhDataTable = dichBenhController.GetData();
                ddlDichBenh.DataSource = dichbenhDataTable;
                ddlDichBenh.DataValueField = "IdBenhDich";
                ddlDichBenh.DataTextField = "TenBenhDich";
                ddlDichBenh.DataBind();
                ddlDichBenh.Items.Insert(0, iadd);

                ListItem item;

                for (int i = 1980; i <= 2050; i++)
                {
                    item = new ListItem();
                    item.Value = i.ToString();
                    item.Text = i.ToString();
                    ddlNam.Items.Add(item);
                }
                ddlNam.Items.Insert(0, iadd);
                lrWarning.Text = "";
            }
            catch (Exception ex)
            {
                lrWarning.Text = "Error: " + ex.Message;
            }
        }

       private void InitDataSource()
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
                table.Columns.Add(new DataColumn("IDDiaPhuong", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("IDDichBenh", typeof(System.Int16)));

                grvDuLieu.HorizontalAlign = HorizontalAlign.Center;
                grvDuLieu.DataSource = table;
                grvDuLieu.DataBind();

                ViewState["CurrentTable"] = table;
                lrWarning.Text = "";
            }
            catch (Exception ex)
            {
                lrWarning.Text = "Error: " + ex.Message;
            }
        }

       protected bool UniqueData()
       {
           int iddiaphuong = Convert.ToInt16(ddlDiaPhuong.SelectedItem.Value);
           for (int i = 0; i < table.Rows.Count; i++)
               if (Convert.ToInt16(table.Rows[i][5]) == iddiaphuong)
                   return false;
           return true;
       }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            table = (DataTable)ViewState["CurrentTable"];
            try
            {
                if (UniqueData())
                {
                    row = table.NewRow();
                    row["DiaPhuong"] = ddlDiaPhuong.SelectedItem.Text;
                    row["DichBenh"] = ddlDichBenh.SelectedItem.Text;
                    row["T1_M"] = Convert.ToInt16(T1_M.Text);
                    row["T1_C"] = Convert.ToInt16(T1_C.Text);
                    row["T2_M"] = Convert.ToInt16(T2_M.Text);
                    row["T2_C"] = Convert.ToInt16(T2_C.Text);
                    row["T3_M"] = Convert.ToInt16(T3_M.Text);
                    row["T3_C"] = Convert.ToInt16(T3_C.Text);
                    row["T4_M"] = Convert.ToInt16(T4_M.Text);
                    row["T4_C"] = Convert.ToInt16(T4_C.Text);
                    row["T5_M"] = Convert.ToInt16(T5_M.Text);
                    row["T5_C"] = Convert.ToInt16(T5_C.Text);
                    row["T6_M"] = Convert.ToInt16(T6_M.Text);
                    row["T6_C"] = Convert.ToInt16(T6_C.Text);
                    row["T7_M"] = Convert.ToInt16(T7_M.Text);
                    row["T7_C"] = Convert.ToInt16(T7_C.Text);
                    row["T8_M"] = Convert.ToInt16(T8_M.Text);
                    row["T8_C"] = Convert.ToInt16(T8_C.Text);
                    row["T9_M"] = Convert.ToInt16(T9_M.Text);
                    row["T9_C"] = Convert.ToInt16(T9_C.Text);
                    row["T10_M"] = Convert.ToInt16(T10_M.Text);
                    row["T10_C"] = Convert.ToInt16(T10_C.Text);
                    row["T11_M"] = Convert.ToInt16(T11_M.Text);
                    row["T11_C"] = Convert.ToInt16(T11_C.Text);
                    row["T12_M"] = Convert.ToInt16(T12_M.Text);
                    row["T12_C"] = Convert.ToInt16(T12_C.Text);
                    row["IDDiaPhuong"] = ddlDiaPhuong.SelectedItem.Value;
                    row["IDDichBenh"] = ddlDichBenh.SelectedItem.Value;

                    table.Rows.Add(row);

                    ViewState["CurrentTable"] = table;

                    grvDuLieu.DataSource = table;
                    grvDuLieu.DataBind();
                    ltError.Text = "";
                }
                else ltError.Text = "Dữ liệu nhập chưa phù hợp!";
            }
            catch {}
        }

        protected void grvDuLieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    table = (DataTable)ViewState["CurrentTable"];
                    int id = e.RowIndex;
                    table.Rows.RemoveAt(id);
                    grvDuLieu.DataSource = table;
                    grvDuLieu.DataBind();
                    ViewState["CurrentTable"] = table;
                }
                lrWarning.Text = "";
            }
            catch (Exception ex)
            {
                lrWarning.Text = "Error: " + ex.Message;
            }
        }

        protected string GetProvinceName(int idbenhvien)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(GetDataController.connectionstring);
                string query = "Select ProvinceName "
                             + "from Provinces Prv, Districts Dst "
                             + "where Prv.ProvinceID=Dst.ProvinceID and "
                             + "DistrictID=(Select idquanhuyen from Benhvien where idbenhvien=@idbenhvien)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbenhvien", idbenhvien);
                sqlcon.Open();
                string ProvinceName = sqlcmd.ExecuteScalar().ToString();
                sqlcon.Close();
                return ProvinceName;
                lrWarning.Text = "";
            }
            catch (Exception ex)
            {
                lrWarning.Text = "Error: " + ex.Message;
            }
            return "";
        }

        protected string GetDistrictName(int idbenhvien)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(GetDataController.connectionstring);
                string query = "Select DistrictName "
                             + "from Districts, BenhVien "
                             + "where idbenhvien=@idbenhvien and idquanhuyen=districtid";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@idbenhvien", idbenhvien);
                sqlcon.Open();
                string DistrictName = sqlcmd.ExecuteScalar().ToString();
                sqlcon.Close();
                return DistrictName;
                lrWarning.Text = "";
            }
            catch (Exception ex)
            {
                lrWarning.Text = "Error: " + ex.Message;
            }
            return "";
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(BaocaoNamController.connectionString);

                string query = "Insert Into BC_BaoCaoNam (maso, nam, ngaybaocao, nguoilapbaocao, nhanxet, bienphaptrienkhai, idnoibaocao) "
                             + "Values (@maso, @nam, @ngaybaocao, @nguoilapbaocao, @nhanxet, @bienphaptrienkhai, @idnoibaocao)";

                SqlCommand sqlcmd1 = new SqlCommand(query, sqlcon);

                sqlcmd1.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@nam", Convert.ToInt16(ddlNam.SelectedItem.Value));
                sqlcmd1.Parameters.AddWithValue("@ngaybaocao", Convert.ToDateTime(cldNgayBaoCao.Value));
                sqlcmd1.Parameters.AddWithValue("@nguoilapbaocao", txtNguoiBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@nhanxet", txtDeNghi.Value);
                sqlcmd1.Parameters.AddWithValue("@bienphaptrienkhai", txtBienPhapTrienKhai.Value);
                sqlcmd1.Parameters.AddWithValue("@idnoibaocao", Convert.ToInt16(ddlBenhVien.SelectedItem.Value));

                sqlcon.Open();
                int AffectedRows = sqlcmd1.ExecuteNonQuery();
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Select idbaocao from BC_BaoCaoNam where maso like @maso";

                SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);

                sqlcmd2.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);

                sqlcon.Open();
                int idbaocao = Convert.ToInt16(sqlcmd2.ExecuteScalar());
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Insert Into BC_SolieuBaocaoNam Values (@thang, @idbaocao, @iddichbenh, @iddiaphuong, @socamacbenh, @socatuvong)";

                table = (DataTable)ViewState["CurrentTable"];
                SqlCommand sqlcmd3;

                for (int i = 0; i < table.Rows.Count; i++)
                    for (int month = 1; month <= 12; month++)
                    {
                        sqlcmd3 = new SqlCommand(query, sqlcon);
                        sqlcmd3.Parameters.AddWithValue("@thang", month);
                        sqlcmd3.Parameters.AddWithValue("@idbaocao", idbaocao);
                        sqlcmd3.Parameters.AddWithValue("@iddichbenh", Convert.ToInt16(table.Rows[i][27]));
                        sqlcmd3.Parameters.AddWithValue("@iddiaphuong", Convert.ToInt16(table.Rows[i][26]));
                        sqlcmd3.Parameters.AddWithValue("@socamacbenh", Convert.ToInt16(table.Rows[i][2 * month]));
                        sqlcmd3.Parameters.AddWithValue("@socatuvong", Convert.ToInt16(table.Rows[i][2 * month + 1]));
                        sqlcon.Open();
                        AffectedRows = sqlcmd3.ExecuteNonQuery();
                        sqlcon.Close();
                    }

                //**************************************************************************************************************

                query = "Insert Into BC_DanhSachBaoCao (idbaocao, loaibaocao, tenbaocao, ngaybaocao, benhvien, benhdich, tinh, huyen, nguoilapbaocao) "
                      + "Values (@idbaocao, @loaibaocao, @tenbaocao, @ngaybaocao, @benhvien, @benhdich, @tinh, @huyen, @nguoilapbaocao)";

                SqlCommand sqlcmd4 = new SqlCommand(query, sqlcon);

                sqlcmd4.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcmd4.Parameters.AddWithValue("@loaibaocao", 4);
                sqlcmd4.Parameters.AddWithValue("@tenbaocao", "Báo cáo dịch bệnh theo năm");
                sqlcmd4.Parameters.AddWithValue("@ngaybaocao", Convert.ToDateTime(cldNgayBaoCao.Value));
                sqlcmd4.Parameters.AddWithValue("@benhvien", ddlBenhVien.SelectedItem.Text);
                sqlcmd4.Parameters.AddWithValue("@benhdich", "tất cả");
                sqlcmd4.Parameters.AddWithValue("@tinh", GetProvinceName(Convert.ToInt16(ddlBenhVien.SelectedItem.Value)));
                sqlcmd4.Parameters.AddWithValue("@huyen", GetDistrictName(Convert.ToInt16(ddlBenhVien.SelectedItem.Value)));
                sqlcmd4.Parameters.AddWithValue("@nguoilapbaocao", txtNguoiBaoCao.Text);

                sqlcon.Open();
                int affectedRows = sqlcmd4.ExecuteNonQuery();
                sqlcon.Close();
                lrWarning.Text = "";
                Response.Redirect("admin.aspx");
            }
            catch (Exception ex)
            {
                lrWarning.Text = "Error: " + ex.Message;
            }
        }
    }
}