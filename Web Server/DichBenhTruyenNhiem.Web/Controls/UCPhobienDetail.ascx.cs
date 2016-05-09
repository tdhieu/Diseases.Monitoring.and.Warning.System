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
    public partial class UCPhobienDetail : System.Web.UI.UserControl
    {
        private PhoBienController phoBienController = new PhoBienController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    WebAdicom.PhobienRow row = phoBienController.GetDataBayId(Convert.ToInt32(Request["id"]));
                    if (row != null)
                    {
                        litContent.Text = WebUtils.GetLanguageValue(row.Description_vn, row.Description_en);
                        imgProduct.ImageUrl = "~/" + row.Pricte;
                        Page.Title = WebUtils.GetLanguageValue(row.Name_vn, row.Name_en);
                        (Page.Master.FindControl("ltTitleMain") as Literal).Text = WebUtils.GetLanguageValue(row.Name_vn, row.Name_en);
                    }
                }
                catch
                {
                }
            }
        }
    }
}