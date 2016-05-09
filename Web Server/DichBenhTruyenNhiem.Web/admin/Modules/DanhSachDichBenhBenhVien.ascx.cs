using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Adicom.Web.Code;
using Adicom.Web.DAL;
using System.Web.UI.MobileControls;
using System.Data.SqlClient;
using DevExpress.XtraCharts;

namespace Adicom.Web.admin.Modules
{
    public partial class DanhSachDichBenhBenhVien : System.Web.UI.UserControl
    {
        private DulieuDichbenhController dulieuDichbenhController = new DulieuDichbenhController();
        private DistrictsController districtsController = new DistrictsController();
        private GetDichBenh getDichBenh = new GetDichBenh();
        public WebAdicom.DistrictsRow rowDis = null;
        public WebAdicom.BenhvienRow rowbenhvien = null;
        private ProvincesController provincesController = new ProvincesController();
        private DichBenhController dichBenhController = new DichBenhController();
        private BenhVienController benhVienController = new BenhVienController();
        public int? benhvien, dichbenh, tinh, quanhuyen;
        public DateTime? fromdate, todate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCombo();
               
            }
        }
        public void LoadCombo()
        {
            try
            {
                ListItem iadd = new ListItem("Chọn dữ liệu", null);
                WebAdicom.DistrictsDataTable DatabaseDistricts = new WebAdicom.DistrictsDataTable();
                DatabaseDistricts = districtsController.GetData();
                cbxHuyen.DataSource = DatabaseDistricts;
                cbxHuyen.DataValueField = "DistrictID";
                cbxHuyen.DataTextField = "DistrictName";
                cbxHuyen.DataBind();
                cbxHuyen.Items.Insert(0, iadd);

                WebAdicom.ProvincesDataTable provincesDataTable = new WebAdicom.ProvincesDataTable();
                provincesDataTable = provincesController.GetData();
                cbxTinh.DataSource = provincesDataTable;
                cbxTinh.DataValueField = "ProvinceID";
                cbxTinh.DataTextField = "ProvinceName";
                cbxTinh.DataBind();
                cbxTinh.Items.Insert(0, iadd);


                WebAdicom.BenhvienDataTable Databasebenhvien = new WebAdicom.BenhvienDataTable();
                Databasebenhvien = benhVienController.GetData();
                cbxbenhVien.DataSource = Databasebenhvien;
                cbxbenhVien.DataValueField = "Idbenhvien";
                cbxbenhVien.DataTextField = "Tenbenhvien";
                cbxbenhVien.DataBind();
                cbxbenhVien.Items.Insert(0, iadd);

                WebAdicom.DichBenhDataTable Databasedichbenh = new WebAdicom.DichBenhDataTable();
                Databasedichbenh = dichBenhController.GetData();
                cbxBenhDich.DataSource = Databasedichbenh;
                cbxBenhDich.DataValueField = "IdBenhDich";
                cbxBenhDich.DataTextField = "TenBenhDich";
                cbxBenhDich.DataBind();
                cbxBenhDich.Items.Insert(0, iadd);
            }
            catch { }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxbenhVien.SelectedIndex != 0)
                    benhvien = Convert.ToInt32(cbxbenhVien.SelectedValue.ToString());
                else
                    benhvien = null;
                if (cbxBenhDich.SelectedIndex != 0)
                    dichbenh = Convert.ToInt32(cbxBenhDich.SelectedValue.ToString());
                else
                    dichbenh = null;
                if (cbxBenhDich.SelectedIndex != 0)
                    dichbenh = Convert.ToInt32(cbxBenhDich.SelectedValue.ToString());
                else
                    dichbenh = null;
                if (cbxTinh.SelectedIndex != 0)
                    tinh = Convert.ToInt32(cbxTinh.SelectedValue.ToString());
                else
                    tinh = null;
                if (cbxHuyen.SelectedIndex != 0)
                    quanhuyen = Convert.ToInt32(cbxHuyen.SelectedValue.ToString());
                else
                    quanhuyen = null;
                if (txtDateFrom.Text != "")
                    fromdate = Convert.ToDateTime(txtDateFrom.Text.ToString());
                else
                    fromdate = null;
                if (txtDateto.Text != "")
                    todate = Convert.ToDateTime(txtDateto.Text.ToString());
                else
                    todate = null;
                WebAdicom.GetdichbenhDataTable database = new WebAdicom.GetdichbenhDataTable();
                database = getDichBenh.ListDS(benhvien,dichbenh,tinh,quanhuyen,fromdate,todate);
                
                gvNews.DataSource = database;
                gvNews.DataBind();

                List<DuLieu_Dichbenh> listDL = new List<DuLieu_Dichbenh>();
                foreach (DataRow row in database.Rows)
                {
                    try
                    {
                        DuLieu_Dichbenh obj = new DuLieu_Dichbenh(DateTime.ParseExact(row[0].ToString().Trim(),"dd/mm/yyyy",null), int.Parse(row[1].ToString()), int.Parse(row[2].ToString()));
                        listDL.Add(obj);
                    }
                    catch(Exception ex) { }
                }
                List<SeriesPoint> seriesPointTuvong = new List<SeriesPoint>();
                List<SeriesPoint> seriesPointTruyennhiem = new List<SeriesPoint>();
                foreach (DuLieu_Dichbenh tn in listDL)
                {
                    SeriesPoint obj = new SeriesPoint(tn.Ngay1, new double[] { tn.Truyennhiem });
                    seriesPointTruyennhiem.Add(obj);
                }

                foreach (DuLieu_Dichbenh tv in listDL)
                {
                    SeriesPoint objtv = new SeriesPoint(tv.Ngay1,new double[] {tv.Tuvong});
                    seriesPointTuvong.Add(objtv);
                }
                WebChartControltruyennhiem.Series[0].Points.Clear();
                WebChartControltruyennhiem.Series[0].Points.AddRange(seriesPointTuvong.ToArray());
                WebChartControltruyennhiem.Series[0].SeriesPointsSortingKey=SeriesPointKey.Argument;

                WebChartControl1.Series[0].Points.Clear();
                WebChartControl1.Series[0].Points.AddRange(seriesPointTruyennhiem.ToArray());
                WebChartControl1.Series[0].SeriesPointsSortingKey=SeriesPointKey.Argument;
                LoadCombo();
            }
            catch(Exception ex)
            { 
            
            }
        }

        protected void cbxTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxTinh.SelectedValue.ToString() != "Chọn dữ liệu")
                {
                    cbxHuyen.DataSource = districtsController.GetListDistricts(Convert.ToInt32(cbxTinh.SelectedValue.ToString()));
                    cbxHuyen.DataBind();

                    cbxbenhVien.DataSource = benhVienController.GetDataByIdtinh(Convert.ToInt32(cbxTinh.SelectedValue.ToString()));
                    cbxbenhVien.DataBind();
                }
            }
            catch { }
        }

        protected void cbxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxHuyen.SelectedValue.ToString() != "Chọn dữ liệu")
                {
                    rowDis = districtsController.GetrowProvince(Convert.ToInt32(cbxHuyen.SelectedValue.ToString()));
                    cbxTinh.SelectedValue = rowDis.ProvinceID.ToString();
                    cbxTinh.DataBind();

                    cbxbenhVien.DataSource = benhVienController.GetDataByIdtinh(Convert.ToInt32(cbxHuyen.SelectedValue.ToString()));
                    cbxbenhVien.DataBind();
                }
            }
            catch { }
        }

        protected void cbxbenhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxbenhVien.SelectedValue.ToString() != "Chọn dữ liệu")
                {
                    rowbenhvien = benhVienController.GetDataById(Convert.ToInt32(cbxbenhVien.SelectedValue.ToString()));
                    if (rowbenhvien != null)
                    {
                        cbxTinh.SelectedValue = rowbenhvien.Idtinh.ToString();
                        cbxHuyen.SelectedValue = rowbenhvien.idquanhuyen.ToString();
                    }
                }
            }
            catch { }
        }
    }
}