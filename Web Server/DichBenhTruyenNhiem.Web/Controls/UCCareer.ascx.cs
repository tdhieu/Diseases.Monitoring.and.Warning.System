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
    public partial class UCCareer : System.Web.UI.UserControl
    {
        private PageController pageController = new PageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                WebAdicom.pagesRow row = pageController.getPageByName("career");
                if (row != null)
                {
                    litCareer.Text = WebUtils.GetLanguageValue( row.Content_vn, row.Content_en);
                }
            }
            catch
            {
            }

        }
    }
}