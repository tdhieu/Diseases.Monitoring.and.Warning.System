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
using Localization;
using System.IO;
using System.Text;
using Adicom.Web.Code;

namespace Adicom.Web.Controls
{
    public partial class UCContactUs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                for (int i = 0; i < 6; i++)
                {
                    ListItem listItem = new ListItem(ResourceManager.GetString("reason" + (i + 1)));
                    dlReason.Items.Add(listItem);
                }
                btnSend.Text = ResourceManager.GetString("send");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            StreamReader re = File.OpenText(HttpContext.Current.Request.PhysicalApplicationPath + "\\email\\contactus.html");
            StringBuilder contactusString = new StringBuilder();
            string input = null;
            while ((input = re.ReadLine()) != null)
            {
                contactusString.Append(input);
            }
            re.Close();
            contactusString.Replace("$name$", txtName.Text);
            contactusString.Replace("$email$", txtEmail.Text);
            contactusString.Replace("$phone$", txtTelephone.Text);
            contactusString.Replace("$company$", textCompany.Text);
            contactusString.Replace("$city$", txtCity.Text);
            contactusString.Replace("$country$", txtCountry.Text);
            contactusString.Replace("$content$", txtRequest.Text);
            contactusString.Replace("$reason$", dlReason.SelectedValue);
            WebUtils.sendmail(txtEmail.Text, "khoipm@adicom.com.vn", "ADICOM JSC - Contact from Customer", contactusString.ToString());
            lbMessage.Text = ResourceManager.GetString("thanks");
            txtName.Text = "";
            txtTelephone.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtRequest.Text = "";
            textCompany.Text = "";
        }

      
    }
}