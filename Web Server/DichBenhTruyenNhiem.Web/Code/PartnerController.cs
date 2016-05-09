using System;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;
namespace Adicom.Web.Code
{
    [DataObject]
    public class PartnerController : BaseController
    {
        private partnerTableAdapter _PartnerTableAdapter;

        public PartnerController()
        {
        }

        public PartnerController(string connectionString)
        {
            this.connectionString = connectionString;
        }


        protected partnerTableAdapter Adapter
        {
            get
            {
                if (this._PartnerTableAdapter == null)
                {
                    this._PartnerTableAdapter = new partnerTableAdapter();
                    this._PartnerTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._PartnerTableAdapter;
            }
        }


        public WebAdicom.partnerDataTable GetData()
        {
            return Adapter.GetData();
        }

        public WebAdicom.partnerDataTable GetDataByType(int type)
        {
            return Adapter.GetDataByType(type);
        }

        public int savePartner(WebAdicom.partnerRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.id).Count == 1)
                    return Adapter.Update(row);
            }
            catch { }

            return Adapter.Insert(row.type, row.Name_vn, row.Name_vn, row.Description_vn, row.Description_en, row.logo);
        }

        public int deletePartner(int id)
        {
            return Adapter.DeleteById(id);
        }


        public WebAdicom.partnerRow getPartnerById(int id)
        {
            WebAdicom.partnerDataTable dataTable = Adapter.GetDataById(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }

        public WebAdicom.partnerDataTable getPartnerByType(int type)
        {
            WebAdicom.partnerDataTable dataTable = Adapter.GetDataByType(type);
            return dataTable;
        }
    }
}
