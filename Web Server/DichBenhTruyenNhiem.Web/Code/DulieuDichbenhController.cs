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
    public class DulieuDichbenhController:BaseController
    {
        private DulieuDichbenhTableAdapter _DulieuDichbenhTableAdapter;
        public DulieuDichbenhController()
        {
        }
        public DulieuDichbenhController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public WebAdicom.DulieuDichbenhDataTable GetData()
        {
            return Adapter.GetData();
        }
        
        protected DulieuDichbenhTableAdapter Adapter
        {
            get
            {
                if (this._DulieuDichbenhTableAdapter== null)
                {
                    this._DulieuDichbenhTableAdapter = new DulieuDichbenhTableAdapter();
                    this._DulieuDichbenhTableAdapter.Connection.ConnectionString = this.connectionString;
                }
                return this._DulieuDichbenhTableAdapter;
            }

        }
        //public WebAdicom.GetdichbenhDataTable ListDS(int benhvien, int dichbenh, int tinh, int huyen, DateTime fromday, DateTime today)
        //{
        //    return Adapter
        //}
        public int DeleteId(int id)
        {
            return Adapter.DeleteById(id);
        }
        public WebAdicom.DulieuDichbenhDataTable GetDataByIdbenhvien(int id)
        {
            return Adapter.GetDataByIdbenhvien(id);
        }
        public WebAdicom.DulieuDichbenhRow GetDataById(int id)
        {
            WebAdicom.DulieuDichbenhDataTable dataTable = Adapter.GetDataById(id);
            if (dataTable.Count != 1) return null;
            return dataTable[0];
        }
        public WebAdicom.DulieuDichbenhDataTable GetListDuLieu(int idbenhvien,int iddichbenh,int idtinh, int idhuyen,DateTime tungay,DateTime dengay)
        {
            return Adapter.GetListDichBenh(idbenhvien,iddichbenh,idtinh,idhuyen,tungay,dengay);
        }
        public int SaveDulieuDichBenh(WebAdicom.DulieuDichbenhRow row)
        {
            try
            {
                if (Adapter.GetDataById(row.Iddulieu).Count == 1)
                    return Adapter.Update(row);
            }
            catch { }

            return Adapter.Insert(row.Idbenhvien,row.Tenbenhvien,row.Iddichbenh,row.Tendichbenh,row.Dateup,row.SoCabitruyennhiem,row.Socatuvong,row.Cacbietphattrienkhai,row.NhungDenghi,row.Idtinh,row.Idhuyen);
        }
        
    }
    public class DuLieu_Dichbenh
    {
        private DateTime Ngay;

        public DateTime Ngay1
        {
            get { return Ngay; }
            set { Ngay = value; }
        }
        private int tuvong, truyennhiem;

        public int Truyennhiem
        {
            get { return truyennhiem; }
            set { truyennhiem = value; }
        }

        public int Tuvong
        {
            get { return tuvong; }
            set { tuvong = value; }
        }
        public DuLieu_Dichbenh(DateTime ngay, int truyennhiem, int tuvong)
        {
            Ngay1 = ngay;
            Tuvong = tuvong;
            Truyennhiem = truyennhiem;
        }
    }
}
