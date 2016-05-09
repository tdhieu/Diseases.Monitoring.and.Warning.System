using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;
using Adicom.Web.DAL.WebAdicomTableAdapters;
using Adicom.Web.DAL;

namespace Adicom.Web.Code
{
    [DataObject]
    public class InformationController:BaseController
    {
        private informationTableAdapter _InformationTableAdapter;

        public InformationController()
        {
        }

        public InformationController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public WebAdicom.informationRow getInformation()
        {
            WebAdicom.informationDataTable dataTable = Adapter.GetData();
            if (dataTable.Rows.Count <= 0) return null;
            return dataTable[0];
        }

        //public int saveInformation(WebAdicom.informationRow row)
        //{
        //    try
        //    {
        //        if (Adapter.GetData().Count == 1)
        //            return Adapter.Update(row);
        //    }
        //    catch { }
        //    return Adapter.Insert(row.id, row.Name_vn, row.Name_en, row.Tel, row.Fax, row.Email, row.slogan_vn, row.slogan_en, row.keyword_vn, row.keyword_en, row.description_vn, row.description_en, row.Edate, row.Euser, row.Mdate, row.Muser, row.contactperson);
        //}

        protected informationTableAdapter Adapter
        {
            get
            {
                if (this._InformationTableAdapter == null)
                {
                    this._InformationTableAdapter = new informationTableAdapter();
                    this._InformationTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._InformationTableAdapter;
            }
        }
    }
}
