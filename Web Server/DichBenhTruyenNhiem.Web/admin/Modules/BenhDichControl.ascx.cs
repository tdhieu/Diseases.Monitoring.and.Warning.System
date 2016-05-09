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
    public partial class BenhDichControl : System.Web.UI.UserControl
    {
        private DichBenhController dichBenhController = new DichBenhController();
        public WebAdicom.DichBenhDataTable database = new WebAdicom.DichBenhDataTable();
        public WebAdicom.DichBenhRow row = null;
        public int Iddichbenh = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadData();
            }
        }
        public void GetRows()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    Iddichbenh = Convert.ToInt32(Request.QueryString["id"].ToString());
                    row = dichBenhController.GetDataById(Iddichbenh);
                }
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
                    txtbenhvien.Text = row.TenBenhDich;
                    txtghichu.Text = row.GhiChu;
                    txtdate.Text = row.NgayBatDau.ToString();
                }
            }
            catch { }
        }
        public void Fefresh()
        {
                txtbenhvien.Text = "";
                txtghichu.Text="";
                txtdate.Text = "";
        }
        public void Save()
        {
            try
            {
                this.GetRows();
                if (row == null)
                    row = database.NewDichBenhRow();
                row.TenBenhDich = txtbenhvien.Text;
                row.GhiChu = txtghichu.Text;
                row.NgayBatDau = DateTime.Now;
                dichBenhController.SaveDichBenh(row);
                this.Fefresh();
                Response.Redirect("~/admin/BenhDichs.aspx");
            }
            catch { }
        }
    }
}