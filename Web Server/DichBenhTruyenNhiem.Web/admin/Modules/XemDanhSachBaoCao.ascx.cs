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
    public partial class XemDanhSachBaoCao : System.Web.UI.UserControl
    {
        private DistrictsController districtController = new DistrictsController();
        private ProvincesController provinceController = new ProvincesController();
        private BenhVienController benhvienController = new BenhVienController();
        private DichBenhController benhdichController = new DichBenhController();
        private BaoCaoNgayController baocaongayController = new BaoCaoNgayController();
        private string fromDay, toDay;
        private string benhdich, benhvien, tinh, huyen;
        DataTable result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCombo();
                Initialize();
            }
        }

        protected void Initialize()
        {
            fromDay = toDay = "";
            benhdich = benhvien = tinh = huyen = "";
        }

        protected void LoadCombo()
        {
            try
            {
                ListItem iadd = new ListItem("Chọn dữ liệu", "-1");

                // Load dữ liệu Tỉnh
                WebAdicom.ProvincesDataTable provinceDataTable = new WebAdicom.ProvincesDataTable();
                provinceDataTable = provinceController.GetData();
                ddlTinh.DataSource = provinceDataTable;
                ddlTinh.DataValueField = "ProvinceID";
                ddlTinh.DataTextField = "ProvinceName";
                ddlTinh.DataBind();
                ddlTinh.Items.Insert(0, iadd);

                // Load dữ liệu Quận/Huyện
                WebAdicom.DistrictsDataTable districtDataTable = new WebAdicom.DistrictsDataTable();
                districtDataTable = districtController.GetData();
                ddlHuyen.DataSource = districtDataTable;
                ddlHuyen.DataValueField = "DistrictID";
                ddlHuyen.DataTextField = "DistrictName";
                ddlHuyen.DataBind();
                ddlHuyen.Items.Insert(0, iadd);

                // Load dữ liệu Bệnh viện
                WebAdicom.BenhvienDataTable benhvienDataTable = new WebAdicom.BenhvienDataTable();
                benhvienDataTable = benhvienController.GetData();
                ddlBenhVien.DataSource = benhvienDataTable;
                ddlBenhVien.DataValueField = "idbenhvien";
                ddlBenhVien.DataTextField = "Tenbenhvien";
                ddlBenhVien.DataBind();
                ddlBenhVien.Items.Insert(0, iadd);

                // Load dữ liệu Bệnh dịch
                WebAdicom.DichBenhDataTable benhdichDataTable = new WebAdicom.DichBenhDataTable();
                benhdichDataTable = benhdichController.GetData();
                ddlBenhDich.DataSource = benhdichDataTable;
                ddlBenhDich.DataValueField = "idbenhdich";
                ddlBenhDich.DataTextField = "TenBenhDich";
                ddlBenhDich.DataBind();
                ddlBenhDich.Items.Insert(0, iadd);
            }
            catch { }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            result = new DataTable();
            try
            {
                fromDay = cldFromDay.Text;
                toDay = cldToDay.Text;
                benhdich = ddlBenhDich.SelectedItem.Text;
                tinh = ddlTinh.SelectedItem.Text;
                huyen = ddlHuyen.SelectedItem.Text;
                benhvien = ddlBenhVien.SelectedItem.Text;
                SqlConnection sqlcon = new SqlConnection(baocaongayController.connectionString);

                string query = "select * from BC_DanhSachBaoCao where 1=1";
                string condition = "";
                if (tinh != "Chọn dữ liệu") condition = condition + " and tinh = @tinh";
                if (huyen != "Chọn dữ liệu") condition = condition + " and huyen = @huyen";
                if (benhvien != "Chọn dữ liệu") condition = condition + " and benhvien = @benhvien";
                if (benhdich != "Chọn dữ liệu") condition = condition + " and benhdich = @benhdich";
                if (fromDay != "" && toDay != "") condition = condition + " and ngaybaocao between @fromDay and @toDay";                
                SqlCommand sqlcmd = new SqlCommand(query+condition, sqlcon);
                if (tinh != "Chọn dữ liệu") sqlcmd.Parameters.AddWithValue("@tinh", tinh);
                if (huyen != "Chọn dữ liệu") sqlcmd.Parameters.AddWithValue("@huyen", huyen);
                if (benhvien != "Chọn dữ liệu") sqlcmd.Parameters.AddWithValue("@benhvien", benhvien);
                if (benhdich != "Chọn dữ liệu") sqlcmd.Parameters.AddWithValue("@benhdich", benhdich);
                if (fromDay != "") sqlcmd.Parameters.AddWithValue("@fromDay", fromDay);
                if (toDay != "") sqlcmd.Parameters.AddWithValue("@toDay", toDay);
                SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                adpt.Fill(result);
                grvDuLieu.DataSource = result;
                grvDuLieu.DataBind();
                ViewState["CurrentTable"] = result;
            }
            catch { }
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            result = (DataTable)ViewState["CurrentTable"];
            int idbaocao, loaibaocao;
            idbaocao = Convert.ToInt16(result.Rows[rowID][1]);
            loaibaocao = Convert.ToInt16(result.Rows[rowID][2]);
            switch (loaibaocao)
            {
                case 1: Response.Redirect("XemBaoCaoNgay.aspx?id="+idbaocao.ToString()); break;
                case 2: Response.Redirect("XemBaoCaoChiTietThang.aspx?id=" + idbaocao.ToString()); break;
                case 3: Response.Redirect("XemBaoCaoTongHopThang.aspx?id=" + idbaocao.ToString()); break;
                case 4: Response.Redirect("XemBaoCaoNam.aspx?id=" + idbaocao.ToString()); break;
            }
        }
    }
}