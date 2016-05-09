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
    public class BenhVienController:BaseController
    {
        private BenhvienTableAdapter _BenhvienTableAdapter;
        public BenhVienController()
        {
        }
        public BenhVienController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public WebAdicom.BenhvienDataTable GetDataByList(int id)
        {
            return Adapter.GetDataByList(id);
        }
        public WebAdicom.BenhvienDataTable GetData()
        {
            return Adapter.GetData();
        }
        public int DeleteById(int id)
        {
            return Adapter.DeleteById(id);
        }
        public WebAdicom.BenhvienRow GetDataByIdtinh(int id)
        {
            WebAdicom.BenhvienDataTable dataTable = Adapter.GetDataByIdtinh(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }
        public WebAdicom.BenhvienRow GetDataByIquanhuyen(int id)
        {
            WebAdicom.BenhvienDataTable dataTable = Adapter.GetDataByIdquanhuyen(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }
        public WebAdicom.BenhvienRow GetDataById(int id)
        {
            WebAdicom.BenhvienDataTable dataTable = Adapter.GetDataById(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }
        public int SaveBenhvien(WebAdicom.BenhvienRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.Idbenhvien).Count == 1)
                    return Adapter.Update(row);
            }
            catch { }

            return Adapter.Insert(row.Tenbenhvien, row.Idtinh, row.idquanhuyen, row.Ghichu, row.dichchi, row.nguoidaidien, row.telephone, row.Email,row.fax,row.website);
        }
        protected BenhvienTableAdapter Adapter
        {
            get
            {
                if (this._BenhvienTableAdapter== null)
                {
                    this._BenhvienTableAdapter = new BenhvienTableAdapter();
                    this._BenhvienTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._BenhvienTableAdapter;
            }
        }
    }
}
