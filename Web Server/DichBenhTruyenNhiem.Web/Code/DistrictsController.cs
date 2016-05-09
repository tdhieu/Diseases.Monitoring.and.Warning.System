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
    public class DistrictsController:BaseController
    {
        private DistrictsTableAdapter _DistrictsTableAdapter;
        public DistrictsController()
        {
        }
        public DistrictsController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public WebAdicom.DistrictsDataTable GetData()
        {
            return Adapter.GetData();
        }
        protected DistrictsTableAdapter Adapter
        {
            get
            {
                if (this._DistrictsTableAdapter== null)
                {
                    this._DistrictsTableAdapter= new DistrictsTableAdapter();
                    this._DistrictsTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._DistrictsTableAdapter;
            }

        }
        public WebAdicom.DistrictsDataTable GetListDistricts(int id)
        {
            return Adapter.GetDataByProvince(id);
        }
        public WebAdicom.DistrictsRow GetrowProvince(int id)
        {
            WebAdicom.DistrictsDataTable dataTable = Adapter.GetDataByIdDistrict(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }
    }
}
