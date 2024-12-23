using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectQuanLySinhVien.models;

namespace ProjectQuanLySinhVien
{
    public partial class FrmUserChangePassword : Form
    {
        private int userType = 0;
        private int userId;
        private bool statusLoad = false;
        private UserDao userDao;
        public FrmDashboard form;
        public delegate void _closeOpenedTab();
        public _closeOpenedTab closeOpenedTab;

        public FrmUserChangePassword()
        {
            InitializeComponent();
        }

        private void Frm_Change_Password_Load(object sender, EventArgs e)
        {
            userDao = new UserDao();
            lblUsername.Text = Cls_Main.staticUser.UserName.ToUpper();
            userType = Cls_Main.staticUser.Type;

            switch (userType)
            {
                case 1:
                    grbAdminResetPassword.Enabled = true;
                    break;
                case 2:
                default:
                    grbAdminResetPassword.Text += " (không có quyền hạn)";
                    grbAdminResetPassword.Enabled = false;
                    break;
            }
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            cboListUser.DataSource = Cls_Main.listUser;
            cboListUser.DisplayMember = "UserName";
            cboListUser.ValueMember = "ID";

            statusLoad = true;
        }

        private void cboListUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboListUser.SelectedIndex > -1 && statusLoad)
            {
                userId = Convert.ToInt32(cboListUser.SelectedValue.ToString());
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            foreach (User item in Cls_Main.listUser)
            {
                if (item.ID == userId)
                {
                    item.PassWord = RandomString(10);
                    userDao.listUser = Cls_Main.listUser;
                    userDao.WriteUsers(Cls_Main.pathListUser);
                    MessageBox.Show("Đặt lại mật khẩu thành công. Mật khẩu mới đã được lưu vào bộ nhớ tạm. \nMật khẩu mới là: " + item.PassWord, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clipboard.SetText(item.PassWord);
                    break;
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtRetypeNewPassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!txtNewPassword.Text.Equals(txtRetypeNewPassword.Text))
            {
                MessageBox.Show("Mật khẩu phải trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!UserChangePassword(txtNewPassword.Text))
            {
                MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool UserChangePassword(string newPassword)
        {
            foreach (User item in Cls_Main.listUser)
            {
                if (item.ID == Cls_Main.staticUser.ID)
                {
                    item.PassWord = newPassword;
                    userDao.listUser = Cls_Main.listUser;
                    userDao.WriteUsers(Cls_Main.pathListUser);
                    return true;
                }
            }
            return false;
        }


        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}