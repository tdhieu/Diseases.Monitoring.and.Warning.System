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

namespace Adicom.Web.admin.Modules
{
    public partial class BenhDichAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                BenhDichControl1.Save();
            }
            catch
            { }
        }
    }
}