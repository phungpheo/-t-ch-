using NHAHANG_RIENG.DAO;
using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHAHANG_RIENG
{
    public partial class AccountInfo : MaterialSkin.Controls.MaterialForm
    {
        private Account loginAcc;

        public Account LoginAcc { get => loginAcc; set => loginAcc = value; }

        public AccountInfo(Account acc)
        {
            InitializeComponent();
            this.loginAcc = acc;
            ShowInfo(loginAcc);
        }


        void ShowInfo( Account acc)
        {
            txbUsername.Text = acc.UserName.ToString();
            txbHoTen.Text = acc.FullName.ToString();

            string file = acc.Avt.ToString();
            try
            {
                if (file.Length > 0)
                {
                    Image avt = Image.FromFile(file);
                    ptbAvt.Image = avt;
                }
            }
            catch (Exception)
            {
            }
            
           
            if(acc.Type == 1)
            {
                txbPhanQuyen.Text = "ADMIN";
            }
            else
            {
                txbPhanQuyen.Text = "USER";
            }
        }

        void UpdateAcc()
        {
            string fullname = txbHoTen.Text;
            string username = txbUsername.Text;
            string password = txbPassword.Text;
            string newpass = txbNewpass.Text;
            string passOK = txbPassOk.Text;
            string linkAvt = openFileAVT.FileName;
            if (!newpass.Equals(passOK))
            {
                MessageBox.Show("Mật khẩu xác nhận phải trùng mật khẩu mới!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.UpdateAcc(username, fullname, password, newpass, linkAvt))
                {
                    MessageBox.Show("Cập nhật thành công!","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk);
                    if (updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent( AccountDAO.Instance.GetAccountByUserName(username)));
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai mật khẩu!","Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                }
            }

        }

        #region Event

        private event EventHandler <AccountEvent> updateAccount;

        public event EventHandler <AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }



        private void btQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btLuu_Click(object sender, EventArgs e)
        {
            UpdateAcc();
            AccountInfo_Load(sender,e);
        }

        private void AccountInfo_Load(object sender, EventArgs e)
        {

        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                openFileAVT.ShowDialog();
                string file = openFileAVT.FileName;
                Image avt = Image.FromFile(file);
                ptbAvt.Image = avt;
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }

}
