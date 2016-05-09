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
using Localization;
using System.Threading;
using System.Globalization;
using Adicom.Web.Controls;
using Adicom.Web.DAL;
using Adicom.Web.Code;
namespace Adicom.Web
{
    public partial class home : BasePage
    {
        private PageController pageController = new PageController();
        protected void Page_Load(object sender, EventArgs e)
        {
             try {
                WebAdicom.pagesRow row = pageController.getPageByName("home");
                if (row != null)
                {
                    litHome.Text = WebUtils.GetLanguageValue(row.Content_vn, row.Content_en);
                    
                }

            }catch {
            }
            
            
        }
    }
}
