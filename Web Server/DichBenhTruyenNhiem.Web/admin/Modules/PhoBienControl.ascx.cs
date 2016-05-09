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
    public partial class PhoBienControl : System.Web.UI.UserControl
    {
        private PhoBienController phoBienController = new PhoBienController();
        public WebAdicom.PhobienDataTable database = new WebAdicom.PhobienDataTable();
        public WebAdicom.PhobienRow row = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dlPhoBien.SelectedIndex = 0;
                this.LoadData();
            }
        }
        public void LoadData()
        {
            bool ret = false;
            try
            {
           ret= this.GetById();
           if (ret != true)
           {
               try
               {
                   dlPhoBien.SelectedValue = row.type.ToString();
               }
               catch { }
               txtTitleVn.Text = row.Name_vn;
               txtTitleEn.Text = row.Name_en;
               txtShortVn.Text = row.Short_vn;
               txtShortEn.Text = row.Short_en;
               txtContentVn.Value = row.Description_vn;
               txtContentEn.Value = row.Description_en;
               //try
               //{
               //    FUpdImage.FileName = row.Pricte.ToString();
               //}
               //catch { }
           }
            }
                catch
            {
                }
            }
        public void Fefresh()
        {
            txtTitleVn.Text = "";
            txtTitleEn.Text = "";
            txtShortVn.Text = "";
            txtShortEn.Text = "";
            txtContentVn.Value = "";
            txtContentEn.Value = "";
            dlPhoBien.SelectedIndex = 0;
        }
        public bool GetById()
        {
            bool ret = false;
            
                if (Request.QueryString["id"] != null)
                {
                    row = phoBienController.GetDataBayId(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    if (row == null)
                        ret = true;
                    else ret = false;
                }
                return ret;
          
        }
        public void Save()
        {
            try
            {
                bool ret = false;
                ret = this.GetById();
                if (ret == true)
                    row = database.NewPhobienRow();
                row.Name_vn = txtTitleVn.Text;
                row.Name_en = txtTitleEn.Text;
                row.Short_vn = txtShortVn.Text;
                row.Short_en = txtShortEn.Text;
                row.Description_vn = txtContentVn.Value;
                row.Description_en = txtContentEn.Value;
                row.type = Convert.ToInt32(dlPhoBien.SelectedValue);
                row.Pricte = WebUtils.saveImages(FUpdImage, "phobienkienthuc");
                phoBienController.SavePhoBien(row);
                this.Fefresh();
                Response.Redirect("~/admin/Phobiens.aspx");
            }
            catch
            {
            }
        }
    }
}