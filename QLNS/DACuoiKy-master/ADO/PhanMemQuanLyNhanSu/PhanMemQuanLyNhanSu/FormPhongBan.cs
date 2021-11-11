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
    public partial class FormPhongBan : Form
    {
        clsResize _form_resize;
        public FormPhongBan()
        {
            InitializeComponent();
            _form_resize = new clsResize(this);
            this.Load += _Load;
            this.Resize += _Resize;
        }
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }

        PhongBanS dbPhongBan = new PhongBanS();

        void Loaddata()
        {
            try
            { 
                dgvPhongBan.DataSource = dbPhongBan.LayPhongBan();
                dgvPhongBan.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra,không lấy được dữ liệu table PhongBan!");
            }
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
                try
                {
                    PhongBanS pb = new PhongBanS();
                    pb.ThemPhongBan(this.txtMaPhongBan.Text, this.txtTenPhongBan.Text, this.txtTruongPhong.Text, this.dtbNgayNhanChuc.Text);
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
                PhongBanS pb = new PhongBanS();
                pb.CapNhatPhongBan(this.txtMaPhongBan.Text, this.txtTenPhongBan.Text, this.txtTruongPhong.Text, this.dtbNgayNhanChuc.Text);

                Loaddata();
                MessageBox.Show("Đã sửa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi khi sửa");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvPhongBan.Rows[e.RowIndex];
            txtMaPhongBan.Text = row.Cells[0].Value.ToString();
            txtTenPhongBan.Text = row.Cells[1].Value.ToString();
            txtTruongPhong.Text = row.Cells[2].Value.ToString();
            dtbNgayNhanChuc.Text = row.Cells[3].Value.ToString();
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
