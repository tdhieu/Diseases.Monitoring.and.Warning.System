using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Adicom.Web.Code;
using Adicom.Web.DAL;
using Localization;

namespace Adicom.Web.admin.Modules
{
    public partial class NewsControl : System.Web.UI.UserControl
    {
        private NewsController newscontroler = new NewsController();
        public WebAdicom.newsDataTable database = new WebAdicom.newsDataTable();
        public WebAdicom.newsRow row = null;
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
            txtShortVn.Text = "";
            txtShortEn.Text = "";
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
                    row = newscontroler.getNewsById(IdNews);
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
                    txtTitleVn.Text = row.title_vn;
                    txtTitleEn.Text = row.title_en;
                    txtShortVn.Text = row.short_vn;
                    txtShortEn.Text = row.short_en;
                    txtPDate.Text = string.Format("{0:MMM dd, yyyy}", row.approve_date);
                    txtContentVn.Value = row.content_vn;
                    txtContentEn.Value = row.content_en;
                    try
                    {
                        dlCategory.SelectedValue = row.category.ToString();
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
                    row = database.NewnewsRow();
                row.approve_date = DateTime.Now;
                row.publish_date = DateTime.Now;
                row.approve_user = "admin";
                row.publish_user = "admin";
                row.status = Cbstar.Checked ? 1 : 0;
                row.content_en = txtContentEn.Value;
                row.content_vn = txtContentVn.Value;
                row.title_en = txtTitleEn.Text;
                row.title_vn = txtTitleVn.Text;
                row.short_en = txtShortEn.Text;
                row.short_vn = txtShortVn.Text;
                row.picture = WebUtils.saveImages(FUpdImage, "news");
                row.category = Convert.ToInt32(dlCategory.SelectedValue);
                newscontroler.saveNews(row);
                this.Fefresh();
                Response.Redirect("~/admin/listnews.aspx");
            }
            catch { }

        }
    }
}
