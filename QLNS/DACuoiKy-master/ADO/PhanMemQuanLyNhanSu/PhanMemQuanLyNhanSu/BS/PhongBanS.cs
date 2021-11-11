using PhanMemQuanLyNhanSu.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace PhanMemQuanLyNhanSu.BS
{
    class PhongBanS
    {
        DBMain db = null;
        QuanLyNhanSu_DatabaseDataContext db2;
        public PhongBanS()
        {
            db = new DBMain();
            db2 = new QuanLyNhanSu_DatabaseDataContext();
        }
        public object LayPhongBan()
        {
            object data = (from q in db2.PhongBans
                           select new
                           {
                               MaPB = q.MaPB,
                               TenPB = q.TenPB,
                               TruongPhong = q.TruongPhong,
                               NgayNhanChuc = q.NgayNhanChuc
                           });
            return data;
        }

        public void ThemPhongBan(string MaPB, string TenPB, string TruongPhong, string NgayNhanChuc)
        {
            PhongBan pb = new PhongBan();
            pb.MaPB = MaPB;
            pb.TenPB = TenPB;
            pb.TruongPhong = TruongPhong;
            pb.NgayNhanChuc = Convert.ToDateTime(NgayNhanChuc);
            db2.PhongBans.InsertOnSubmit(pb);
            db2.SubmitChanges();
        }

        public void CapNhatPhongBan(string MaPB, string TenPB, string TruongPhong, string NgayNhanChuc)
        {
            var phong = (from q in db2.PhongBans where q.MaPB == MaPB select q).SingleOrDefault();
            if (phong != null)
            {
                phong.TenPB = TenPB;
                phong.TruongPhong = TruongPhong;
                phong.NgayNhanChuc = Convert.ToDateTime(NgayNhanChuc);
                db2.SubmitChanges();
            }
            
        }
    }
}
