﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PhanMemQuanLyNhanSu.DB;

namespace PhanMemQuanLyNhanSu.BS
{
    class DangNhap
    {
        DBMain db = null;
        public DangNhap()
        {
            db = new DBMain();
        }
        public bool KtraTaiKhoan(string TenDangNhap, string MatKhau, ref string err)
        {

            string sqlkt = "select * from DangNhap where TenTaiKhoan=N'" + TenDangNhap + "' and MatKhau=N'" + MatKhau + "'";
            return db.CheckLogin(sqlkt, System.Data.CommandType.Text, ref err);
        }

        public bool capNhatTaiKhoan(string TenDangNhap, string MatKhau)
        {
            string sqlkt = "UPDATE DangNhap SET MatKhau='" + MatKhau + "' WHERE TenTaiKhoan=N'" + TenDangNhap + "'";
            string err = "";
            return db.MyExecuteNonQuery(sqlkt, System.Data.CommandType.Text, ref err);
        }
    }
}
