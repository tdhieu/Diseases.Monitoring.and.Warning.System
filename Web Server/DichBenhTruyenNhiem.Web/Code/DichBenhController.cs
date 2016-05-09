using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;
using System.ComponentModel;

namespace Adicom.Web.Code
{
    [DataObject]
    public class DichBenhController:BaseController
    {
        private DichBenhTableAdapter _DichBenhTableAdapter;
        public DichBenhController()
        {
        }
        public DichBenhController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int DeleteById(int id)
        {
            return Adapter.DeleteById(id);
        }
        public WebAdicom.DichBenhDataTable GetList(int id)
        {
            return Adapter.GetDataByIddichbenh(id);
        }
        public WebAdicom.DichBenhDataTable GetData()
        {
            return Adapter.GetData();
        }
        public WebAdicom.DichBenhRow GetDataById(int id)
        {
            WebAdicom.DichBenhDataTable database = Adapter.GetDataById(id);
            if (database.Count != 1) return null;
            return database[0];
        }
        public int SaveDichBenh(WebAdicom.DichBenhRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.IdBenhDich).Count == 1)
                    return Adapter.Update(row);
            }
            catch{}
            return Adapter.Insert(row.TenBenhDich,row.GhiChu,row.NgayBatDau);
        }
        protected DichBenhTableAdapter Adapter
        {
            get
            {
                if (this._DichBenhTableAdapter== null)
                {
                    this._DichBenhTableAdapter = new DichBenhTableAdapter();
                    this._DichBenhTableAdapter.Connection.ConnectionString = this.connectionString;
                }                
                return this._DichBenhTableAdapter;
            }
        }
    }
}
