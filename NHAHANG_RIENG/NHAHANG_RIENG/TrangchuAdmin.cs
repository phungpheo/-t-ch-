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
    public partial class TrangchuAdmin : MaterialSkin.Controls.MaterialForm
    {

        private Account loginAcc;

        public Account LoginAcc { get => loginAcc; set => loginAcc = value; }
       
        public TrangchuAdmin(Account acc)
        {
            InitializeComponent();
            this.LoginAcc = acc;
            lbstatus.Text = loginAcc.FullName.ToString() ;
        }

        #region event
        private void btqlban_Click(object sender, EventArgs e)
        {
            BanMon bm = new BanMon(loginAcc);
            this.Hide();
            bm.Show();
        }

        private void btDoanhthu_Click(object sender, EventArgs e)
        {
            DoanhThu dt = new DoanhThu(loginAcc);
            this.Hide();
            dt.ShowDialog();
        }

        private void btqlmon_Click(object sender, EventArgs e)
        {
            QuanLyHeThong ma = new QuanLyHeThong(loginAcc);
            this.Hide();
            ma.ShowDialog();
        }


        #endregion

        private void lbstatus_Click(object sender, EventArgs e)
        {
            AccountInfo accinfo = new AccountInfo(loginAcc);
            accinfo.UpdateAccount += accinfo_UpdateAccount;
            accinfo.ShowDialog();
        }
        void accinfo_UpdateAccount(object sender, AccountEvent e)
        {

            lbstatus.Text = e.Acc.FullName.ToString() + " !" ;
        }

      

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn đăng xuất?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                this.Hide();
                dn.ShowDialog();
            }
        }
    }
}
