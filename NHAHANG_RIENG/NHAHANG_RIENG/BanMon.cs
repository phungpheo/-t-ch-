using NHAHANG_RIENG.DAO;
using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace NHAHANG_RIENG
{
    public partial class BanMon : MaterialSkin.Controls.MaterialForm
    {
        private Account loginAcc;
        private Table tb;

        public Account LoginAcc { get => loginAcc; set => loginAcc = value; }
        public int maban;
        public BanMon(Account acc)
        {
            InitializeComponent();
            this.loginAcc = acc;

            lbStatus.Text = loginAcc.FullName.ToString();
            ShowStatus(loginAcc.Type);
            LoadTable();
            LoadCatery();
            LoadComboboxTable(cbxChuyenban);
            LoadComboboxTable(cbxGopban);

            LoadBanDat();
            BanDatBinding();


        }

        #region Mothor
        // Hàm đưa ds bàn ra cbx chuyển bàn
        void LoadComboboxTable(ComboBox cbx)
        {
            cbx.DataSource = TableDAO.Instance.LoadtableList();
            cbx.DisplayMember = "Name";
        }   

        // Đưa ra tên user ở đầu form
        void ShowStatus(int type)
        {

            
            if (LoginAcc.Type == 0)
            {
                panelQuayLai.Enabled = false;
                lbStatus.Text = loginAcc.FullName.ToString() +"a";
                lbStatus.Visible = true;

                ////Câu chào thôi mà làm j mà thêm mày lại ko show đk tên
                int gio = DateTime.Now.Hour;
                if (gio < 13)
                    label2.Text = "Chào buổi sáng! ";
                else if (gio > 12 && gio < 18)
                    label2.Text = "Chào buổi chiều! ";
                else label2.Text = "Chào buổi tối! ";

            }
            else
            {
                panelQuayLai.Enabled = true;
                panelStatus.Visible = false;
            }

        }

        // mỗi khi nhấn vào Loại món ăn thì sẽ phải load lại
        void LoadCatery()
        {
            List<Catery> listCatery = CateryDAO.Instance.GetListCatery();
            cbxLoaimon.DataSource = listCatery;
            cbxLoaimon.DisplayMember = "NAME";
        }

        void LoadFoodListByCateryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCateryID(id);
            cbxMon.DataSource = listFood;
            cbxMon.DisplayMember = "NAME";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tablelist;
            tablelist = TableDAO.Instance.LoadtableList(); // lấy ds table
            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHieght };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click; // click vào btn thì làm event btn_ckick
                btn.Tag = item;
                btn.ForeColor = Color.White;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.DarkSlateGray;
                        break;
                    default:
                        btn.BackColor = Color.Coral;
                        break;
                }

                flpTable.Controls.Add(btn);
            }

            //lbChonBan.Text = item.Name;
            //string a = item.Name;
        }
        void LoadBanDat()
        {
            dgvDatban.DataSource = BanDatDAO.Instance.GetListBanDat();
            LoadComboboxTable(cbxBanso);
            BanDatBinding();
            EnableBT();

        }
        private void ltvhoadon_SelectedIndexChanged(object sender, EventArgs e)
        {
         //  e3  cbxMon.Text = (ltvhoadon.Selec).Name;
        }
        void LoadListTable()
        {
            dgvDatban.DataSource = TableDAO.Instance.LoadtableList();
        }
        void BanDatBinding()
        {
            txbID.DataBindings.Clear(); txbGhiChu.DataBindings.Clear(); txb_khdat.DataBindings.Clear(); txb_sdtdat.DataBindings.Clear();
            txb_sokhachdat.DataBindings.Clear(); cbxBanso.DataBindings.Clear();
            dtp_ngaydat.DataBindings.Clear(); dtGio.DataBindings.Clear();

            txbID.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "id"));
            txb_khdat.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "tenkh"));
            txb_sdtdat.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "sdt"));
            txb_sokhachdat.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "sokhach"));
            cbxBanso.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "ban"));
            txbGhiChu.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "ghichu"));
            dtGio.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "Gio"));
            dtp_ngaydat.DataBindings.Add(new Binding("text", dgvDatban.DataSource, "Ngay"));

        }
        void ShowBill(int id)
        {
            ltvhoadon.Items.Clear();
            float Thanhtien = 0;
            List<NHAHANG_RIENG.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            foreach (NHAHANG_RIENG.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Gia.ToString());
                lsvItem.SubItems.Add(item.TongTien.ToString());
                Thanhtien += item.TongTien;
                ltvhoadon.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("VI-VN");

            //lbShowTien.Text = Thanhtien.ToString("c",culture);
            // txbshowtien.Text = Thanhtien.ToString("c", culture);
            txbshowtien.Text = Thanhtien.ToString();
        }

        #endregion

        #region Events
        private void btQuaylai_Click(object sender, EventArgs e)
        {

            TrangchuAdmin tc = new TrangchuAdmin(loginAcc);
            this.Hide();
            tc.ShowDialog();
        }

         //Lấy ra tên bàn vừa chọn
        private void btn_Click(object sender, EventArgs e)              ///chọn bàn
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ltvhoadon.Tag = (sender as Button).Tag;
            ShowBill(tableID);

            string TenBan = ((sender as Button).Tag as Table).Name;        
            lbBan.Text = TenBan;
        }

        private void cbxLoaimon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
            {
                return;
            }

            Catery selected = cb.SelectedItem as Catery;
            id = selected.ID;

            LoadFoodListByCateryID(id);
        }

        private void btAddMon_Click(object sender, EventArgs e)
        {
            
            try
            {
                Table table = ltvhoadon.Tag as Table;
                int billID = BillDAO.Instance.GetUncheckBillIdByTableID(table.ID);

                int foodID = (cbxMon.SelectedItem as Food).ID;
                int count = (int)nudSlg.Value;
                // chưa tồn tại Bill
                if (billID == -1)
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                }

                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(billID, foodID, count);

                }
                ShowBill(table.ID);
                LoadTable();
            }
            catch { }
        }
        private void btThanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                maban = (ltvhoadon.Tag as Table).ID;
                
                Table table = ltvhoadon.Tag as Table;
                int idBill = BillDAO.Instance.GetUncheckBillIdByTableID(table.ID);
                int giamgia = (int)nudGiamgia.Value;
                double tongtien_hoadon = Convert.ToDouble(txbshowtien.Text);
                //double tongtien_hoadon = Convert.ToDouble(txbshowtien.Text.Split(',')[0]);
                //double tongtien_hoadon = double.Parse(txbshowtien.Text, NumberStyles.Currency);
                double tien_giamgia = (tongtien_hoadon / 100) * giamgia;
                double tongtien_thucte = tongtien_hoadon - tien_giamgia;
                
                if (idBill != 1)
                {
                    Table tb1 = TableDAO.Instance.GetTableByName(lbBan.Text);
                    if (MessageBox.Show(String.Format("Thanh toán hóa đơn cho {0}?\n Tổng tiền: {1} VNĐ\n Giảm giá: {2}% Tức: {3} VNĐ\n Cần thanh toán: {4} VNĐ", table.Name, tongtien_hoadon, giamgia, tien_giamgia, tongtien_thucte), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        HoaDon hd = new HoaDon();
                        hd.ShowDialog();
                       BillDAO.Instance.CheckOut(idBill, giamgia, (float)tongtien_hoadon, (float)tongtien_thucte);
                        ShowBill(table.ID);
                        LoadTable();
                    }
                }
            }
            catch { }

        }

        private void btXoaMon_Click(object sender, EventArgs e)         //chưa xong
        {

                Table table = ltvhoadon.Tag as Table;

                int billID = BillDAO.Instance.GetUncheckBillIdByTableID(table.ID);

                int foodID = (cbxMon.SelectedItem as Food).ID;
                string foodname = (cbxMon.SelectedItem as Food).Name;

                int countFoodList = ltvhoadon.SelectedItems.Count;
                //int countFoodList = (cbxMon.SelectedItem as BillInfo).Count;
                int countFooddel = (int)nubXoaMon.Value;
                //int 
                int count = (int)nubXoaMon.Value;

                if (billID == -1)
                {

                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(billID, foodID, count);
                }

                ShowBill(table.ID);
                LoadTable();
          

        }

        /// Chuyển bàn
        private void btChuyenban_Click(object sender, EventArgs e)
        {
                // lấy được id bàn 1 là từ bàn đang được chọn.
                int idtable1 = (ltvhoadon.Tag as Table).ID;

                // id bàn 2 là chọn từ combobox
                int idtable2 = (cbxChuyenban.SelectedItem as Table).ID;
            if ((cbxChuyenban.SelectedItem as Table).Status == "Trống")
            {
                // thông báo chueyern bàn
                if (MessageBox.Show(String.Format("THÔNG BÁO CHUYỂN BÀN:\n - Chuyển {0} sang {1}. ?", (ltvhoadon.Tag as Table).Name, (cbxChuyenban.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    TableDAO.Instance.SwitchTable(idtable1, idtable2);

                    LoadTable();
                }
                lbBan.Text = cbxChuyenban.Text;
                //ltvhoadon.Tag = cbxChuyenban.Items;
            }
            else MessageBox.Show((cbxChuyenban.SelectedItem as Table).Name+" đang sử dụng!");
        }
        private void btGopban_Click(object sender, EventArgs e)
        {
            int idtable1 = (ltvhoadon.Tag as Table).ID;
            int idtable2 = (cbxGopban.SelectedItem as Table).ID;
            TableDAO.Instance.GroupTable(idtable1, idtable2);
          //  BillDAO.Instance.DelBill(idtable2);

            LoadTable();
        }

        #endregion
        /// <summary>
        /// ========================ĐĂT BÀN======
        /// </summary>
        private void DisableBT()
        {
            bt_themdat.Enabled = false;
            bt_suadat.Enabled = false;
            bt_xoadat.Enabled = false;

            gb_thongtinban.Enabled = true;
            bt_Luu.Enabled = true;
            bt_Huy.Enabled = true;

            txbGhiChu.Enabled = true;
            txb_khdat.Enabled = true;
            txb_sdtdat.Enabled = true;
            txb_sokhachdat.Enabled = true;
            cbxBanso.Enabled = true;
            dtGio.Enabled = true;
            dtp_ngaydat.Enabled = true;
        }
        private void EnableBT()
        {
            bt_themdat.Enabled = true;
            bt_suadat.Enabled = true;
            bt_xoadat.Enabled = true;

            txbGhiChu.Enabled = false;
            txb_khdat.Enabled = false;
            txb_sdtdat.Enabled = false;
            txb_sokhachdat.Enabled = false;
            cbxBanso.Enabled = false;
            dtGio.Enabled = false;
            dtp_ngaydat.Enabled = false;

            bt_Luu.Enabled = false;
            bt_Huy.Enabled = false;
        }
        private void ClearBox()
        {
            txbID.Clear();
            txb_khdat.Clear(); txb_sdtdat.Clear(); txb_sokhachdat.Value = 0;
            cbxBanso.SelectedIndex = 0; dtGio.Text = ""; dtp_ngaydat.Text = "";
        }
        private string nvDat = "";
        private void bt_themdat_Click(object sender, EventArgs e)
        {
            nvDat = "them";
            DisableBT();
            ClearBox();
        }
        private void bt_suadat_Click(object sender, EventArgs e)
        {
            nvDat = "sua";
            DisableBT();
        }
        private void bt_xoadat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbID.Text != "")
                {
                    if (MessageBox.Show(String.Format("Hủy đặt bàn {0} ?", (cbxBanso.SelectedItem as Table).Name, "Thông báo", MessageBoxButtons.OKCancel)) == System.Windows.Forms.DialogResult.OK)
                        
                    {
                        int id = Convert.ToInt32(txbID.Text);

                        if (BanDatDAO.Instance.DeleteBanDat(id))
                        {
                            MessageBox.Show("Hủy bàn đặt thành công!");

                        }
                    }
                }

                else
                    MessageBox.Show("Chọn bàn bạn muốn hủy!");
            }
            catch { }
            LoadBanDat();
        }
        private void bt_Luu_Click(object sender, EventArgs e)
        {
            if (nvDat == "them")
            {
                if (txb_khdat.Text == "" || txb_sdtdat.Text == "" || txb_sokhachdat.Text == "" || dtp_ngaydat.Text == "" || dtGio.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin đặt bàn!");
                }
                else
                {
                    int id = cbxBanso.SelectedIndex + 1;
                    BanDat ban = BanDatDAO.Instance.GetBanDatById(id);
                    cbxBanso.SelectedItem = ban;

                    string tenkh = txb_khdat.Text;
                    string sdt = txb_sdtdat.Text;
                    string ghichu = txbGhiChu.Text;
                    int sokhach = (int)txb_sokhachdat.Value;
                    string gio = dtGio.Value.ToString("hh:mm");
                    string ngay = dtp_ngaydat.Value.ToString("dd/MM/yyyy");


                    if (BanDatDAO.Instance.InsertBanDat(tenkh, sdt, id, sokhach, gio, ngay, ghichu))
                    {
                        MessageBox.Show("Thêm bàn đặt thành công!");

                    }
                }
            }
            if (nvDat == "sua")
            {
                if (txbID.Text == "") MessageBox.Show("Vui lòng chọn bàn đặt bạn muốn sửa!");
                else
                {
                    if (MessageBox.Show("Bạn thực sự muốn sửa ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idban = cbxBanso.SelectedIndex + 1;
                        BanDat ban = BanDatDAO.Instance.GetBanDatById(idban);
                        cbxBanso.SelectedItem = ban;


                        int id = Convert.ToInt32(txbID.Text);
                        string tenkh = txb_khdat.Text;
                        string sdt = txb_sdtdat.Text;
                        string ghichu = txbGhiChu.Text;
                        int sokhach = (int)txb_sokhachdat.Value;
                        string gio = dtGio.Value.ToString("hh:mm");
                        string ngay = dtp_ngaydat.Value.ToString("dd/MM/yyyy");

                        if (BanDatDAO.Instance.UpdateBanDat(tenkh, sdt, idban, sokhach, gio, ngay, ghichu, id))
                        {
                            MessageBox.Show("Sửa bàn đặt thành công!");

                        }
                        else MessageBox.Show("Sửa thất bại!");
                    }
                }
            }
            LoadBanDat();
            EnableBT();
            ClearBox();
        }

        private void bt_Huy_Click(object sender, EventArgs e)
        {
            EnableBT();
            ClearBox();
        }

        private void txbID_TextChanged(object sender, EventArgs e)  //binding tới combobox
        {
            try
            {

                if (dgvDatban.SelectedCells.Count > 0)
                {
                    int id = (int)dgvDatban.SelectedCells[0].OwningRow.Cells["id"].Value;

                    string ban = dgvDatban.SelectedCells[0].OwningRow.Cells["Ban"].Value.ToString();
                    Table table = TableDAO.Instance.ABC(ban);
                    cbxBanso.SelectedItem = table;

                    int index = -1;
                    int i = 0;
                    foreach (Table item in cbxBanso.Items)
                    {
                        if (item.ID == table.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbxBanso.SelectedIndex = index;
                }
            }
            catch { }
        }

        

        

        private void lbStatus_Click(object sender, EventArgs e)
        {
            AccountInfo acc = new AccountInfo(loginAcc);
            acc.ShowDialog();
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
