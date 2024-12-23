using ProjectQuanLySinhVien.models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectQuanLySinhVien
{
    public partial class FrmLogin : Form
    {

        private List<User> list;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            list = Cls_Main.listUser;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui long dien day du thong tin");
                return;
            }

            if (LoginApplication(txtUsername.Text, txtPassword.Text))
            {
                Cls_Main.staticUser = list.Find(x => x.UserName == txtUsername.Text);
                MessageBox.Show("Đăng nhập thành công!\nChào mừng bạn: " + Cls_Main.staticUser.UserName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai thông tin đăng nhập, vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Console.WriteLine("triggered");
            Application.Exit();
        }
        
        private bool LoginApplication(string username, string password)
        {
            User item = list.Find(x => x.UserName == username);
            if (item != null && item.PassWord.Equals(password))
            {
                return true;
            }

            return false;
        }
    }
}
