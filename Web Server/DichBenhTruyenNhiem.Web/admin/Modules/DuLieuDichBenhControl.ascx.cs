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
    public partial class DuLieuDichBenhControl : System.Web.UI.UserControl
    {
        private DulieuDichbenhController dulieuDichbenhController = new DulieuDichbenhController();
        private DichBenhController dichBenhController = new DichBenhController();
        private BenhVienController benhVienController = new BenhVienController();
        private DistrictsController districtsController = new DistrictsController();
        private ProvincesController provincesController = new ProvincesController();
        public WebAdicom.DulieuDichbenhDataTable database = new WebAdicom.DulieuDichbenhDataTable();
        public WebAdicom.DulieuDichbenhRow row = null;
        public WebAdicom.BenhvienRow rowbenhvien = null;
        public int Id = 0;
        public int Idbv=0;
        public int role = 0;
        public string Namebenhvien = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["Idbenhvien"] != null)
                        Idbv = Convert.ToInt32(Session["Idbenhvien"].ToString());
                    if (Session["NameBenhVien"] != null)
                        Namebenhvien = Session["NameBenhVien"].ToString();
                    if (Session["roleName"] != null)
                    {
                        role = Convert.ToInt32(Session["roleName"].ToString());
                        this.LoadCombo();
                        drldichbenh.SelectedIndex = 0;
                        this.LoadData();
                    }
                    else
                        Response.Redirect("~/Login.aspx");
                }
            }
            catch { }
        }
        public void Getbenhvien()
        {
            try
            {
                if (Session["Idbenhvien"] != null)
                rowbenhvien=benhVienController.GetDataById(Convert.ToInt32(Session["Idbenhvien"].ToString()));
            }
            catch { }
        }
        public void GetRows()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    row = dulieuDichbenhController.GetDataById(Id);
                }
            }
            catch { }
        }
        public void LoadCombo()
        {
            try
            {
                WebAdicom.DichBenhDataTable Databasedichbenh = new WebAdicom.DichBenhDataTable();
                Databasedichbenh = dichBenhController.GetData();
                drldichbenh.DataSource = Databasedichbenh;
                drldichbenh.DataValueField = "IdBenhDich";
                drldichbenh.DataTextField = "TenBenhDich";
                drldichbenh.DataBind();

                //WebAdicom.DistrictsDataTable Dataquanhuyen = new WebAdicom.DistrictsDataTable();
                //Dataquanhuyen = districtsController.GetData();
                //drlquanhuyen.DataSource = Dataquanhuyen;
                //drlquanhuyen.DataValueField = "DistrictID";
                //drlquanhuyen.DataTextField = "DistrictName";
                //drlquanhuyen.DataBind();

                //WebAdicom.ProvincesDataTable Datatinh = new WebAdicom.ProvincesDataTable();
                //Datatinh = provincesController.GetData();
                //drltinh.DataSource = Datatinh;
                //drltinh.DataValueField = "ProvinceID";
                //drltinh.DataTextField = "ProvinceName";
                //drltinh.DataBind();
            }
            catch { }
        }
        public void LoadData()
        {
            try
            {
                this.Getbenhvien();
                this.GetRows();
                //if (role != 0)
                //{
                //    if (role == 1)

                //    if(role==3)
                //}
                if (row != null)
                {
                    txtbenhvien.Text = row.Tenbenhvien;
                    txtdate.Text = row.Dateup.ToString();
                    txtbitruyennhiem.Text = row.SoCabitruyennhiem.ToString();
                    txttuvong.Text = row.Socatuvong.ToString();
                    txtcacbienphaptrienkhai.Text = row.Cacbietphattrienkhai;
                    txtcacdenghi.Text = row.NhungDenghi;
                    try
                    {
                        drldichbenh.SelectedValue = row.Iddichbenh.ToString();
                    }
                    catch { }
                }
                else
                {
                    txtbenhvien.Text = rowbenhvien.Tenbenhvien;
                }
            }
            catch { }
        }
        public void Fefresh()
        {
            //txtbenhvien.Text = "";
            txtdate.Text = "";
            txtbitruyennhiem.Text = "";
            txttuvong.Text = "";
            txtcacbienphaptrienkhai.Text = "";
            txtcacdenghi.Text = "";
            drldichbenh.SelectedIndex = 0;
        }
        public void Save()
        {
            try
            {
                this.Getbenhvien();
                this.GetRows();
                if (row == null)
                    row = database.NewDulieuDichbenhRow();
                row.Tenbenhvien = rowbenhvien.Tenbenhvien;
                //row.Dateup = Convert.ToDateTime(txtdate.Text.ToString());
                if(txtdate.Text!="")
                    row.Dateup = Convert.ToDateTime(txtdate.Text.ToString());
                    else
                row.Dateup = DateTime.Now;
                row.SoCabitruyennhiem = Convert.ToInt32(txtbitruyennhiem.Text.ToString());
                row.Socatuvong = Convert.ToInt32(txttuvong.Text.ToString());
                row.Cacbietphattrienkhai = txtcacbienphaptrienkhai.Text;
                row.NhungDenghi = txtcacdenghi.Text;
                row.Idbenhvien = rowbenhvien.Idbenhvien;
                row.Iddichbenh = Convert.ToInt32(drldichbenh.SelectedValue);
                row.Tendichbenh = drldichbenh.SelectedItem.Text;
                row.Idtinh = rowbenhvien.Idtinh;
                row.Idhuyen = rowbenhvien.idquanhuyen;
                dulieuDichbenhController.SaveDulieuDichBenh(row);
                this.Fefresh();
                Response.Redirect("~/admin/DuLieuBenhDichs.aspx");
            }
            catch { }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToString();
        }
    }
}