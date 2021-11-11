using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSVLinq.BS_Layer;
namespace QLSVLinq
{
    public partial class frmLogin : Form
    {
        bool Add;
        string err;
        BLLogin dbLogin = new BLLogin(); 
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            string username = txtTenDN.Text;
            string password = txtMatKhau.Text;
            
            if (rdbAd.Checked)
            {

                QLSVDataContext qlSV = new QLSVDataContext();
                var tpQuery = qlSV.Logins.Where(tp => tp.userName == txtTenDN.Text && tp.passWord == txtMatKhau.Text && tp.Quyen == rdbAd.Text).FirstOrDefault();
                if (tpQuery!=null)
                {
                    string user = txtTenDN.Text;
                    string pass = txtMatKhau.Text;
                    MessageBox.Show("Đăng nhập thành công");
                    frmAdmin ad = new frmAdmin(user, pass, "Admin");
                    this.Hide();
                    ad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    txtTenDN.Select();
                }
            }

            if (rdbMb.Checked)
            {
                QLSVDataContext qlSV = new QLSVDataContext();
                var vpQuery = qlSV.Logins.Where(vp => vp.userName == txtTenDN.Text.Trim() && vp.passWord == txtMatKhau.Text && vp.Quyen == rdbMb.Text).FirstOrDefault();
                if (vpQuery!=null)
                {
                    string user = txtTenDN.Text;
                    string pass = txtMatKhau.Text;
                    MessageBox.Show("Đăng nhập thành công");
                    frmAdmin ad = new frmAdmin(user, pass, "Member");
                    this.Hide();
                    ad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    txtTenDN.Select();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTenDN.Focus();
            rdbMb.Checked = true;
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
