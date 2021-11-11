using PhanMemQuanLyNhanSu.BS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormCapNhatTaiKhoan : Form
    {
        public FormCapNhatTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormCapNhatTaiKhoan_Load(object sender, EventArgs e)
        {
            this.txtTenTaiKhoan.Text = FormMain.user_current;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMatKhauHienTai.Text == "" || txtMatKhauMoi.Text == "" || txtXacNhanMatKhauMoi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin cần thiết!!!");
                return;
            }
            if (txtMatKhauMoi.Text != txtXacNhanMatKhauMoi.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp!!!");
                return;
            }

            DangNhap dn = new DangNhap();
            bool check = dn.KtraTaiKhoan(this.txtTenTaiKhoan.Text, this.txtMatKhauHienTai.Text);
            if (!check)
            {            
                MessageBox.Show("Mật khẩu hiện tại không đúng!");
                return;
            }
            dn.capNhatTaiKhoan(this.txtTenTaiKhoan.Text, this.txtMatKhauMoi.Text);
            MessageBox.Show("Cập nhật mật khẩu thành công!");
            this.Close();
        }
    }
}
