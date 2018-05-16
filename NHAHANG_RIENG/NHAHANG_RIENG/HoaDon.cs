using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHAHANG_RIENG.DAO;
using NHAHANG_RIENG.DTO;
using Microsoft.Reporting.WinForms;

namespace NHAHANG_RIENG
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
         //   int maban = tb.ID;
          //  SetParameters(maban);
            reportViewer1.RefreshReport();
        }
        public void SetParameters(int maban)
        {
            ReportParameter rp = new ReportParameter("MaBan");
            rp.Values.Add(maban.ToString());
            reportViewer1.LocalReport.SetParameters(rp);
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QUANLYNHAHANGDataSet.BILL' table. You can move, or remove it, as needed.
            // this.usp
            this.BILLTableAdapter.Fill(this.QUANLYNHAHANGDataSet.BILL);

            this.reportViewer1.RefreshReport();
        }

        private void btCheckOut_Click(object sender, EventArgs e)
        {
        }
    }
}
