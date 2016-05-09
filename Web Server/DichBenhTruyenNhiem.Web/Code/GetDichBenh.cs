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
    public class GetDichBenh:BaseController
    {
        private GetdichbenhTableAdapter _GetdichbenhTableAdapter;
        public GetDichBenh()
        {
        }
        public GetDichBenh(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected GetdichbenhTableAdapter Adapter
        {
            get
            {
                if (this._GetdichbenhTableAdapter == null)
                {
                    this._GetdichbenhTableAdapter= new GetdichbenhTableAdapter();
                    this._GetdichbenhTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._GetdichbenhTableAdapter;
            }

        }
        public WebAdicom.GetdichbenhDataTable ListDS(int? benhvien, int? dichbenh, int? tinh, int? huyen, DateTime? fromday, DateTime? today)
        {
            return Adapter.GetDataDichBenh(benhvien,dichbenh,tinh,huyen,fromday,today);
        }
    }
}
