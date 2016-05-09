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
using Adicom.Web.DAL;
using Adicom.Web.Code;
namespace Adicom.Web.admin.Modules
{
    public partial class HomeControl : System.Web.UI.UserControl
    {
        private PageController pageController = new PageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        WebAdicom.pagesRow row = pageController.getPageByName("home");
                        if (row != null)
                        {
                            txtContentEn.Value = row.Content_en;
                            txtContentVn.Value = row.Content_vn;
                        }

                    }
                    catch
                    {
                    }
                }
            }
            catch { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                WebAdicom.pagesDataTable dataTable = new WebAdicom.pagesDataTable();
                WebAdicom.pagesRow row = pageController.getPageByName("home");
                if (row == null)
                    row = dataTable.NewpagesRow();
                row.Name = "home";
                row.Content_en = txtContentEn.Value;
                row.Content_vn = txtContentVn.Value;
                row.Edate = DateTime.Now;
                row.Mdate = DateTime.Now;
                row.Euser = "admin";
                row.MUser = "admin";
                pageController.savePage(row);
            }
            catch
            {
            }
        }
    }
}