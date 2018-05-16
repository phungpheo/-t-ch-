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
    public partial class DangNhap : MaterialSkin.Controls.MaterialForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        bool Dangnhap(string username, string password)
        {
            return AccountDAO.Instance.Dangnhap(username, password);
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;

            //DataProvider data;
            if (Dangnhap(username, password))
            {
                Account loginAcc = AccountDAO.Instance.GetAccountByUserName(username);
                if (loginAcc.Type == 1)
                {
                    TrangchuAdmin tc = new TrangchuAdmin(loginAcc);
                    this.Hide();
                    tc.ShowDialog();
                }
                else
                {
                    BanMon bm = new BanMon(loginAcc);
                    this.Hide();
                    bm.ShowDialog();
                }
            }
            else
            {
                lbstatus.Text = "Đăng nhập sai. Vui lòng đăng nhập lại!";
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void ckbShowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowpass.Checked)
            {
                txbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
            }
        }

      
    }
}
