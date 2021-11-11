using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemQuanLyNhanSu.DB;
using System.Data;

namespace PhanMemQuanLyNhanSu.BS
{
    class CheDoS
    {
        QuanLyNhanSu_DatabaseDataContext db2;
        DBMain db = null;
        public CheDoS()
        {

            db2 = new QuanLyNhanSu_DatabaseDataContext();
            db = new DBMain();
        }

        public object layCheDo(string MaNV)
        {
            object data = (from q in db2.CheDos
                        where q.MaNV == MaNV
                        select new
                        {
                            MaNv = q.MaNV,
                            BHXH = q.BHXH,
                            BHXHDate = q.BHXHDate,
                            BHYT = q.BHYT,
                            BHYTE = q.BHYTE,
                            BHYTS = q.BHYTS,
                            ThaiSan = q.ThaiSan,
                            ThaiSanS = q.ThaiSanS
                        }).ToList();
            return data;
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
