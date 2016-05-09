using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;
using Adicom.Web.Code;
using System.Data;
using System.Data.SqlClient;

namespace Adicom.Web.Code
{
    [DataObject]
    public class GetDataController: BaseController
    {
        public string connectionstring = ConfigurationManager.ConnectionStrings["webadicomConnectionString"].ConnectionString;
        public SqlConnection sqlcon;

        public string GetHospitalName(object param)
        {
            int id = Convert.ToInt16(param);
            sqlcon = new SqlConnection(connectionstring);
            string query = "Select tenbenhvien From Benhvien Where idbenhvien=@idbenhvien";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.Parameters.AddWithValue("@idbenhvien", id);
            sqlcon.Open();
            string tenbenhvien = sqlcmd.ExecuteScalar().ToString();
            sqlcon.Close();
            return tenbenhvien;
        }

        public string GetDistrictName(object param)
        {
            int id = Convert.ToInt16(param);
            sqlcon = new SqlConnection(connectionstring);
            string query = "Select DistrictName From Districts Where DistrictID=@idhuyen";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.Parameters.AddWithValue("@idhuyen", id);
            sqlcon.Open();
            string tenhuyen = sqlcmd.ExecuteScalar().ToString();
            sqlcon.Close();
            return tenhuyen;
        }

        public string GetProvinceName(object param)
        {
            int id = Convert.ToInt16(param);
            sqlcon = new SqlConnection(connectionstring);
            string query = "Select ProvinceName From Provinces Where ProvinceID=@idtinh";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.Parameters.AddWithValue("@idtinh", id);
            sqlcon.Open();
            string tentinh = sqlcmd.ExecuteScalar().ToString();
            sqlcon.Close();
            return tentinh;
        }

        public string GetDiseaseName(object param)
        {
            int id = Convert.ToInt16(param);
            sqlcon = new SqlConnection(connectionstring);
            string query = "Select TenBenhDich From DichBenh Where IDBenhDich=@idbenhdich";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.Parameters.AddWithValue("@idbenhdich", id);
            sqlcon.Open();
            string tenbenhdich = sqlcmd.ExecuteScalar().ToString();
            sqlcon.Close();
            return tenbenhdich;
        }
    }

}
