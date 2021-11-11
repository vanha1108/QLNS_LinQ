using PhanMemQuanLyNhanSu.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhanSu.BS
{
    class LuongS
    {
        QuanLyNhanSu_DatabaseDataContext db;
        public LuongS()
        {

            db = new QuanLyNhanSu_DatabaseDataContext();
        }
        public object LayLuong()
        {
            object data = (from q in db.Luongs
                           select new
                           {
                               MaLuong = q.MaLuong,
                               TenLuong = q.TenLuong,
                               LuongCB = q.LuongCB,
                               HeSoLuong = q.HeSoLuong
                           });
            return data;
        }

        public void ThemLuong(string MaLuong, string TenLuong, string LuongCB, string HeSoLuong)
        {
            Luong luong = new Luong();
            luong.MaLuong = MaLuong;
            luong.TenLuong = TenLuong;
            luong.LuongCB = Convert.ToDouble(LuongCB);
            luong.HeSoLuong = Convert.ToDouble(HeSoLuong);
            db.Luongs.InsertOnSubmit(luong);
            db.SubmitChanges();
        }

        public void CapNhatLuong(string MaLuong, string TenLuong, string LuongCB, string HeSoLuong)
        {
            var luong = (from data in db.Luongs where data.MaLuong == MaLuong select data).FirstOrDefault();
            if (luong != null)
            {
                luong.TenLuong = TenLuong;
                luong.LuongCB = Convert.ToDouble(LuongCB);
                luong.HeSoLuong = Convert.ToDouble(HeSoLuong);
                db.SubmitChanges();
            }
        }

        public void XoaLuong(string MaLuong)
        {
            var luong = (from data in db.Luongs where data.MaLuong == MaLuong select data).FirstOrDefault();
            db.Luongs.DeleteOnSubmit(luong);
            db.SubmitChanges();
        }
    }
}
