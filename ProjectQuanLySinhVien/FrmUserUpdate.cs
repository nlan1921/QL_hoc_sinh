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
    public partial class FrmUserUpdate : Form
    {
        public bool isAdd = false;
        private UserDao userDao;
        public User user;
        public FrmUserUpdate()
        {
            InitializeComponent();
        }

        private void Frm_Update_User_Load(object sender, EventArgs e)
        {
            userDao = new UserDao();
            userDao.listUser = Cls_Main.listUser;
            txtId.Enabled = false;
            LoadComboBox();

            if (isAdd)
            {
                txtId.Text = GetMaxID();
                lblTitle.Text = "Thêm mới người dùng";
                btnUpdate.Text = "Thêm";
            } else
            {
                lblTitle.Text = "Cập nhật thông tin người dùng";
                btnUpdate.Text = "Cập nhật";
                txtId.Text = user.ID.ToString();
                txtFullName.Text = user.FullName;
                rdoMale.Checked = user.Gender;
                rdoFemale.Checked = !user.Gender;
                txtUsername.Text = user.UserName;
                txtPassword.Text = user.PassWord;
                chkRemember.Checked = user.Remember;
                cboType.SelectedValue = user.Type;
            }
        }

        private void LoadComboBox()
        {
            List<UserType> list = new List<UserType>()
            {
                new UserType() {ID = 1, Type = "Admin"},
                new UserType() {ID = 2, Type = "User"}
            };
            cboType.DataSource = list;
            cboType.DisplayMember = "Type";
            cboType.ValueMember = "ID";
            cboType.SelectedIndex = -1;
            cboType.Text = "--- Select type ---";
        }
        private string GetMaxID()
        {
            return string.Format("{0}", userDao.GetMaxId()+1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || cboType.SelectedIndex == -1)
            {
                MessageBox.Show("Vui long dien day du thong tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User user = new User()
                {
                    ID = Convert.ToInt32(txtId.Text),
                    FullName = txtFullName.Text,
                    Gender = rdoMale.Checked,
                    UserName = txtUsername.Text,
                    PassWord = txtPassword.Text,
                    Remember = chkRemember.Checked,
                    Type = Convert.ToInt32(cboType.SelectedValue.ToString())
                };
                if (UpdateUser(user))
                {
                    MessageBox.Show("Update user thanh cong", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                } else
                {
                    MessageBox.Show("Vui long dien day du thong tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool UpdateUser(User user)
        {
            try
            {
                if (isAdd)
                {
                    userDao.listUser.Add(user);
                } else
                {
                    foreach (User item in userDao.listUser)
                    {
                        if (item.ID.Equals(user.ID))
                        {
                            item.ID = user.ID;
                            item.FullName = user.FullName;
                            item.Gender = user.Gender;
                            item.UserName = user.UserName;
                            item.PassWord = user.PassWord;
                            item.Remember = user.Remember;
                            item.Type = user.Type;
                        }
                    }
                }
                userDao.WriteUsers(Cls_Main.pathListUser);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
