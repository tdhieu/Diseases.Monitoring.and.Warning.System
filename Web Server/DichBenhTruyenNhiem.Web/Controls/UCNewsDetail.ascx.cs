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

namespace Adicom.Web.Controls
{
    public partial class UCNewsDetail : System.Web.UI.UserControl
    {
        private NewsController newsController = new NewsController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    WebAdicom.newsRow row = newsController.getNewsById(Convert.ToInt32(Request["id"]));
                    if (row != null)
                    {
                        litNews.Text = WebUtils.GetLanguageValue(row.content_vn, row.content_en);
                        ltPublishDate.Text = row.publish_date.ToShortDateString();
                        Page.Title = WebUtils.GetLanguageValue(row.title_vn, row.title_en);
                        (Page.Master.FindControl("ltTitleMain") as Literal).Text = WebUtils.GetLanguageValue(row.title_vn, row.title_en);
                    }
                }
                catch
                {
                }
            }

        }
        
    }
}