using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;
using Adicom.Web.Code;
using DevExpress.Web.ASPxEditors;
using System.Drawing;

namespace Adicom.Web.admin.Modules
{
    public partial class MailList : System.Web.UI.UserControl
    {
        BaseController basecontroller = new BaseController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateRepeater();
            }
        }

        protected void GenerateRepeater()
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(basecontroller.connectionString);
                string query = "select idthongbao, ngaygui, tieude, trangthai from BC_ThongBao";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                SqlDataAdapter adpt = new SqlDataAdapter(sqlcmd);
                DataTable myDataSet = new DataTable();
                adpt.Fill(myDataSet);
                // Repeater Control Databinding using Datasource
                Repeater Repeater1 = new Repeater();
                Repeater1.DataSource = myDataSet;
                Repeater1.DataBind();

                int id, isNew;
                foreach (RepeaterItem repeatItem in Repeater1.Items)
                {
                    // if condition to add HeaderTemplate Dynamically only Once
                    if (repeatItem.ItemIndex == 0)
                    {
                        RepeaterItem headerItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Header);
                        HtmlGenericControl hTag = new HtmlGenericControl("h4");
                        hTag.InnerHtml = string.Format("<font style=\"font-family:Times New Roman; font-size:large;\">{0}</font><br /><br />", "Danh Sách Thông Báo:");
                        repeatItem.Controls.Add(hTag);
                    }
                    id = Convert.ToInt16(myDataSet.Rows[repeatItem.ItemIndex]["idthongbao"]);
                    isNew = Convert.ToInt16(myDataSet.Rows[repeatItem.ItemIndex]["trangthai"]);
                    // Add ItemTemplate DataItems Dynamically
                    RepeaterItem repeaterItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Item);
                    Label lbl = new Label();
                    lbl.Text = string.Format("<br />{0} ", Convert.ToDateTime(myDataSet.Rows[repeatItem.ItemIndex]["ngaygui"]).ToShortDateString() + " ");
                    HyperLink hpl = new HyperLink();
                    if (isNew == 1) hpl.Text = string.Format("{0} <br /><br />", myDataSet.Rows[repeatItem.ItemIndex]["tieude"]);
                    else hpl.Text = string.Format("{0} <br /><br />", myDataSet.Rows[repeatItem.ItemIndex]["tieude"] + " (new)");
                    hpl.NavigateUrl = "~/admin/XemThongBao.aspx?id=" + id.ToString();
                    repeatItem.Controls.Add(lbl);
                    repeatItem.Controls.Add(hpl);

                    // Add SeparatorTemplate Dynamically
                    repeaterItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Separator);
                    LiteralControl ltrlHR = new LiteralControl();
                    ltrlHR.Text = "<hr />";
                    repeatItem.Controls.Add(ltrlHR);
                }

                // Add Repeater Control as Child Control of Panel Control                
                Panel1.Controls.Add(Repeater1);
            }
            catch { }        
        }
    }
}