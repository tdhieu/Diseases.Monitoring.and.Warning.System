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
    public class RoleControl:BaseController
    {
        private rolesTableAdapter _RolesTableAdapter;
        public RoleControl()
        {
        }
        public RoleControl(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public WebAdicom.rolesDataTable GetData()
        {
            return Adapter.GetData();
        }
        protected rolesTableAdapter Adapter
        {
            get
            {
                if (this._RolesTableAdapter == null)
                {
                    this._RolesTableAdapter = new rolesTableAdapter();
                    this._RolesTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._RolesTableAdapter;
            }
        }
    }
    }

