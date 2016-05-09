using System;
using System.Data;
using System.Configuration;

using System.ComponentModel;
using Adicom.Web.DAL;
using Adicom.Web.DAL.WebAdicomTableAdapters;

namespace Adicom.Web.Code
{
    [DataObject]
    public class NewsController : BaseController
    {
        private newsTableAdapter _NewsTableAdapter;

        public NewsController()
        {
        }

        public NewsController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public WebAdicom.newsDataTable GetData()
        {
            return Adapter.GetData();
        }

        public WebAdicom.newsDataTable GetLatestNews()
        {
            return Adapter.GetLatestNews();
        }

        public WebAdicom.newsDataTable GetNewsByCategory(int category)
        {
            return Adapter.GetDataByCategory(category);
        }


        public int GetCount()
        {
            return (int)Adapter.GetCount();
        }

        //public WebAdicom.newsDataTable getPageAndSort(string sortExpression, int startRowIndex, int maximumRows)
        //{
        //    return Adapter.GetPageAndSort(sortExpression, startRowIndex, maximumRows);

        //}

        public int deleteNews(int id)
        {
            return Adapter.DeleteById(id);
        }

        public WebAdicom.newsRow getNewsById(int id)
        {
            WebAdicom.newsDataTable dataTable = Adapter.GetDataById(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }

        public int saveNews(WebAdicom.newsRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.id).Count == 1)
                    return Adapter.Update(row);
            }
            catch { }

            return Adapter.Insert(row.title_vn, row.title_en, row.content_vn, row.content_en, row.short_vn, row.short_en, row.publish_date, row.publish_user, (byte)(row.status), row.picture, row.approve_date, row.approve_user, row.category);
        }

        protected newsTableAdapter Adapter
        {
            get
            {
                if (this._NewsTableAdapter == null)
                {
                    this._NewsTableAdapter = new newsTableAdapter();
                    this._NewsTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._NewsTableAdapter;
            }
        }
    }
}
