using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;

namespace Adicom.Web.Code
{
    [DataObject]
    public class PageController : BaseController
    {
        private pagesTableAdapter _PagesTableAdapter;

        public PageController()
        {
        }

        public PageController(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public WebAdicom.pagesRow getPageByName(string name)
        {
            WebAdicom.pagesDataTable dataTable = Adapter.GetDataByPageName(name);
            if (dataTable.Count != 1) return null;

            return dataTable[0];
        }

        public int savePage(WebAdicom.pagesRow row)
        {
            if (Adapter.GetDataByPageName(row.Name).Count == 1)
                return Adapter.Update(row);
            else
                return Adapter.Insert(row.Name, row.Content_vn, row.Content_en, row.Edate, row.Mdate, row.Euser, row.MUser);
        }

        protected pagesTableAdapter Adapter
        {
            get
            {
                if (this._PagesTableAdapter == null)
                {
                    this._PagesTableAdapter = new pagesTableAdapter();
                    this._PagesTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._PagesTableAdapter;
            }
        }
    }
}
