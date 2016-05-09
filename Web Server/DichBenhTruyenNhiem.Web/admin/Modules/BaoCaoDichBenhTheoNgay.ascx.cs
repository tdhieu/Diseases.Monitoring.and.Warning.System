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
    public partial class BaoCaoDichBenhTheoNgay : System.Web.UI.UserControl
    {
        DataRow row;
        DataTable table;
        private DistrictsController districtsController = new DistrictsController();
        private DichBenhController dichBenhController = new DichBenhController();
        private BenhVienController benhVienController = new BenhVienController();
        private BaoCaoNgayController BaoCaoNgayController = new BaoCaoNgayController();
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
                ListItem iadd = new ListItem("Chon du lieu", null);

                WebAdicom.DistrictsDataTable districtsDataTable = new WebAdicom.DistrictsDataTable();
                districtsDataTable = districtsController.GetData();
                ddlDiaPhuong.DataSource = districtsDataTable;
                ddlDiaPhuong.DataValueField = "DistrictID";
                ddlDiaPhuong.DataTextField = "DistrictName";
                ddlDiaPhuong.DataBind();
                ddlDiaPhuong.Items.Insert(0, iadd);

                WebAdicom.BenhvienDataTable benhvienDataTable = new WebAdicom.BenhvienDataTable();
                benhvienDataTable = benhVienController.GetData();
                ddlBenhVien.DataSource = benhvienDataTable;
                ddlBenhVien.DataValueField = "Idbenhvien";
                ddlBenhVien.DataTextField = "Tenbenhvien";
                ddlBenhVien.DataBind();
                ddlBenhVien.Items.Insert(0, iadd);

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
                table.Columns.Add(new DataColumn("TenDiaPhuong", typeof(System.String))); //ten dia phuong
                table.Columns.Add(new DataColumn("NgayXuatHienODich", typeof(System.DateTime))); //ngay xuat hien o dich 
                table.Columns.Add(new DataColumn("NgayXuatHienCaNhiem", typeof(System.DateTime))); //ngay xuat hien ca nhiem
                table.Columns.Add(new DataColumn("SoCaNhiem", typeof(System.Int16))); //so ca nhiem
                table.Columns.Add(new DataColumn("SoCaTuVong", typeof(System.Int16))); //so ca tu vong
                table.Columns.Add(new DataColumn("MaDiaPhuong", typeof(System.Int16))); //ma dia phuong

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
                    row["NgayXuatHienODich"] = Convert.ToDateTime(cldNgayXuatHienODich.Text);
                    row["NgayXuatHienCaNhiem"] = Convert.ToDateTime(cldNgayXuatHienCaNhiem.Text);
                    row["SoCaNhiem"] = Convert.ToInt16(txtSoNhiem.Text);
                    row["SoCaTuVong"] = Convert.ToInt16(txtSoTuVong.Text);
                    row["MaDiaPhuong"] = Convert.ToInt16(ddlDiaPhuong.SelectedItem.Value);
                    table.Rows.Add(row);

                    ViewState["CurrentTable"] = table;

                    grvDuLieu.DataSource = table;
                    grvDuLieu.DataBind();
                    lrError.Text = "";
                }
                else lrError.Text = "Dữ liệu nhập chưa phù hợp!";
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
                SqlConnection sqlcon = new SqlConnection(BaoCaoNgayController.connectionString);
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
                SqlConnection sqlcon = new SqlConnection(BaoCaoNgayController.connectionString);
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
                SqlConnection sqlcon = new SqlConnection(BaoCaoNgayController.connectionString);                

                SqlCommand sqlcmd1;

                string query = "Insert Into BC_BaoCaoNgay (iddichbenh, maso, sotinhcodich, sohuyencodich, tongsocanhiem,"
                                                        + "tongsotuvong, bienphaptrienkhai, nhanxet, ngaybaocao, nguoilapbaocao,"
                                                        + "idnoibaocao) "
                             + "Values (@iddichbenh, @maso, @sotinhcodich, @sohuyencodich, @tongsocanhiem,"
                                                        +"@tongsotuvong, @bienphaptrienkhai, @nhanxet, @ngaybaocao, @nguoilapbaocao,"
                                                        +"@idnoibaocao)";

                sqlcmd1 = new SqlCommand(query, sqlcon);

                sqlcmd1.Parameters.AddWithValue("@iddichbenh", Convert.ToInt16(ddlBenhDich.SelectedItem.Value));
                sqlcmd1.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@sotinhcodich", Convert.ToInt16(txtSoTinhBiNhiem.Text));
                sqlcmd1.Parameters.AddWithValue("@sohuyencodich", Convert.ToInt16(txtSoHuyenBiNhiem.Text));
                sqlcmd1.Parameters.AddWithValue("@tongsocanhiem", Convert.ToInt16(txtSoCaNhiem.Text));
                sqlcmd1.Parameters.AddWithValue("@tongsotuvong", Convert.ToInt16(txtSoCaTuVong.Text));
                sqlcmd1.Parameters.AddWithValue("@bienphaptrienkhai", txtBienPhapTrienKhai.Value.ToString());
                sqlcmd1.Parameters.AddWithValue("@nhanxet", txtDeNghi.Value.ToString());
                sqlcmd1.Parameters.AddWithValue("@ngaybaocao", Convert.ToDateTime(cldNgayBaoCao.Value));
                sqlcmd1.Parameters.AddWithValue("@nguoilapbaocao", txtNguoiLapBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@idnoibaocao", Convert.ToInt16(ddlBenhVien.SelectedItem.Value));

                sqlcon.Open();
                int affectedRows = sqlcmd1.ExecuteNonQuery();
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Select idbaocao from BC_BaoCaoNgay where maso like @maso";
                
                SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);

                sqlcmd2.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);

                sqlcon.Open();
                int idbaocao = Convert.ToInt16(sqlcmd2.ExecuteScalar());
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Insert Into BC_SolieuBaocaoNgay "
                      + "Values (@idbaocao, @iddistrict, @socatruyennhiem, "
                      + "@socatuvong, @ngayxuathienodich, @ngayxuathiencabenh)";

                SqlCommand sqlcmd3; 

                table = (DataTable)ViewState["CurrentTable"];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sqlcmd3 = new SqlCommand(query, sqlcon);
                    sqlcmd3.Parameters.AddWithValue("@idbaocao", idbaocao);
                    sqlcmd3.Parameters.AddWithValue("@iddistrict", Convert.ToInt16(table.Rows[i][5]));
                    sqlcmd3.Parameters.AddWithValue("@socatruyennhiem", Convert.ToInt16(table.Rows[i][3]));
                    sqlcmd3.Parameters.AddWithValue("@socatuvong", Convert.ToInt16(table.Rows[i][4]));
                    sqlcmd3.Parameters.AddWithValue("@ngayxuathienodich", Convert.ToDateTime(table.Rows[i][1]));
                    sqlcmd3.Parameters.AddWithValue("@ngayxuathiencabenh", Convert.ToDateTime(table.Rows[i][2]));
                    sqlcon.Open();
                    affectedRows = sqlcmd3.ExecuteNonQuery();
                    sqlcon.Close();
                }

                //**************************************************************************************************************

                query = "Insert Into BC_DanhSachBaoCao (idbaocao, loaibaocao, tenbaocao, ngaybaocao, benhvien, benhdich, tinh, huyen, nguoilapbaocao) "
                      + "Values (@idbaocao, @loaibaocao, @tenbaocao, @ngaybaocao, @benhvien, @benhdich, @tinh, @huyen, @nguoilapbaocao)";

                SqlCommand sqlcmd4 = new SqlCommand(query, sqlcon);

                sqlcmd4.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcmd4.Parameters.AddWithValue("@loaibaocao", 1);
                sqlcmd4.Parameters.AddWithValue("@tenbaocao", "Báo cáo dịch bệnh theo ngày");
                sqlcmd4.Parameters.AddWithValue("@ngaybaocao", Convert.ToDateTime(cldNgayBaoCao.Value));
                sqlcmd4.Parameters.AddWithValue("@benhvien", GetDataController.GetHospitalName(Convert.ToInt16(ddlBenhVien.SelectedItem.Value)));
                sqlcmd4.Parameters.AddWithValue("@benhdich", ddlBenhDich.SelectedItem.Text);
                sqlcmd4.Parameters.AddWithValue("@tinh", GetProvinceName(Convert.ToInt16(ddlBenhVien.SelectedItem.Value)));
                sqlcmd4.Parameters.AddWithValue("@huyen", GetDistrictName(Convert.ToInt16(ddlBenhVien.SelectedItem.Value)));
                sqlcmd4.Parameters.AddWithValue("@nguoilapbaocao", txtNguoiLapBaoCao.Text);
                
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
