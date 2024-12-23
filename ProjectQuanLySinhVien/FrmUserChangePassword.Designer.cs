
namespace ProjectQuanLySinhVien
{
    partial class FrmUserChangePassword
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
            this.grbAdminResetPassword = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboListUser = new System.Windows.Forms.ComboBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.grbChangePassword = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRetypeNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.grbAdminResetPassword.SuspendLayout();
            this.grbChangePassword.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbAdminResetPassword
            // 
            this.grbAdminResetPassword.Controls.Add(this.label1);
            this.grbAdminResetPassword.Controls.Add(this.cboListUser);
            this.grbAdminResetPassword.Controls.Add(this.btnResetPassword);
            this.grbAdminResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAdminResetPassword.Location = new System.Drawing.Point(451, 137);
            this.grbAdminResetPassword.Name = "grbAdminResetPassword";
            this.grbAdminResetPassword.Size = new System.Drawing.Size(446, 188);
            this.grbAdminResetPassword.TabIndex = 0;
            this.grbAdminResetPassword.TabStop = false;
            this.grbAdminResetPassword.Text = "Quản trị viên đặt lại mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn người dùng:";
            // 
            // cboListUser
            // 
            this.cboListUser.FormattingEnabled = true;
            this.cboListUser.Location = new System.Drawing.Point(182, 63);
            this.cboListUser.Name = "cboListUser";
            this.cboListUser.Size = new System.Drawing.Size(234, 28);
            this.cboListUser.TabIndex = 1;
            this.cboListUser.SelectedIndexChanged += new System.EventHandler(this.cboListUser_SelectedIndexChanged);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(272, 113);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(144, 30);
            this.btnResetPassword.TabIndex = 0;
            this.btnResetPassword.Text = "Đặt lại";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // grbChangePassword
            // 
            this.grbChangePassword.Controls.Add(this.lblUsername);
            this.grbChangePassword.Controls.Add(this.label4);
            this.grbChangePassword.Controls.Add(this.txtRetypeNewPassword);
            this.grbChangePassword.Controls.Add(this.txtNewPassword);
            this.grbChangePassword.Controls.Add(this.label3);
            this.grbChangePassword.Controls.Add(this.label2);
            this.grbChangePassword.Controls.Add(this.btnChangePassword);
            this.grbChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChangePassword.Location = new System.Drawing.Point(1011, 137);
            this.grbChangePassword.Name = "grbChangePassword";
            this.grbChangePassword.Size = new System.Drawing.Size(446, 188);
            this.grbChangePassword.TabIndex = 1;
            this.grbChangePassword.TabStop = false;
            this.grbChangePassword.Text = "Thay đổi mật khẩu";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(179, 34);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(38, 20);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tài khoản:";
            // 
            // txtRetypeNewPassword
            // 
            this.txtRetypeNewPassword.Location = new System.Drawing.Point(183, 90);
            this.txtRetypeNewPassword.Name = "txtRetypeNewPassword";
            this.txtRetypeNewPassword.Size = new System.Drawing.Size(234, 26);
            this.txtRetypeNewPassword.TabIndex = 5;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(183, 60);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(234, 26);
            this.txtNewPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhập lại mật khẩu mới:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(273, 122);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(144, 30);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Text = "Thay đổi";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(157)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 81);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1904, 81);
            this.label5.TabIndex = 0;
            this.label5.Text = "THAY ĐỔI MẬT KHẨU";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmUserChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbChangePassword);
            this.Controls.Add(this.grbAdminResetPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUserChangePassword";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.Frm_Change_Password_Load);
            this.grbAdminResetPassword.ResumeLayout(false);
            this.grbAdminResetPassword.PerformLayout();
            this.grbChangePassword.ResumeLayout(false);
            this.grbChangePassword.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbAdminResetPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboListUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.GroupBox grbChangePassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtRetypeNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}