using PhanMemQuanLyNhanSu.BS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormLuong : Form
    {
        public FormLuong()
        {
            InitializeComponent();
        }

        LuongS dbLuong = new LuongS();

        void Loaddata()
        {
            try
            {
                dgvLuong.DataSource = dbLuong.LayLuong();
                dgvLuong.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table Luong!");
            }
        }
        private void FormLuong_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LuongS luong = new LuongS();
                luong.ThemLuong(this.txtMaLuong.Text, this.txtTenLuong.Text, this.txtLuongCB.Text, this.txtHeSoLuong.Text);
                Loaddata();

                MessageBox.Show("Đã thêm");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi thêm");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                LuongS luong = new LuongS();
                luong.CapNhatLuong(this.txtMaLuong.Text, this.txtTenLuong.Text, this.txtLuongCB.Text, this.txtHeSoLuong.Text);
                Loaddata();

                MessageBox.Show("Đã sửa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi khi sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                LuongS luong = new LuongS();
                luong.XoaLuong(this.txtMaLuong.Text);

                Loaddata();
                MessageBox.Show("Đã xóa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Xảy ra lỗi trong khi xóa!");
            }
        }

       

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvLuong.Rows[e.RowIndex];
            txtMaLuong.Text = row.Cells[0].Value.ToString();
            txtTenLuong.Text = row.Cells[1].Value.ToString();
            txtLuongCB.Text = row.Cells[2].Value.ToString();
            txtHeSoLuong.Text = row.Cells[3].Value.ToString();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form main = new Form();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
    }
}
