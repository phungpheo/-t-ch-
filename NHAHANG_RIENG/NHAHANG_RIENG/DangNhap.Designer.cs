namespace NHAHANG_RIENG
{
    partial class DangNhap
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
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDangnhap = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnThoat = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ckbShowpass = new System.Windows.Forms.CheckBox();
            this.lbstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(190, 120);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(233, 26);
            this.txbUsername.TabIndex = 1;
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(190, 169);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(233, 26);
            this.txbPassword.TabIndex = 2;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(39, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(85, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu";
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.Depth = 0;
            this.btnDangnhap.Location = new System.Drawing.Point(161, 287);
            this.btnDangnhap.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Primary = true;
            this.btnDangnhap.Size = new System.Drawing.Size(118, 31);
            this.btnDangnhap.TabIndex = 5;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Depth = 0;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(321, 287);
            this.btnThoat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Primary = true;
            this.btnThoat.Size = new System.Drawing.Size(83, 31);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // ckbShowpass
            // 
            this.ckbShowpass.AutoSize = true;
            this.ckbShowpass.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckbShowpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbShowpass.Location = new System.Drawing.Point(266, 216);
            this.ckbShowpass.Margin = new System.Windows.Forms.Padding(4);
            this.ckbShowpass.Name = "ckbShowpass";
            this.ckbShowpass.Size = new System.Drawing.Size(157, 21);
            this.ckbShowpass.TabIndex = 9;
            this.ckbShowpass.TabStop = false;
            this.ckbShowpass.Text = "Hiển thị mật khẩu";
            this.ckbShowpass.UseVisualStyleBackColor = false;
            this.ckbShowpass.CheckedChanged += new System.EventHandler(this.ckbShowpass_CheckedChanged);
            // 
            // lbstatus
            // 
            this.lbstatus.AutoSize = true;
            this.lbstatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lbstatus.Location = new System.Drawing.Point(138, 242);
            this.lbstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(0, 18);
            this.lbstatus.TabIndex = 10;
            // 
            // DangNhap
            // 
            this.AcceptButton = this.btnDangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(511, 374);
            this.Controls.Add(this.lbstatus);
            this.Controls.Add(this.ckbShowpass);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangnhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbUsername);
            this.Name = "DangNhap";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialRaisedButton btnDangnhap;
        private MaterialSkin.Controls.MaterialRaisedButton btnThoat;
        private System.Windows.Forms.CheckBox ckbShowpass;
        private System.Windows.Forms.Label lbstatus;
    }
}