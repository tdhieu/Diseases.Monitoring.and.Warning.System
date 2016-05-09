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
    public partial class CareerControl : System.Web.UI.UserControl
    {
        private PageController pagecontroler = new PageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        WebAdicom.pagesRow row = pagecontroler.getPageByName("career");
                        if (row != null)
                        {
                            txtVN.Value = row.Content_vn;
                            txtEN.Value = row.Content_en;
                        }                        
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                WebAdicom.pagesDataTable datable = new WebAdicom.pagesDataTable();
                WebAdicom.pagesRow row = pagecontroler.getPageByName("career");
                if (row == null)
                    row = datable.NewpagesRow();
                row.Name = "career";
                row.Content_vn = txtVN.Value;
                row.Content_en = txtEN.Value;
                row.Edate = DateTime.Now;
                row.Mdate = DateTime.Now;
                row.Euser = "admin";
                row.MUser = "admin";
                pagecontroler.savePage(row);
            }
            catch { }
        }
    }
}