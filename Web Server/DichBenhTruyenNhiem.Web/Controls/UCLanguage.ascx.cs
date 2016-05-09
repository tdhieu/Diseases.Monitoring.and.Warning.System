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

namespace Adicom.Web.Controls
{
    public partial class UCLanguage : System.Web.UI.UserControl
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

            string lang = string.Empty;//default to the invariant culture
            HttpCookie cookie = Request.Cookies["language"];

            if (cookie != null && cookie.Value != null)
            {
                lang = cookie.Value;
            }
            switch (lang)
            {

                case "vi-VN":
                    hplVietnamese.Visible = false;
                    hplEnglish.Visible = true;
                    hplEnglish.CssClass += " selectLanguage";
                    break;
                default:
                    hplVietnamese.Visible = true;
                    hplEnglish.Visible = false;
                    hplVietnamese.CssClass += " selectLanguage";
                    break;
            }
        }

        protected void onLanguageButtonClick(object sender, EventArgs e)
        {
            LinkButton lbtLanguage = (sender as LinkButton);
            string lang = string.Empty;
            switch (lbtLanguage.ID)
            {
                case "hplVietnamese":
                    lang = "vi-VN";
                    break;
                case "hplEnglish":
                    lang = "en-US";
                    break;
            }

            HttpCookie cookie = new HttpCookie("language");

            cookie.Value = lang;

            Response.SetCookie(cookie);

            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}