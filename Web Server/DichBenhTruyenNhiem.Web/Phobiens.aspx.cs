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
using Adicom.Web.Controls;
namespace Adicom.Web
{
    public partial class Phobiens : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                UCServicesDetail1.Visible = false;
                UCServices1.Visible = true;
            }
            else
            {
                UCServicesDetail1.Visible = true;
                UCServices1.Visible = false;
            }
        }
    }
}
