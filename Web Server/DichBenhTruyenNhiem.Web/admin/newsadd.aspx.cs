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

namespace Adicom.Web.admin
{
    public partial class newsadd : System.Web.UI.Page
    {
        public int IdNews = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string a = Request.QueryString["id"].ToString();
                }
                
            }
            
        }
         
        protected void NewsAdd1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
