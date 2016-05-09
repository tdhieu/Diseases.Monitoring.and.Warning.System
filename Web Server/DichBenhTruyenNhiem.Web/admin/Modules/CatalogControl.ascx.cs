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
    public partial class CatalogControl : System.Web.UI.UserControl
    {
        private ProductController productController = new ProductController(Adicom.Web.Properties.Settings.Default.webadicomConnectionString);
        public WebAdicom.servicesDataTable database = new WebAdicom.servicesDataTable();
        public WebAdicom.servicesRow row = null;
        public int IdNews = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                  LoadData();
            }
        }
        public void GetId()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    IdNews = Convert.ToInt32(Request.QueryString["id"].ToString());
                    row = productController.getServiceById(IdNews);
                }
            }
            catch { }
        }
        public void LoadData()
        {
            try{
            GetId();
            if (row != null)
            {
                try
                {
                    if (row.category.ToString() == "1")
                        dltype.SelectedValue = "3";
                    if (row.category.ToString() == "2")
                        dltype.SelectedValue = "4";
                }
                catch { }
                try
                {

                    dlCategory.SelectedValue = row.type.ToString();
                }
                catch { }
                txtTitleVn.Text = row.Name_vn;
                txtTitleEn.Text = row.Name_en;
                txtShortVn.Text = row.Short_vn;
                txtShortEn.Text = row.Short_en;
                txtContentVn.Value = row.Description_vn;
                txtContentEn.Value = row.Description_en;
            }
               
            }
            catch { }
        }
        public void Save()
        {
            try
            {
                database.NewservicesRow();
                GetId();
                if (row == null)
                    row = database.NewservicesRow();
                row.type = Convert.ToInt32(dlCategory.SelectedValue);
                row.category = Convert.ToInt32(dltype.SelectedValue);

                row.Name_vn = txtTitleVn.Text;
                row.Name_en = txtTitleEn.Text;
                row.Short_vn = txtShortVn.Text;
                row.Short_en = txtShortEn.Text;
                row.Description_vn = txtContentVn.Value;
                row.Description_en = txtContentEn.Value;
                if (row.type == 1 && row.category > 2)
                    return;
                if (row.type == 2 && row.category <= 2)
                    return;
                if (dltype.SelectedValue == "3")
                    row.category = 1;
                if (dltype.SelectedValue == "4")
                    row.category = 2;
                row.picture = WebUtils.saveImages(FUpdImage, "product");
                productController.saveProduct(row);
                this.Fefresh();
                Response.Redirect("~/admin/listcatalog.aspx");
            }
            catch { }

        }
         public void Fefresh()
        {
            dlCategory.SelectedIndex=0;
            dltype.SelectedIndex=0;
            txtTitleEn.Text = "";
            txtTitleVn.Text = "";
            txtShortVn.Text = "";
            txtShortEn.Text = "";
            txtContentVn.Value = "";
            txtContentEn.Value = "";
        }
    }
}