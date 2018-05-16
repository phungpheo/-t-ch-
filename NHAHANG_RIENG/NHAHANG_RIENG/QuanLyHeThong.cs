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
    public partial class QuanLyHeThong : MaterialSkin.Controls.MaterialForm
    {
        private Account loginAcc;

        public Account LoginAcc { get => loginAcc; set => loginAcc = value; }

        BindingSource foodlist = new BindingSource();

        public QuanLyHeThong(Account acc)
        {
            InitializeComponent();

            this.loginAcc = acc;
            LoadCateryInCombobox(cbxDanhmuc);
        }
        private void QuanLyHeThong_Load(object sender, EventArgs e)
        {
            LoadListFood();
            LoadCateryInCombobox(cbxDanhmuc);
            EnableMon();
            BindingFood();
            ///
            LoadListCatery();
            EnableDM();             //bt của cả món ăn và danh mục
            CateryBinding();
            ////
            LoadAccount();
            EnableTK();
            AccountBingding();
            //
            LoadBan();
            EnableBan();
            BanBingding();
        }
        #region methors
        public void LoadListFood()
        {
            dgvMonAn.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadListCatery()
        {
            dgvDanhMuc.DataSource = CateryDAO.Instance.GetListCatery();
        }
        public void BindingFood()
        {
            txbID.DataBindings.Clear();
            txbTenMon.DataBindings.Clear();
            nudGia.DataBindings.Clear();
            // - kiểu - sourse - tên cột - true: tự động ép kiểu - never: sửa bên txb nhưng không thay đổi bên dgv
            txbID.DataBindings.Add(new Binding("text", dgvMonAn.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTenMon.DataBindings.Add(new Binding("text", dgvMonAn.DataSource, "Name", true, DataSourceUpdateMode.Never));
            nudGia.DataBindings.Add(new Binding("Value", dgvMonAn.DataSource, "GIA", true, DataSourceUpdateMode.Never));
        }
        public void CateryBinding()
        {
            txbIdDanhmuc.DataBindings.Clear();
            txbTenDm.DataBindings.Clear();
            txbIdDanhmuc.DataBindings.Add(new Binding("text", dgvDanhMuc.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTenDm.DataBindings.Add(new Binding("text", dgvDanhMuc.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        public void LoadCateryInCombobox(ComboBox cbx)
        {
            cbx.DataSource = CateryDAO.Instance.GetListCatery();
            cbx.DisplayMember = "NAME";
        }


        List<Food> SearchFood(string name)
        {
            List<Food> listfood = FoodDAO.Instance.SearchFoodByName(name);

            return listfood;
        }
        #endregion



        #region event

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            dgvMonAn.DataSource = SearchFood(txbTimkiem.Text);
        }

        private void btQuaylai_Click(object sender, EventArgs e)
        {
            TrangchuAdmin tc = new TrangchuAdmin(loginAcc);
            this.Hide();
            tc.ShowDialog();
        }


        // binding cbx Danh mục món ăn
        private void txb(object sender, EventArgs e)
        {
            try
            {

                if (dgvMonAn.SelectedCells.Count > 0)
                {
                    string loaimon = dgvMonAn.SelectedCells[0].OwningRow.Cells["LoaiMon"].Value.ToString();
                    Catery catery = CateryDAO.Instance.ABC(loaimon);

                    cbxDanhmuc.SelectedItem = catery;

                    int index = -1;
                    int i = 0;
                    foreach (Catery item in cbxDanhmuc.Items)
                    {

                        if (item.ID == catery.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbxDanhmuc.SelectedIndex = index;
                }
            }
            catch { }
        }

        /* private void btThemMon_Click(object sender, EventArgs e)
         {
             string name = txbTenMon.Text;
             int idcatery = (cbxDanhmuc.SelectedItem as Catery).ID;
             float gia = (float)nudGia.Value;

             if (FoodDAO.Instance.InsertFood(name, idcatery, gia))
             {
                 MessageBox.Show("Thêm món thành công", "Thông báo");
                 LoadListFood();
                 if (insertFood != null)
                     insertFood(this, new EventArgs());
             }
             else
             {
                 MessageBox.Show("Thêm món ăn không thành công");
             }
         }

         private void btSuamon_Click(object sender, EventArgs e)
         {

             string name = txbTenMon.Text;
             int idcatery = (cbxDanhmuc.SelectedItem as Catery).ID;
             float gia = (float)nudGia.Value;
             int id = Convert.ToInt32(txbID.Text);

             if (FoodDAO.Instance.UpdateFood(id, name, idcatery, gia))
             {
                 MessageBox.Show("Sửa món thành công", "Thông báo");
                 LoadListFood();
                 if (updateFood != null)
                     updateFood(this, new EventArgs());
             }
             else
             {
                 MessageBox.Show("Sửa món ăn không thành công");
             }
         }

         private void btXoamon_Click(object sender, EventArgs e)
         {
             string name = txbTenMon.Text;
             int id = Convert.ToInt32(txbID.Text);


             if (MessageBox.Show(String.Format("Chắc chắn xóa món {0}?",name, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == System.Windows.Forms.DialogResult.Yes)
             {
                 if (FoodDAO.Instance.DeleteFood(id))
                 {
                     MessageBox.Show("Xóa món thành công", "Thông báo");
                     LoadListFood();
                     if (deleteFood != null)
                         deleteFood(this, new EventArgs());
                 }
                 else
                 {
                     MessageBox.Show("Xóa món ăn không thành công");
                 }
             }

         }



         private event EventHandler insertFood;
         public event EventHandler InsertFood
         {
             add { insertFood += value; }
             remove { insertFood -= value; }
         }

         private event EventHandler deleteFood;
         public event EventHandler DeleteFood
         {
             add { deleteFood += value; }
             remove { deleteFood -= value; }
         }

         private event EventHandler updateFood;
         public event EventHandler UpdateFood
         {
             add { updateFood += value; }
             remove { updateFood -= value; }
         }
         */
        string nv = "";
        private void DisableMon()
        {
            
            btThemMon.Enabled = false;
            btSuamon.Enabled = false;
            btXoamon.Enabled = false;
            btTimkiem.Enabled = false;

            bt_LuuMon.Enabled = true;
            bt_HuyLuuMon.Enabled = true;

            txbTenMon.Enabled = true;
            nudGia.Enabled = true;
            cbxDanhmuc.Enabled = true;
        }
        private void EnableMon()
        {
            btThemMon.Enabled = true;
            btSuamon.Enabled = true;
            btXoamon.Enabled = true;
            btTimkiem.Enabled = true;

            bt_LuuMon.Enabled = false;
            bt_HuyLuuMon.Enabled = false;

            txbTenMon.Enabled = false;
            nudGia.Enabled = false;
            cbxDanhmuc.Enabled = false;

        }
        private void DisableDM()
        {
            btThemDM.Enabled = false;
            btSuaDM.Enabled = false;
            btXoaDM.Enabled = false;
            bt_LuuCategory.Enabled = true;
            bt_HuyLuuCatrgory.Enabled = true;
            txbTenDm.Enabled = true;
        }
        private void EnableDM()
        {
            btThemDM.Enabled = true;
            btSuaDM.Enabled = true;
            btXoaDM.Enabled = true;
            bt_LuuCategory.Enabled = false;
            bt_HuyLuuCatrgory.Enabled = false;
            txbTenDm.Enabled = false;
        }
        private void ClearBox()
        {
            txbID.Clear(); txbTenDm.Clear(); txbIdDanhmuc.Clear(); txbTenMon.Clear(); txbTimkiem.Clear(); nudGia.Value = 0; cbxDanhmuc.Text = "";
        }
        private void btThemMon_Click(object sender, EventArgs e)
        {
            nv = "them";
            DisableMon();
            LoadListFood();
            ClearBox();
            bt_LuuMon.Focus();
        }
        private void btSuamon_Click(object sender, EventArgs e)
        {
            nv = "sua";
            DisableMon();
            bt_LuuMon.Focus();
        }
        private void btXoamon_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn thực sự muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idfood = Convert.ToInt32(txbID.Text);

                    if (FoodDAO.Instance.DeleteFood(idfood))
                    {
                        MessageBox.Show("Xóa món thành công!");
                        LoadListFood();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Chọn món bạn muốn xóa!");
            }

            QuanLyHeThong_Load(sender, e);
            txbID.Text = "";
            txbTenMon.Text = "";
            nudGia.Value = 0;
        }

        private void bt_LuuMon_Click(object sender, EventArgs e)
        {
            if (nv == "them")
            {
                if (txbTenMon.Text == "" || cbxDanhmuc.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin!");
                }
                else
                {
                    string kt = "";
                    for (int i = 0;i < dgvMonAn.Rows.Count;i++)
                    {
                        if (txbTenMon.Text == dgvMonAn.Rows[i].Cells["Name"].Value.ToString())
                        {
                            kt = "tt";
                            break;
                        }
                    }
                    if(kt=="tt")
                    {
                        MessageBox.Show("Món ăn đã tồn tại!");
                    }
                    else
                    {
                        int id = (cbxDanhmuc.SelectedItem as Catery).ID;
                        Catery catery = CateryDAO.Instance.GetCateryById(id);       //GET CATERY BY NAME
                        cbxDanhmuc.SelectedItem = catery;

                        string name = txbTenMon.Text;
                        int categoryid = catery.ID;
                        float price = (float)nudGia.Value;

                        if (FoodDAO.Instance.InsertFood(name, categoryid, price))
                        {
                            MessageBox.Show("Thêm món thành công!");
                            kt = "";
                        }
                    }
                }

                QuanLyHeThong_Load(sender, e);
            }
            if (nv == "sua")
            {
                if (txbID.Text == "") MessageBox.Show("Vui lòng chọn món ăn bạn muốn sửa!");
                else
                {
                    if (MessageBox.Show("Bạn thực sự muốn sửa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        int id = (cbxDanhmuc.SelectedItem as Catery).ID;
                        int idfood = Convert.ToInt32(txbID.Text);
                        Catery catery = CateryDAO.Instance.GetCateryById(id);
                        cbxDanhmuc.SelectedItem = catery;

                        string name = txbTenMon.Text; ;
                        int categoryid = catery.ID;
                        float price = (float)nudGia.Value;

                        if (FoodDAO.Instance.UpdateFood(idfood, name, categoryid, price))
                        {
                            MessageBox.Show("Sửa món thành công!");
                            LoadListFood();
                        }
                        else MessageBox.Show("Sửa món thất bại!");
                    }
                }
            }
            QuanLyHeThong_Load(sender, e);
            nv = "";
        }

        private void bt_HuyLuuMon_Click(object sender, EventArgs e)
        {

            EnableMon();
            ClearBox();
            QuanLyHeThong_Load(sender, e);


        }


        #endregion
        string nvDM = "";
        private void btThemDM_Click(object sender, EventArgs e)
        {
            nvDM = "themDM";
            DisableDM();
            LoadListCatery();
            ClearBox();
            bt_LuuCategory.Focus();
        }
        private void btSuaDM_Click(object sender, EventArgs e)
        {
            nvDM = "suaDM";
            DisableDM();
        }


        private void btXoaDM_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbIdDanhmuc.Text);
                if (MessageBox.Show("Bạn thực sự muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CateryDAO.Instance.DeleteCatery(id))
                    {
                        MessageBox.Show("Xóa danh mục thành công!");
                        LoadListCatery();
                    }
                    else MessageBox.Show("Xóa danh mục thất bại!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Chọn danh mục cần xóa!");
            }

            QuanLyHeThong_Load(sender, e);
        }



        private void bt_LuuCategory_Click(object sender, EventArgs e)
        {
            if (nvDM == "themDM")
            {
                if (txbTenDm.Text == "") MessageBox.Show("Hãy nhập tên danh mục!");
                else
                {
                    string kt = "";
                    for(int i=0; i<dgvDanhMuc.Rows.Count;i++)
                    {
                        if (txbTenDm.Text == dgvDanhMuc.Rows[i].Cells["tenDM"].Value.ToString())
                        {
                            kt = "tt";
                            break;
                        }

                    }
                    if(kt=="tt")
                    {
                        MessageBox.Show("Tên danh mục món ăn đã tồn tại");
                    }
                    else
                    {
                        string name = txbTenDm.Text;

                        if (CateryDAO.Instance.InsertCatery(name))
                        {

                            MessageBox.Show("Thêm danh mục thành công!");
                            kt = "";
                        }
                    }
                   
                }

            }
            if (nvDM == "suaDM")
            {
                if (txbIdDanhmuc.Text == "")
                {
                    MessageBox.Show("Hãy chọn danh mục bạn muốn sửa!");
                }
                else
                {
                    if (MessageBox.Show("Bạn thực sự muốn sửa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(txbIdDanhmuc.Text);
                        string name = txbTenDm.Text;

                        if (CateryDAO.Instance.EditCatery(id, name))
                        {
                            MessageBox.Show("Sửa danh mục thành công!");
                            LoadListCatery();
                        }
                        else MessageBox.Show("Sửa danh mục thất bại!");
                    }
                }

            }
            
            QuanLyHeThong_Load(sender, e);
            nvDM = "";
        }
        private void bt_HuyLuuCatrgory_Click(object sender, EventArgs e)
        {

            ClearBox();
            EnableDM();
            QuanLyHeThong_Load(sender, e);


        }
   ///========================================TÀI KHOẢN======================
        

        void LoadAccount()
        {
            dgvACC.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AccountBingding()
        {
            txbFullname.DataBindings.Clear(); txbUsername.DataBindings.Clear(); nudPhanquyen.DataBindings.Clear();
            txbFullname.DataBindings.Add(new Binding("Text", dgvACC.DataSource, "FULLNAME", true, DataSourceUpdateMode.Never));
            txbUsername.DataBindings.Add(new Binding("Text", dgvACC.DataSource, "USERNAME", true, DataSourceUpdateMode.Never));
            nudPhanquyen.DataBindings.Add(new Binding("value", dgvACC.DataSource, "TYPE", true, DataSourceUpdateMode.Never));
        }
        void DisableTK()
        {
            btThemTk.Enabled = false;
            btSuaTk.Enabled = false;
            btXoaTk.Enabled = false;
            btReset.Enabled = false;

            btLuuTK.Enabled = true;
            btHuyLuuTK.Enabled = true;

            txbFullname.Enabled = true;
            nudPhanquyen.Enabled = true;
            txbUsername.Enabled = true;

        }
        void EnableTK()
        {
            btThemTk.Enabled = true;
            btSuaTk.Enabled = true;
            btXoaTk.Enabled = true;
            btReset.Enabled = true;

            btLuuTK.Enabled = false;
            btHuyLuuTK.Enabled = false;
            txbFullname.Enabled = false;
            nudPhanquyen.Enabled = false;
            txbUsername.Enabled = false;
        }
        void ClearBoxTK()
        {
            txbFullname.Text = ""; txbUsername.Text = ""; nudPhanquyen.Value = 0;
        }
        void AddAccount(string fullname, string username, int type)
        {
            int kt = 0;
            for (int i=0;i<dgvACC.Rows.Count;i++)
            {
                if (txbUsername.Text == dgvACC.Rows[i].Cells["username"].Value.ToString())
                {
                    kt = 1;
                    break;
                }
            }
            if(kt==1) MessageBox.Show("Tên đăng nhập đã tồn tại!");
            else
            {
                if (AccountDAO.Instance.InsertAccount(username, fullname, type))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                }
                else
                    MessageBox.Show("Thêm tài khoản không thành công");
            }
            

        }
        void EditAccount(string fullname, string username, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(username, fullname, type))
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
                MessageBox.Show("Bạn không thể sửa tên đăng nhập");
        }
        void DeleteAccount(string username)
        {
            if (MessageBox.Show(String.Format("Chắc chắn xóa tài khoản : {0}?", username.ToUpper(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == System.Windows.Forms.DialogResult.OK)
            {
                if (!username.Equals(loginAcc.UserName))
                {
                    if (AccountDAO.Instance.DeleteAccount(username))
                    {
                        MessageBox.Show("Xóa tài khoản thành công");
                    }
                    else
                        MessageBox.Show("Xóa tài khoản không thành công");
                }
                else
                    MessageBox.Show("Không thể xóa chính bạn :D ", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                //MessageBox.Show(String.Format("Tài khoản : {0} chính là tài khoản đang đăng nhập! Không thể xóa!", username, "Cảnh báo!",MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }
        void ResetPass(string username)
        {

            if (MessageBox.Show(String.Format("Đặt lại mật khẩu cho xóa tài khoản : {0}?", username.ToUpper(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == System.Windows.Forms.DialogResult.OK)
            {
                if (AccountDAO.Instance.ResetPassword(username))
                {
                    MessageBox.Show("Reset mật khẩu thành công");
                }
                else
                    MessageBox.Show("Reset mật khẩu không thành công");
            }

        }
        string nvTK = "";
        private void btThemTk_Click(object sender, EventArgs e)
        {
            DisableTK();
            nvTK = "them";
            ClearBoxTK();
            LoadAccount();
        }
        private void btSuaTk_Click(object sender, EventArgs e)
        {
            DisableTK();
            nvTK = "sua";
        }
        private void btXoaTk_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;

            DeleteAccount(username);
            QuanLyHeThong_Load(sender, e);
        }
        private void btLuuTK_Click(object sender, EventArgs e)
        {
            if (nvTK == "them")
            {
                string username = txbUsername.Text;
                string fullname = txbFullname.Text;
                int type = (int)nudPhanquyen.Value;
                AddAccount(fullname, username, type);
            }
            if (nvTK == "sua")
            {
                string username = txbUsername.Text;
                string fullname = txbFullname.Text;
                int type = (int)nudPhanquyen.Value;
                EditAccount(fullname, username, type);
            }
            QuanLyHeThong_Load(sender, e);
        }

        private void btHuyLuuTK_Click(object sender, EventArgs e)
        {
            EnableTK();
            ClearBoxTK();
            QuanLyHeThong_Load(sender, e);
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            ResetPass(username);
        }

        
        /// 

        /////////==================bàn================
        void LoadBan()
        {
            dgvBan.DataSource = TableDAO.Instance.LoadtableList();
        }
        void BanBingding()
        {
            txbIDBan.DataBindings.Clear(); txbTenBan.DataBindings.Clear(); txbTrangThai.DataBindings.Clear();
            txbIDBan.DataBindings.Add(new Binding("text", dgvBan.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTenBan.DataBindings.Add(new Binding("text", dgvBan.DataSource, "NAME", true, DataSourceUpdateMode.Never));
            txbTrangThai.DataBindings.Add(new Binding("text", dgvBan.DataSource, "STATUS", true, DataSourceUpdateMode.Never));
        }
        void DisableBan()
        {
            btThemBan.Enabled = false;
            btSuaBan.Enabled = false;
            btXoaBan.Enabled = false;
            txbTenBan.Enabled = true;

            btLuuBan.Enabled = true;
            btHuyLuuBan.Enabled = true;
        }
        void EnableBan()
        {
            btThemBan.Enabled = true;
            btSuaBan.Enabled = true;
            btXoaBan.Enabled = true;
            txbTenBan.Enabled = false;

            btLuuBan.Enabled = false;
            btHuyLuuBan.Enabled = false;
        }
        void ClearBoxBan()
        {
            txbIDBan.Text = ""; txbTenBan.Text = ""; txbTrangThai.Text = "";
        }
        string nvBan = "";
        private void btThemBan_Click(object sender, EventArgs e)
        {
            DisableBan();
            ClearBoxBan();
            LoadBan();
            nvBan = "them";
        }

        private void btSuaBan_Click(object sender, EventArgs e)
        {
            DisableBan();
            nvBan = "sua";
        }

        private void btXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbIDBan.Text);
                if (txbTrangThai.Text != "Có Khách")
                {
                    if (MessageBox.Show("Bạn thực sự muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (TableDAO.Instance.DeleteTable(id))
                        {
                            MessageBox.Show("Xóa bàn thành công!");
                            LoadListCatery();
                        }
                        else MessageBox.Show("Xóa bàn thất bại!");

                    }
                }
                else MessageBox.Show("Không thể xóa bàn đang sử dụng");
            }
            catch (Exception)
            {

                MessageBox.Show("Chọn  bàn cần xóa!");
            }

            QuanLyHeThong_Load(sender, e);
        }

        private void btLuuBan_Click(object sender, EventArgs e)
        {
            if (nvBan == "them")
            {
                if (txbTenBan.Text == "") MessageBox.Show("Hãy nhập tên bàn!");
                else
                {
                    int kt = 0;
                    for(int i=0;i<dgvBan.Rows.Count;i++)
                    {
                        if (txbTenBan.Text == dgvBan.Rows[i].Cells["tenban"].Value.ToString())
                        {
                            kt = 1;
                            break;
                        }

                    }
                    if(kt==1) MessageBox.Show("Tên bàn đã tồn tại!");
                    else
                        {
                        string name = txbTenBan.Text;
                        string status = "Trống";

                        if (TableDAO.Instance.InsertTable(name, status))
                        {

                            MessageBox.Show("Thêm bàn thành công!");

                        }
                    }

                }
            }
            if (nvBan == "sua")
            {
                if (txbIDBan.Text == "")
                {
                    MessageBox.Show("Hãy chọn bàn bạn muốn sửa!");
                }
                else
                {
                    if (MessageBox.Show("Bạn thực sự muốn sửa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(txbIDBan.Text);
                        string name = txbTenBan.Text;

                        if (TableDAO.Instance.UpdateTable(id, name))
                        {
                            MessageBox.Show("Sửa  thành công!");
                            LoadListCatery();
                        }
                        else MessageBox.Show("Sửa thất bại!");
                    }
                }
            }
            QuanLyHeThong_Load(sender, e);
        }

        private void btHuyLuuBan_Click(object sender, EventArgs e)
        {
            EnableBan();
            ClearBoxBan();
            QuanLyHeThong_Load(sender, e);
        }
        
        private void lbstatus_Click(object sender, EventArgs e)
        {
            AccountInfo acc = new AccountInfo(loginAcc);
            acc.ShowDialog();
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
    }
}
