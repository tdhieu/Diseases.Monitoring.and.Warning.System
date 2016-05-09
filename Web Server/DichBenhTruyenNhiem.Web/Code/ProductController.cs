using System;
using System.Data;
using System.Configuration;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;
using System.ComponentModel;
namespace Adicom.Web.Code
{
    [DataObject]
    public class ProductController:BaseController
    {
        private servicesTableAdapter _ProductTableAdapter;

        public ProductController()
        {
        }

        public ProductController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        

        protected servicesTableAdapter Adapter
        {
            get
            {
                if (this._ProductTableAdapter == null)
                {
                    this._ProductTableAdapter = new servicesTableAdapter();
                    this._ProductTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._ProductTableAdapter;
            }
        }

        public WebAdicom.servicesDataTable GetData()
        {
            return Adapter.GetData();
        }

        public WebAdicom.servicesDataTable GetDataByTypeAndCategory(int type, int category)
        {
            return Adapter.GetDataByTypeAndCategory(type, category);
        }

        public WebAdicom.servicesDataTable GetRandomServices()
        {
            return Adapter.GetRandomServices();
        }
        public int saveProduct(WebAdicom.servicesRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.id).Count == 1)
                    return Adapter.Update(row);
            }
            catch { }

            return  Adapter.Insert(row.type, row.Name_vn,row.Name_vn, row.Description_vn, row.Description_en, row.picture, row.category, row.Short_vn, row.Short_en);
        }

        public int deleteProduct(int id)
        {
            return Adapter.DeleteById(id);
        }

        public WebAdicom.servicesRow getServiceById(int id)
        {
            WebAdicom.servicesDataTable dataTable = Adapter.GetDataById(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }

        public WebAdicom.servicesDataTable getServiceByType(int type)
        {
            WebAdicom.servicesDataTable dataTable = Adapter.GetDataByType(type);
            return dataTable;
        }
    }
}
