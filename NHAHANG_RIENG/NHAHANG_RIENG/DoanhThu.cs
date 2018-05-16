using NHAHANG_RIENG.DAO;
using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHAHANG_RIENG
{
    public partial class DoanhThu : MaterialSkin.Controls.MaterialForm
    {
        private Account loginAcc;

        public Account LoginAcc { get => loginAcc; set => loginAcc = value; }

        public DoanhThu(Account acc )
        {
            InitializeComponent();
            this.loginAcc = acc;
            LoadListBillByDate(dtp_in.Value, dtp_out.Value);
    
        }

        #region methors

        void LoadListBillByDate(DateTime checkin, DateTime checkout)
        {
            // LoadDatetimePicker();
            dgvThongke.DataSource = BillDAO.Instance.GetListBillByDate(checkin, checkout);
            btnDau.Text = "1";
            int tonghoadon = BillDAO.Instance.GetNumberBillByDate(checkin, checkout);
            txbLuotkhach.Text = tonghoadon.ToString();

            string thanhtienHD = "";
            string thanhtienTT = "";

            thanhtienHD = BillDAO.Instance.TotalPrices_HD(checkin, checkout);
            thanhtienTT = BillDAO.Instance.TotalPrices_TT(checkin, checkout);

            txbTongthuHoadon.Text = thanhtienHD.ToString();
            txbTongthuThucte.Text = thanhtienTT.ToString();

            // 1 trang có 5 dòng
            int trangcuoi = tonghoadon / 5;
            if (tonghoadon % 5 != 0)
                trangcuoi++;
            btnCuoi.Text = trangcuoi.ToString();
        }

        // Load 
        void LoadDatetimePicker()
        {
            DateTime today = DateTime.Now;
            dtp_in.Value = new DateTime(today.Year, today.Month, 01);
            dtp_out.Value = dtp_in.Value.AddMonths(1).AddDays(-1);
        }

        // hàm show tổng tiền
        void Load_txbTongthu()
        {
            try
            {
                LoadListBillByDate(dtp_in.Value, dtp_out.Value);
                float thanhtien = 0;
                for (int i = 1; i <= (dgvThongke.Rows.Count - 1); i++)
                {
                    thanhtien = thanhtien + float.Parse(dgvThongke.Rows[i].Cells[4].Value.ToString());
                }
               // txbTongthu.Text = thanhtien.ToString();
            }
            catch { }
          
        }
        #endregion


        #region events
        private void btQuaylai_Click(object sender, EventArgs e)
        {
            TrangchuAdmin tc = new TrangchuAdmin(loginAcc);
            this.Hide();
            tc.ShowDialog();
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            
            LoadDatetimePicker();
            LoadListBillByDate(dtp_in.Value, dtp_out.Value);
        }

        private void btThongke_Click(object sender, EventArgs e)
        {
           LoadListBillByDate(dtp_in.Value, dtp_out.Value);
        }

        #endregion

        private void txbTrangHientai_TextChanged(object sender, EventArgs e)
        {
            dgvThongke.DataSource = BillDAO.Instance.GetListBillByDate_inPage(dtp_in.Value, dtp_out.Value, Convert.ToInt32(txbTrangHientai.Text));
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            txbTrangHientai.Text = "1";
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {

            int page = Convert.ToInt32(txbTrangHientai.Text);
            if (page > 1)
                page--;
            txbTrangHientai.Text = page.ToString();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbTrangHientai.Text);
            int tonghoadon = BillDAO.Instance.GetNumberBillByDate(dtp_in.Value, dtp_out.Value);
            // 1 trang có 5 hóa đơn
            if (page * 5 < tonghoadon)
                page++;
            txbTrangHientai.Text = page.ToString();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            int tonghoadon = BillDAO.Instance.GetNumberBillByDate(dtp_in.Value, dtp_out.Value);
            // 1 trang có 5 dòng
            int trangcuoi = tonghoadon / 5;
            if (tonghoadon % 5 != 0)
                trangcuoi++;
            txbTrangHientai.Text = trangcuoi.ToString();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực đăng xuất?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                dn.Show();
                this.Hide();
            }
        }

        private void lbstatus_Click(object sender, EventArgs e)
        {
            AccountInfo acc = new AccountInfo(loginAcc);
            acc.ShowDialog();
        }
    }
}
