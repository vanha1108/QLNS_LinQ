using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemQuanLyNhanSu.BS;

namespace PhanMemQuanLyNhanSu
{
    public partial class FormCheDo : Form
    {
        CheDoS cheDo = null;
        public FormCheDo()
        {
            cheDo = new CheDoS();
            InitializeComponent();
        }

        private void FormCheDo_Load(object sender, EventArgs e)
        {
            lblMaNV.Visible = false;
            dtpBHYTS.CustomFormat = "DD/MM/YYYY";
            dtpBHYTE.CustomFormat = "dd/MM/yyyy";
            dtpBHXH.CustomFormat = "dd/MM/yyyy";
            dtpThaiSan.CustomFormat = "dd/MM/yyyy";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = txtMaNV.Text.Trim();
            resetComponent();
            DataSet dataSet = cheDo.layThongTinNhanVien(txtMaNV.Text);
            DataTable nhanVienInfor = dataSet.Tables[0];
            if(nhanVienInfor.Rows.Count == 0)
            {
                lblNotify.Text = "Nhân viên này không tồn tại!!!";
                this.disableConponent();
            }
            else
            {
                DataRow data = nhanVienInfor.Rows[0];
                lblMaNV.Text = txtMaNV.Text;
                lblName.Text = data["HoTenNV"].ToString();
                lblGioiTinh.Text = data["GioiTinh"].ToString().ToUpper();
                lblCMND.Text = data["CMND"].ToString();
                lblPhong.Text = data["TenPB"].ToString();
                lblLoaiNV.Text = (data["LoaiNV"].ToString() == "False" ? "Chính thức" : "Thử việc");
                if(lblLoaiNV.Text.Equals("Thử việc")){
                    lblNotify.Text = "Nhân viên này đang thử việc, không thể cập nhật chế độ!!!";
                    disableConponent();
                    btnCapNhap.Enabled = false;
                }
                else
                {
                    DataSet cheDoInfor = cheDo.layCheDo(lblMaNV.Text);
                    openComponent();
                    DataTable dataFound = cheDoInfor.Tables[0];
                    if(dataFound.Rows.Count == 0)
                    {
                        lblNotify.Text = "Nhân viên này chưa đăng kí thông tin, chọn ngày tháng và nhấn 'Đăng ký'";
                        btnCapNhap.Text = "Đăng ký";
                    }
                    else
                    {
                        lblNotify.Text = "";
                        btnCapNhap.Text = "Cập nhật";
                        txtBHXH.Text = dataFound.Rows[0]["BHXH"].ToString();

                        txtBHYT.Text = dataFound.Rows[0]["BHYT"].ToString();

                        dtpBHXH.Value = DateTime.Parse(dataFound.Rows[0]["BHXHDate"].ToString());
                        dtpBHYTS.Value = DateTime.Parse(dataFound.Rows[0]["BHYTS"].ToString());
                        dtpBHYTE.Value = DateTime.Parse(dataFound.Rows[0]["BHYTE"].ToString());
                        if (dataFound.Rows[0]["ThaiSan"].ToString().Equals("True"))
                        {
                            cbThaiSan.Checked = true;
                            dtpThaiSan.Value = DateTime.Parse(dataFound.Rows[0]["ThaiSanS"].ToString());
                        }
                        else
                        {
                            cbThaiSan.Checked = false;
                        }

                    }
                    if (lblGioiTinh.Text.Equals("NỮ"))
                    {
                        dtpThaiSan.Enabled = true;
                        cbThaiSan.Enabled = true;
                    }
                    else
                    {
                        dtpThaiSan.Enabled = false;
                        cbThaiSan.Enabled = false;
                    }
                }
            }
        }

        private void disableConponent()
        {
            this.dtpBHXH.Enabled = false;
            this.dtpBHYTE.Enabled = false;
            this.dtpBHYTS.Enabled = false;
            this.dtpThaiSan.Enabled = false;
            cbThaiSan.Enabled = false;
            btnCapNhap.Enabled = false;
        }

        private void openComponent()
        {
            txtBHYT.ReadOnly = false;
            txtBHYT.Clear();

            txtBHXH.ReadOnly = false;
            txtBHXH.Clear();

            cbThaiSan.Checked = false;

            this.dtpBHXH.Enabled = true;
            this.dtpBHYTE.Enabled = true;
            this.dtpBHYTS.Enabled = true;
            this.dtpThaiSan.Enabled = true;
            cbThaiSan.Enabled = false;
            btnCapNhap.Enabled = true;
        }

        private void resetComponent()
        {
            openComponent();
            btnCapNhap.Text = "Cập nhật";
            lblMaNV.Text = "";
        }

        private void dtpBHYTS_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if(dtpBHYTE.Value.Year < dtpBHYTS.Value.Year)
            {
                MessageBox.Show("Ngày kết thúc bảo hiển y tế phải sau ngày bắt đầu");
                return;
            }
            else if(dtpBHYTE.Value.Year == dtpBHYTS.Value.Year && dtpBHYTE.Value.Month < dtpBHYTS.Value.Month)
            {
                MessageBox.Show("Ngày kết thúc bảo hiển y tế phải sau ngày bắt đầu");
                return;
            }
            else if(dtpBHYTE.Value.Month == dtpBHYTS.Value.Month && dtpBHYTE.Value.Month == dtpBHYTS.Value.Month && dtpBHYTE.Value.Day < dtpBHYTS.Value.Day)
            {
                MessageBox.Show("Ngày kết thúc bảo hiển y tế phải sau ngày bắt đầu");
                return;
            }
            if(txtMaNV.Text != lblMaNV.Text)
            {
                if(MessageBox.Show("Mã nhân viên đã thay đổi, vẫn tiếp tục cập nhật trên Nhân Viên: " + lblMaNV.Text, "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }
            if(cheDo.layCheDo(lblMaNV.Text).Tables[0].Rows.Count > 0)
            {
                if(lblGioiTinh.Text == "NAM")
                {
                    cheDo.updateCheDoNam(lblMaNV.Text, txtBHXH.Text, dtpBHXH.Value.ToString(), txtBHYT.Text, dtpBHYTS.Value.ToString(), dtpBHYTE.Value.ToString());
                }
                else
                {
                    string dateThaiSan = null;  
                    if (cbThaiSan.Checked)
                    {
                        dateThaiSan = dtpThaiSan.Value.ToString();
                    }
                    cheDo.updateCheDoNu(lblMaNV.Text, txtBHXH.Text, dtpBHXH.Value.ToString(), txtBHYT.Text, dtpBHYTS.Value.ToString(), dtpBHYTE.Value.ToString(),cbThaiSan.Checked.ToString(),dateThaiSan);
                }
            }
            else
            {
                string dateThaiSan = null;
                if (cbThaiSan.Checked)
                {
                    dateThaiSan = dtpThaiSan.Value.ToString();
                }
                cheDo.insertCheDo(lblMaNV.Text, txtBHXH.Text, dtpBHXH.Value.ToString(), txtBHYT.Text, dtpBHYTS.Value.ToString(), dtpBHYTE.Value.ToString(), cbThaiSan.Checked.ToString(), dateThaiSan);
            }

            MessageBox.Show("Thao tác thành công!!!");
        }
    }
}
