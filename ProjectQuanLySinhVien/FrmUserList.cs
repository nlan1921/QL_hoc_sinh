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
    public partial class FrmUserList : Form
    {

        UserDao userDao;
        List<User> list;
        User user;

        public FrmDashboard form;
        public delegate void _closeOpenedTab();
        public _closeOpenedTab closeOpenedTab;

        public FrmUserList()
        {
            InitializeComponent();
        }

        private void Frm_Users_Main_Load(object sender, EventArgs e)
        {
            userDao = new UserDao();
            LoadData();
        }
        private void LoadData()
        {
            userDao.ReadUsers(Cls_Main.pathListUser);
            Cls_Main.listUser = userDao.listUser;
            list = userDao.listUser;

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = list;
            dgvUsersList.DataSource = bindingSource;

            lblQuantity.Text = dgvUsersList.RowCount.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmUserUpdate frmUpdate = new FrmUserUpdate();
            frmUpdate.isAdd = true;
            frmUpdate.ShowDialog();
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                FrmUserUpdate frmUpdate = new FrmUserUpdate();
                frmUpdate.isAdd = false;
                frmUpdate.user = user;
                frmUpdate.ShowDialog();
                LoadData();
            } else
            {
                MessageBox.Show("Vui lòng chọn Sinh viên muốn sữa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvUsersList_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.RowCount > 0)
            {
                user = new User()
                {
                    ID = Convert.ToInt32(dgvUsersList.CurrentRow.Cells["colId"].Value.ToString()),
                    FullName = dgvUsersList.CurrentRow.Cells["colFullName"].Value.ToString(),
                    Gender = Convert.ToBoolean(dgvUsersList.CurrentRow.Cells["colGender"].Value.ToString()),
                    UserName = dgvUsersList.CurrentRow.Cells["colUsername"].Value.ToString(),
                    PassWord = dgvUsersList.CurrentRow.Cells["colPassword"].Value.ToString(),
                    Remember = Convert.ToBoolean(dgvUsersList.CurrentRow.Cells["colRemember"].Value.ToString()),
                    Type = Convert.ToInt32(dgvUsersList.CurrentRow.Cells["colType"].Value.ToString())
                };
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xoá người dùng này ch?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    userDao.listUser.Remove(user);
                    userDao.WriteUsers(Cls_Main.pathListUser);
                    LoadData();
                }
            } else
            {
               
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            closeOpenedTab();
        }
    }
}
