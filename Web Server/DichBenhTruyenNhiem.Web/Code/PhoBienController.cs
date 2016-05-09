using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
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
    public class PhoBienController : BaseController
    {
        private PhobienTableAdapter _PhobienTableAdapter;
        public PhoBienController()
        {
        }
        public PhoBienController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public WebAdicom.PhobienDataTable GetData()
        {
            return Adapter.GetData();
        }
        protected PhobienTableAdapter Adapter
        {
            get
            {
                if (this._PhobienTableAdapter == null)
                {
                    this._PhobienTableAdapter = new PhobienTableAdapter();
                    this._PhobienTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._PhobienTableAdapter;
            }

        }
        public int DeleteId(int id)
        {
            return Adapter.DeleteById(id);
        }
        public WebAdicom.PhobienRow GetDataBayId(int id)
        {
            WebAdicom.PhobienDataTable dataTable = Adapter.GetDataById(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }
        public int SavePhoBien(WebAdicom.PhobienRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.id).Count == 1)
                    return Adapter.Update(row);
            }
            catch { }

            return Adapter.Insert(row.type,row.Name_vn, row.Name_en, row.Description_vn, row.Description_en, row.Pricte, row.Short_vn, row.Short_en);
        }
        public WebAdicom.PhobienDataTable GetPhoBienByType(int type)
        {
            WebAdicom.PhobienDataTable dataTable = Adapter.GetDataByType(type);
            return dataTable;
        }
    }
   
}
