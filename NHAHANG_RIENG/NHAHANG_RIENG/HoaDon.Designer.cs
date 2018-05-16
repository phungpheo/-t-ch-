namespace NHAHANG_RIENG
{
    partial class HoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_GETBILL_BYTABLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BILLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUANLYNHAHANGDataSet = new NHAHANG_RIENG.QUANLYNHAHANGDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BILLTableAdapter = new NHAHANG_RIENG.QUANLYNHAHANGDataSetTableAdapters.BILLTableAdapter();
            this.btIn = new System.Windows.Forms.Button();
            this.btCheckOut = new System.Windows.Forms.Button();
            this.lbBan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GETBILL_BYTABLEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BILLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHAHANGDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_GETBILL_BYTABLEBindingSource
            // 
            this.USP_GETBILL_BYTABLEBindingSource.DataMember = "USP_GETBILL_BYTABLE";
            // 
            // BILLBindingSource
            // 
            this.BILLBindingSource.DataMember = "BILL";
            this.BILLBindingSource.DataSource = this.QUANLYNHAHANGDataSet;
            // 
            // QUANLYNHAHANGDataSet
            // 
            this.QUANLYNHAHANGDataSet.DataSetName = "QUANLYNHAHANGDataSet";
            this.QUANLYNHAHANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.USP_GETBILL_BYTABLEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NHAHANG_RIENG.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 447);
            this.reportViewer1.TabIndex = 0;
            // 
            // BILLTableAdapter
            // 
            this.BILLTableAdapter.ClearBeforeFill = true;
            // 
            // btIn
            // 
            this.btIn.Location = new System.Drawing.Point(180, 483);
            this.btIn.Name = "btIn";
            this.btIn.Size = new System.Drawing.Size(144, 44);
            this.btIn.TabIndex = 1;
            this.btIn.Text = "Trở lại";
            this.btIn.UseVisualStyleBackColor = true;
            // 
            // btCheckOut
            // 
            this.btCheckOut.Location = new System.Drawing.Point(377, 483);
            this.btCheckOut.Name = "btCheckOut";
            this.btCheckOut.Size = new System.Drawing.Size(144, 44);
            this.btCheckOut.TabIndex = 2;
            this.btCheckOut.Text = "In hóa đơn";
            this.btCheckOut.UseVisualStyleBackColor = true;
            this.btCheckOut.Click += new System.EventHandler(this.btCheckOut_Click);
            // 
            // lbBan
            // 
            this.lbBan.AutoSize = true;
            this.lbBan.Location = new System.Drawing.Point(639, 466);
            this.lbBan.Name = "lbBan";
            this.lbBan.Size = new System.Drawing.Size(0, 17);
            this.lbBan.TabIndex = 3;
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.lbBan);
            this.Controls.Add(this.btCheckOut);
            this.Controls.Add(this.btIn);
            this.Controls.Add(this.reportViewer1);
            this.Name = "HoaDon";
            this.Text = "HoaDon";
            this.Load += new System.EventHandler(this.HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GETBILL_BYTABLEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BILLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHAHANGDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BILLBindingSource;
        private QUANLYNHAHANGDataSet QUANLYNHAHANGDataSet;
        private QUANLYNHAHANGDataSetTableAdapters.BILLTableAdapter BILLTableAdapter;
        private System.Windows.Forms.BindingSource USP_GETBILL_BYTABLEBindingSource;
        private System.Windows.Forms.Button btIn;
        private System.Windows.Forms.Button btCheckOut;
        private System.Windows.Forms.Label lbBan;
    }
}