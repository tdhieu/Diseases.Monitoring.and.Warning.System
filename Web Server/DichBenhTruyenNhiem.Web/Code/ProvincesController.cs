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
    public class ProvincesController:BaseController
    {
        private ProvincesTableAdapter _ProvincesTableAdapter;
        public ProvincesController()
        {
        }
        public ProvincesController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected ProvincesTableAdapter Adapter
        {
            get
            {
                if (this._ProvincesTableAdapter== null)
                {
                    this._ProvincesTableAdapter= new ProvincesTableAdapter();
                    this._ProvincesTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._ProvincesTableAdapter;
            }
        }
        public WebAdicom.ProvincesDataTable GetData()
        {
            return Adapter.GetData();
        }
    }
}
