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
    public partial class BaoCaoTongHopThang : System.Web.UI.UserControl
    {
        DataTable table;
        WebAdicom.DichBenhDataTable dichbenhDataTable;
        private DistrictsController districtsController = new DistrictsController();
        private DichBenhController dichBenhController = new DichBenhController();
        private BenhVienController benhVienController = new BenhVienController();
        private BaoCaoTongHopThangController BaocaoTonghopThangController = new BaoCaoTongHopThangController();
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

                ListItem item;

                for (int i = 1; i <= 12; i++)
                {
                    item = new ListItem();
                    item.Value = i.ToString();
                    item.Text = "Tháng " + i;
                    ddlthang.Items.Add(item);
                }
                ddlthang.Items.Insert(0, iadd);

                for (int i = 1980; i <= 2050; i++)
                {
                    item = new ListItem();
                    item.Value = i.ToString();
                    item.Text = i.ToString();
                    ddlNam.Items.Add(item);
                }
                ddlNam.Items.Insert(0, iadd);
 
                dichbenhDataTable = new WebAdicom.DichBenhDataTable();
                dichbenhDataTable = dichBenhController.GetData(); //idbenhdich - index[0]; tenbenhdich - index[1]
                ViewState["DichBenh"] = dichbenhDataTable;
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
                table.Columns.Add(new DataColumn("TenDichBenh", typeof(System.String)));
                table.Columns.Add(new DataColumn("SoCaMac", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("SoCaChet", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("IDDiaPhuong", typeof(System.Int16)));
                table.Columns.Add(new DataColumn("IDDichBenh", typeof(System.Int16)));

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

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                table = (DataTable)ViewState["CurrentTable"];
                dichbenhDataTable = (WebAdicom.DichBenhDataTable)ViewState["DichBenh"];
                DataRow row;
                for (int i = 0; i < dichbenhDataTable.Rows.Count; i++)
                {
                    row = table.NewRow();   // Chỉ thêm vào dữ liệu địa phương và dịch bệnh cho DataTable
                    row["IDDiaPhuong"] = ddlDiaPhuong.SelectedItem.Value;
                    row["IDDichBenh"] = dichbenhDataTable[i][0].ToString();
                    row["TenDiaPhuong"] = ddlDiaPhuong.SelectedItem.Text;
                    row["TenDichBenh"] = dichbenhDataTable[i][1].ToString();

                    table.Rows.Add(row);
                }

                ddlDiaPhuong.Items.RemoveAt(ddlDiaPhuong.SelectedIndex);
                ViewState["CurrentTable"] = table;

                grvDuLieu.DataSource = table;
                grvDuLieu.DataBind();
                lrWarning.Text = "";
            }
            catch (Exception ex)
            {
                lrWarning.Text = "Error: " + ex.Message;
            }
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
                SqlConnection sqlcon = new SqlConnection(BaocaoTonghopThangController.connectionString);

                SqlCommand sqlcmd1;
                string query = "Insert Into BC_BaoCaoThangTongHop (maso, thang, nam, ngaybaocao, nguoilapbaocao, nhanxet,"
                             + "bienphaptrienkhai, idnoibaocao) "
                             + "Values (@maso, @thang, @nam, @ngaybaocao, @nguoilapbaocao, @nhanxet,"
                             + "@bienphaptrienkhai, @idnoibaocao)";

                sqlcmd1 = new SqlCommand(query, sqlcon);

                sqlcmd1.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@thang", Convert.ToInt16(ddlthang.SelectedItem.Value));
                sqlcmd1.Parameters.AddWithValue("@nam", Convert.ToInt16(ddlNam.SelectedItem.Value));
                sqlcmd1.Parameters.AddWithValue("@ngaybaocao", Convert.ToDateTime(cldNgayBaoCao.Value));
                sqlcmd1.Parameters.AddWithValue("@nguoilapbaocao", txtNguoiBaoCao.Text);
                sqlcmd1.Parameters.AddWithValue("@nhanxet", txtDeNghi.Value);
                sqlcmd1.Parameters.AddWithValue("@bienphaptrienkhai", txtBienPhapTrienKhai.Value);
                sqlcmd1.Parameters.AddWithValue("@idnoibaocao", ddlBenhVien.SelectedItem.Value);

                sqlcon.Open();
                int AffectedRows = sqlcmd1.ExecuteNonQuery();
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Select idbaocao from BC_BaoCaoThangTongHop where maso like @maso";

                SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);

                sqlcmd2.Parameters.AddWithValue("@maso", txtMaBaoCao.Text);

                sqlcon.Open();
                int idbaocao = Convert.ToInt16(sqlcmd2.ExecuteScalar());
                sqlcon.Close();

                //**************************************************************************************************************

                query = "Insert Into BC_SolieuBaoCaoThangTongHop Values(@idbaocao, @iddichbenh, @iddiaphuong, @songuoimac, @songuoichet)";
                table = (DataTable)ViewState["CurrentTable"];
                SqlCommand sqlcmd3;
                TextBox SoCaMac, SoCaChet;                
                for (int i = 0; i < grvDuLieu.Rows.Count; i++)
                {
                    sqlcmd3 = new SqlCommand(query, sqlcon);
                    sqlcmd3.Parameters.AddWithValue("@idbaocao", idbaocao);
                    sqlcmd3.Parameters.AddWithValue("@iddichbenh", Convert.ToInt16(table.Rows[i][5]));
                    sqlcmd3.Parameters.AddWithValue("@iddiaphuong", Convert.ToInt16(table.Rows[i][4]));
                    SoCaMac = (TextBox)grvDuLieu.Rows[i].Cells[2].FindControl("txtSoCaMac");
                    SoCaChet = (TextBox)grvDuLieu.Rows[i].Cells[3].FindControl("txtSoCaChet");
                    sqlcmd3.Parameters.AddWithValue("@songuoimac", Convert.ToInt16(SoCaMac.Text));
                    sqlcmd3.Parameters.AddWithValue("@songuoichet", Convert.ToInt16(SoCaChet.Text));
                    sqlcon.Open();
                    AffectedRows = sqlcmd3.ExecuteNonQuery();
                    sqlcon.Close();
                }

                //**************************************************************************************************************

                query = "Insert Into BC_DanhSachBaoCao (idbaocao, loaibaocao, tenbaocao, ngaybaocao, benhvien, benhdich, tinh, huyen, nguoilapbaocao) "
                      + "Values (@idbaocao, @loaibaocao, @tenbaocao, @ngaybaocao, @benhvien, @benhdich, @tinh, @huyen, @nguoilapbaocao)";

                SqlCommand sqlcmd4 = new SqlCommand(query, sqlcon);

                sqlcmd4.Parameters.AddWithValue("@idbaocao", idbaocao);
                sqlcmd4.Parameters.AddWithValue("@loaibaocao", 3);
                sqlcmd4.Parameters.AddWithValue("@tenbaocao", "Báo cáo tổng hợp tình hình dịch bệnh theo tháng");
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
