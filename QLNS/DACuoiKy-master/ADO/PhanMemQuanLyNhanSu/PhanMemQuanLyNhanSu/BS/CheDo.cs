using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemQuanLyNhanSu.DB;
using System.Data;

namespace PhanMemQuanLyNhanSu.BS
{
    class CheDo
    {
        DBMain db = null;
        public CheDo()
        {

            db = new DBMain();
        }

        public DataSet layCheDo(string MaNV)
        {
            string sqlString = "select * from CheDo where MaNV = '"+MaNV+"'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public DataSet layThongTinNhanVien(string MaNV)
        {
            string sqlString = "select NV.HoTenNV, NV.CMND,NV.GioiTinh,NV.LoaiNV,PB.TenPB from NhanVien AS NV, PhongBan AS PB where NV.Phong = PB.MaPB and NV.MaNV = '" + MaNV+"'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }

        public bool updateCheDoNu(string MaNV, string BHXH, string BHXHDate, string BHYT, string BHYTS, string BHYTE, string ThaiSan, string ThaiSanS)
        {
            string sqlString = "update CheDo set BHXH='" + BHXH + "', BHXHDate='" + BHXHDate + "', BHYT='" + BHYT + "', BHYTS='" + BHYTS + "', BHYTE='" + BHYTE + "', ThaiSan='" + ThaiSan + "', ThaiSanS='" + ThaiSanS + "' where MaNV = '" + MaNV + "'";
            string error = "";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
        public bool updateCheDoNam(string MaNV, string BHXH, string BHXHDate, string BHYT, string BHYTS, string BHYTE)
        {
            string sqlString = "update CheDo set BHXH='" + BHXH + "', BHXHDate='" + BHXHDate + "', BHYT='" + BHYT + "', BHYTS='" + BHYTS + "', BHYTE='" + BHYTE + "' where MaNV = '" + MaNV + "'";
            string error = "";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
        public bool insertCheDo(string MaNV, string BHXH, string BHXHDate, string BHYT, string BHYTS, string BHYTE, string ThaiSan, string ThaiSanS)
        {
            string sqlString = "insert into CheDo values('" + MaNV + "','" + BHXH + "','" + BHXHDate + "','" + BHYT + "','" + BHYTS + "','" + BHYTE + "','" + ThaiSan + "','" + ThaiSanS + "')";
            string error = "";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
    }
}
