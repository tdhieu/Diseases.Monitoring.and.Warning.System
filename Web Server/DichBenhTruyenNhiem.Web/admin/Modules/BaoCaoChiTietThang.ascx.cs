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
    public partial class BaoCaoChiTietThang : System.Web.UI.UserControl
    {
        DataRow row;
        DataTable table;
        private DistrictsController districtsController = new DistrictsController();
        private DichBenhController dichBenhController = new DichBenhController();
        private BenhVienController benhVienController = new BenhVienController();
        private BaoCaoChiTietThangController BaocaoChitietThangController = new BaoCaoChiTietThangController();
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
                ddlBenhDich.DataSource = dichbenhDataTable;
                ddlBenhDich.DataValueField = "IdBenhDich";
                ddlBenhDich.DataTextField = "TenBenhDich";
                ddlBenhDich.DataBind();
                ddlBenhDich.Items.Insert(0, iadd);
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
                table.Columns.Add(new DataColumn("TenDiaPhuong", typeof(System.String)));
                table.Columns.Add(new DataColumn("SoBenhNhanNhiem", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("SoCaAcTinh", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("SoCaTuVong", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("SoCaXetNghiem", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("SoCaDuongTinh", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("MaDiaPhuong", typeof(System.Int16)));

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
                    row["TenDiaPhuong"] = ddlDiaPhuong.SelectedItem.Text;
                    row["SoBenhNhanNhiem"] = Convert.ToInt16(txtBenhNhanNhiem.Text);
                    row["SoCaAcTinh"] = Convert.ToInt16(txtBenhAcTinh.Text);
                    row["SoCaTuVong"] = Convert.ToInt16(txtSoTuVong.Text);
                    row["SoCaXetNghiem"] = Convert.ToInt16(txtSoXetNghiem.Text);
                    row["SoCaDuongTinh"] = Convert.ToInt16(txtSoDuongTinh.Text);
                    row["MaDiaPhuong"] = Convert.ToInt16(ddlDiaPhuong.SelectedItem.Value);

                    table.Rows.Add(row);

                    ViewState["CurrentTable"] = table;

                    grvDuLieu.DataSource = table;
                    grvDuLieu.DataBind();
                    lrWarning.Text = "";
                }
                else ltError.Text = "Dữ liệu nhập chưa phù hợp";
            }
            catch { }            
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
                lrWarning.Text = "";
                return ProvinceName;
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
                lrWarning.Text = "";
                return DistrictName;
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
                SqlConnection sqlcon = new SqlConnection(BaocaoChitietThangController.connectionString);

                SqlCommand sqlcmd1;

                string query = "Insert Into BC_BaoCaoThangChiTiet (iddichbenh, maso, ngaybatdau, ngayketthuc,"
                                             + "ngaylapbaocao, nguoilapbaocao, nhanxet, bienphaptrienkhai, idnoibaocao) "
                             + "Values (@iddichbenh, @maso, @ngaybatdau, @ngayketthuc, @ngaylapbaocao, @nguoilapbaocao,"
                                             + "@nhanxet, @bienphaptrienkhai, @idnoibaocao)";

                sqlcmd1 = new SqlCommand(query, sqlcon);

                sqlcmd1.Parameters.AddWithValue("@iddichbenh", Convert.ToInt16(ddlBenhDich.SelectedItem.Value));
                sqlcmd1.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@ngaybatdau", Convert.ToDateTime(cldNgayBatDau.Value));
                sqlcmd1.Parameters.AddWithValue("@ngayketthuc", Convert.ToDateTime(cldNgayKetThuc.Value));
                sqlcmd1.Parameters.AddWithValue("@ngaylapbaocao", Convert.ToDateTime(cldNgayBaoCao.Value));
                sqlcmd1.Parameters.AddWithValue("@nguoilapbaocao", txtNguoiBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@nhanxet", txtDeNghi.Value.ToString());
                sqlcmd1.Parameters.AddWithValue("@bienphaptrienkhai", txtBienPhapTrienKhai.Value.ToString());
                sqlcmd1.Parameters.AddWithValue("@idnoibaocao", Convert.ToInt16(ddlBenhVien.SelectedItem.Value));

                sqlcon.Open();
                int affectedRows = sqlcmd1.ExecuteNonQuery();
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Select idbaocao from BC_BaoCaoThangChiTiet where maso like @maso";

                SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);
                
                sqlcmd2.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);

                sqlcon.Open();
                int idbaocao = Convert.ToInt16(sqlcmd2.ExecuteScalar());
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Insert Into BC_SolieuBaocaoThangChiTiet " +
                        "Values (@idbaocao, @iddiaphuong, @sobenhnhannhiem, @socatuvong, @socaactinh, @socaxetnghiem, @socaduongtinh)";

                table = (DataTable)ViewState["CurrentTable"];
                SqlCommand sqlcmd3;
                
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sqlcmd3 = new SqlCommand(query, sqlcon);
                    sqlcmd3.Parameters.AddWithValue("@idbaocao", idbaocao);
                    sqlcmd3.Parameters.AddWithValue("@iddiaphuong", Convert.ToInt16(table.Rows[i][6]));
                    sqlcmd3.Parameters.AddWithValue("@sobenhnhannhiem", Convert.ToInt16(table.Rows[i][1]));
                    sqlcmd3.Parameters.AddWithValue("@socatuvong", Convert.ToInt16(table.Rows[i][2]));
                    sqlcmd3.Parameters.AddWithValue("@socaactinh", Convert.ToInt16(table.Rows[i][3]));
                    sqlcmd3.Parameters.AddWithValue("@socaxetnghiem", Convert.ToInt16(table.Rows[i][4]));
                    sqlcmd3.Parameters.AddWithValue("@socaduongtinh", Convert.ToInt16(table.Rows[i][5]));
                    sqlcon.Open();
                    affectedRows = sqlcmd3.ExecuteNonQuery();
                    sqlcon.Close();
                }

                //**************************************************************************************************************

                query = "Insert Into BC_DanhSachBaoCao (idbaocao, loaibaocao, tenbaocao, ngaybaocao, benhvien, benhdich, tinh, huyen, nguoilapbaocao) "
                      + "Values (@idbaocao, @loaibaocao, @tenbaocao, @ngaybaocao, @benhvien, @benhdich, @tinh, @huyen, @nguoilapbaocao)";

                SqlCommand sqlcmd4 = new SqlCommand(query, sqlcon);
                string tendichbenh = ddlBenhDich.SelectedItem.Text;
                sqlcmd4.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcmd4.Parameters.AddWithValue("@loaibaocao", 2);
                sqlcmd4.Parameters.AddWithValue("@tenbaocao", "Báo cáo tình hình dịch bệnh "  + tendichbenh + " theo tháng");
                sqlcmd4.Parameters.AddWithValue("@ngaybaocao", Convert.ToDateTime(cldNgayBaoCao.Value));
                sqlcmd4.Parameters.AddWithValue("@benhvien", ddlBenhVien.SelectedItem.Text);
                sqlcmd4.Parameters.AddWithValue("@benhdich", tendichbenh);
                sqlcmd4.Parameters.AddWithValue("@tinh", GetProvinceName(Convert.ToInt16(ddlBenhVien.SelectedItem.Value)));
                sqlcmd4.Parameters.AddWithValue("@huyen", GetDistrictName(Convert.ToInt16(ddlBenhVien.SelectedItem.Value)));
                sqlcmd4.Parameters.AddWithValue("@nguoilapbaocao", txtNguoiBaoCao.Text);

                sqlcon.Open();
                affectedRows = sqlcmd4.ExecuteNonQuery();
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