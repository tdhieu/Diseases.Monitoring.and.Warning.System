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
namespace Adicom.Web.Code
{
    public class UsersController:BaseController
    {
        private usersTableAdapter _UserTableAdapter;

        public UsersController()
        {
        }

        public UsersController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public WebAdicom.usersDataTable GetData()
        {
            return Adapter.GetData();
        }
        public WebAdicom.usersDataTable GetByTenBenhVien(string Name)
        {
            return Adapter.GetDataBytenbenhvien(Name);
        }
        public WebAdicom.usersRow GetByUserName(string userName)
        {
            WebAdicom.usersDataTable dataTable = Adapter.GetUserByName(userName);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }
        public int DeleteById(int id)
        {
            return Adapter.DeleteById(id);
        }
        public int SaveUser(WebAdicom.usersRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.id).Count == 1)
                    return Adapter.Update(row);
            }
            catch { }

            return Adapter.Insert(row.user_name, row.password, row.role, row.idbenhvien,row.tenbenhvien);
        }

        protected usersTableAdapter Adapter
        {
            get
            {
                if (this._UserTableAdapter == null)
                {
                    this._UserTableAdapter = new usersTableAdapter();
                    this._UserTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._UserTableAdapter;
            }
        }
    }
}
