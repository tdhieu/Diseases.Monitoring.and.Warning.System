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
using Adicom.Web.Code;
using Adicom.Web.DAL;

namespace Adicom.Web.admin.Modules
{
    public partial class BenhVienControl : System.Web.UI.UserControl
    {
        private BenhVienController benhVienController = new BenhVienController();
        private DistrictsController districtsController = new DistrictsController();
        private ProvincesController provincesController = new ProvincesController();
        public WebAdicom.BenhvienDataTable database = new WebAdicom.BenhvienDataTable();
        public WebAdicom.BenhvienRow row = null;
        public WebAdicom.DistrictsRow rowDis = null;
        public WebAdicom.BenhvienRow rowbenhvien = null;
        public int Idbv = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadCombo();
                drlquanhuyen.SelectedIndex = 0;
                drltinh.SelectedIndex = 0;
                this.LoadData();
            }
        }
         public void GetRows()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    Idbv = Convert.ToInt32(Request.QueryString["id"].ToString());
                    row = benhVienController.GetDataById(Idbv);
                }
            }
            catch { }
        }
        public void LoadCombo()
        {
            try
            {
                ListItem iadd = new ListItem("Chọn dữ liệu", null);
                WebAdicom.DistrictsDataTable DatabaseDistricts = new WebAdicom.DistrictsDataTable();
                DatabaseDistricts = districtsController.GetData();
                drlquanhuyen.DataSource = DatabaseDistricts;
                drlquanhuyen.DataValueField = "DistrictID";
                drlquanhuyen.DataTextField = "DistrictName";
                drlquanhuyen.DataBind();
                drlquanhuyen.DataBind();
                drlquanhuyen.Items.Insert(0, iadd);

                WebAdicom.ProvincesDataTable provincesDataTable = new WebAdicom.ProvincesDataTable();
                provincesDataTable = provincesController.GetData();
                drltinh.DataSource = provincesDataTable;
                drltinh.DataValueField = "ProvinceID";
                drltinh.DataTextField = "ProvinceName";
                drltinh.DataBind();
                drltinh.DataBind();
                drltinh.Items.Insert(0, iadd);
            }
            catch { }
        }
        public void LoadData()
        {
            try
            {
                this.GetRows();
                if (row != null)
                {
                    txtbenhvien.Text = row.Tenbenhvien;
                    txtdiachi.Text = row.dichchi;
                    try
                    {
                        drlquanhuyen.SelectedValue = row.idquanhuyen.ToString();
                    }
                    catch { }
                    try
                    {
                        drltinh.SelectedValue = row.Idtinh.ToString();
                    }
                    catch { }
                    txtghichu.Text = row.Ghichu;
                    txtnguoidaidien.Text = row.nguoidaidien;
                    txtsodienthoi.Text = row.telephone.ToString();
                    txtmail.Text = row.Email;
                    txtfax.Text = row.fax.ToString();
                    txtweb.Text = row.website;
                }
            }
            catch { }
        }
        public void Fefresh()
        {
            txtbenhvien.Text = "";
            txtdiachi.Text = "";
            txtghichu.Text = "";
            txtnguoidaidien.Text = "";
            txtsodienthoi.Text = "";
            txtmail.Text = "";
            txtfax.Text = "";
            txtweb.Text = "";
            drltinh.SelectedIndex = 0;
            drlquanhuyen.SelectedIndex = 0;
        }
        
        public void Save()
        {
            try
            {
                this.GetRows();
                if (row == null)
                    row = database.NewBenhvienRow();
                row.Tenbenhvien = txtbenhvien.Text;
                row.dichchi = txtdiachi.Text;
                row.Ghichu = txtghichu.Text;
                row.nguoidaidien = txtnguoidaidien.Text;
                row.telephone = Convert.ToInt32(txtsodienthoi.Text.ToString());
                row.Email = txtmail.Text;
                row.fax = Convert.ToInt32(txtfax.Text.ToString());
                row.website = txtweb.Text;
                row.idquanhuyen = Convert.ToInt32(drlquanhuyen.SelectedValue);
                row.Idtinh = Convert.ToInt32(drltinh.SelectedValue);
                benhVienController.SaveBenhvien(row);
                this.Fefresh();
                Response.Redirect("~/admin/BenhViens.aspx");
            }
            catch { }
        }
 

        protected void drltinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drltinh.SelectedValue.ToString() != "")
            {
                drlquanhuyen.DataSource = districtsController.GetListDistricts(Convert.ToInt32(drltinh.SelectedValue.ToString()));
                drlquanhuyen.DataBind();
            }
        }

        protected void drlquanhuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drlquanhuyen.SelectedValue.ToString() != "")
            {
                rowDis = districtsController.GetrowProvince(Convert.ToInt32(drltinh.SelectedValue.ToString()));
                drltinh.SelectedValue = rowDis.ProvinceID.ToString();
                drltinh.DataBind();
            }
        }

        protected void drltinh_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (drltinh.SelectedValue.ToString() != "Chọn dữ liệu")
                {
                    drlquanhuyen.DataSource = districtsController.GetListDistricts(Convert.ToInt32(drltinh.SelectedValue.ToString()));
                    drlquanhuyen.DataBind();
                }
            }
            catch { }
        }

        protected void drlquanhuyen_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (drlquanhuyen.SelectedValue.ToString() != "Chọn dữ liệu")
                {
                    rowDis = districtsController.GetrowProvince(Convert.ToInt32(drlquanhuyen.SelectedValue.ToString()));
                    drltinh.SelectedValue = rowDis.ProvinceID.ToString();
                    drltinh.DataBind();
                }
            }
            catch { }
        }
       
    }
    }
