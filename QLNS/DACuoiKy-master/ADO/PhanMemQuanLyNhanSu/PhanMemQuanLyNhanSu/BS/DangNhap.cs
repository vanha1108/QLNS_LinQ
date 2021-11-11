using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PhanMemQuanLyNhanSu.DB;
using System.Windows.Forms;

namespace PhanMemQuanLyNhanSu.BS
{
    class DangNhap
    {
        QuanLyNhanSu_DatabaseDataContext db;
        public DangNhap()
        {
            db = new QuanLyNhanSu_DatabaseDataContext();
        }
        public bool KtraTaiKhoan(string TenDangNhap, string MatKhau)
        {
            var login = db.DangNhaps.Where(s => s.TenTaiKhoan == TenDangNhap && s.MatKhau == MatKhau).FirstOrDefault();
            if (login != null) return true;
            return false;
        }

        public void capNhatTaiKhoan(string TenDangNhap, string MatKhau)
        {
            var update = db.DangNhaps.SingleOrDefault(x => x.TenTaiKhoan == TenDangNhap);

            if (update != null)
            {
                update.MatKhau = MatKhau;
                db.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Lỗi data");
            }
           

        }
    }
}
