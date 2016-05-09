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
    public partial class PartnerControl : System.Web.UI.UserControl
    {
        private PartnerController partnerController = new PartnerController(Adicom.Web.Properties.Settings.Default.webadicomConnectionString);
        public WebAdicom.partnerDataTable database = new WebAdicom.partnerDataTable();
        public WebAdicom.partnerRow row = null;
        public int IdNews = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        if (!Page.IsPostBack)
            {
                 this.LoadData();
            }
        }
        public void Fefresh()
        {
            txtTitleVn.Text = "";
            txtTitleEn.Text = "";
            txtContentVn.Value = "";
            txtContentEn.Value = "";
        }
        public void GetRows()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    IdNews = Convert.ToInt32(Request.QueryString["id"].ToString());
                    row = partnerController.getPartnerById(IdNews);
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
                    txtTitleVn.Text = row.Name_vn;
                    txtTitleEn.Text = row.Name_en;
                    txtContentVn.Value = row.Description_vn;
                    txtContentEn.Value = row.Description_en;
                    try
                    {
                        dltype.SelectedValue = row.type.ToString();
                    }
                    catch { }
                }
            }
            catch { }
        }
        public void Save()
        {
            try
            {
                this.GetRows();
                if (row == null)
                    row = database.NewpartnerRow();
                row.type = Convert.ToInt32(dltype.SelectedValue);
                row.Description_en = txtContentEn.Value;
                row.Description_vn = txtContentVn.Value;
                row.Name_en = txtTitleEn.Text;
                row.Name_vn = txtTitleVn.Text;
                row.logo = WebUtils.saveImages(FUpdImage, "partner");
                partnerController.savePartner(row);
                this.Fefresh();
                Response.Redirect("~/admin/listpartner.aspx");
            }
            catch { }

        }
    }
}