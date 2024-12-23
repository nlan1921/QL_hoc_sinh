using DevComponents.DotNetBar;
using ProjectQuanLySinhVien.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQuanLySinhVien
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
            CallLogin();
        }

        #region Thiet ke layOut

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            lblTime.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            timer1.Enabled = true;
            pnlGroupManager.Height = 45;
            pnlAccount.Height = 45;
            pnlReportPanel.Height = 45;
            pnlStudentManagerPanel.Height = 45;
        }
        private bool isLogined = false;

        private void CallLogin()
        {
            isLogined = false;
            this.Hide();
            if (new FrmLogin().ShowDialog() == DialogResult.OK)
            {
                isLogined = true;
                this.Show();
                tcDashboard.Tabs.Clear();
                tcDashboard.RecalcLayout();
            }
            else
            {
                Console.WriteLine("triggerededed");
                Application.Exit();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
        }
        private void btnAccountPannel_Click(object sender, EventArgs e)
        {
            if (pnlAccount.Height > 45)
            {
                pnlAccount.Height = 45;
            }
            else
            {
                pnlGroupManager.Height = 45;
                pnlAccount.Height = 280;
                pnlReportPanel.Height = 45;
                pnlStudentManagerPanel.Height = 45;
            }
        }

        private void btnGroupManagerPanel_Click(object sender, EventArgs e)
        {

            if (pnlGroupManager.Height > 45)
            {
                pnlGroupManager.Height = 45;
            }
            else
            {
                pnlGroupManager.Height = 141;
                pnlAccount.Height = 45;
                pnlReportPanel.Height = 45;
                pnlStudentManagerPanel.Height = 45;
            }
        }

        private void btnStudentManagerPanel_Click(object sender, EventArgs e)
        {
            if (pnlStudentManagerPanel.Height > 45)
            {
                pnlStudentManagerPanel.Height = 45;
            }
            else
            {
                pnlGroupManager.Height = 45;
                pnlAccount.Height = 45;
                pnlReportPanel.Height = 45;
                pnlStudentManagerPanel.Height = 188;
            }
        }

        private void btnReportPanel_Click(object sender, EventArgs e)
        {
            if (pnlReportPanel.Height > 45)
            {
                pnlReportPanel.Height = 45;
            }
            else
            {
                pnlGroupManager.Height = 45;
                pnlAccount.Height = 45;
                pnlReportPanel.Height = 141;
                pnlStudentManagerPanel.Height = 45;
            }
        }

        private void ResetPanelHeight()
        {
            pnlGroupManager.Height = 45;
            pnlAccount.Height = 45;
            pnlReportPanel.Height = 45;
            pnlStudentManagerPanel.Height = 45;
        }
        #endregion


        #region TabControl actions
        bool tabOpenStatus = false;
        string tabName;

        public FrmDashboard form;
        public delegate void _closeOpenedTab();

        private void CloseOpenedTab()
        {
            foreach (TabItem tab in tcDashboard.Tabs)
            {
                if (tab.IsSelected)
                {
                    tcDashboard.Tabs.Remove(tab);
                    return;
                }
            }
        }

        /// <summary>
        /// Phương thức tìm kiếm xem 1 form đã mở hay chưa
        /// </summary>
        /// <param name="name">Tên form</param>
        /// <returns>true: đã mở; false: chưa mở</returns>
        private bool CheckOpenedTab(string name)
        {
            for (int i = 0; i < tcDashboard.Tabs.Count; i++)
            {
                if (tcDashboard.Tabs[i].Text == name)
                {
                    tcDashboard.SelectedTabIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void tcDashboard_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            TabItem t = tcDashboard.SelectedTab;
            tcDashboard.Tabs.Remove(t);
        }

        private void OpenTab(Form form, string title, bool tabOpenStatus)
        {
            this.tabOpenStatus = tabOpenStatus;
            this.tabName = title;

            if (!CheckOpenedTab(title))
            {
                TabItem tab = tcDashboard.CreateTab(tabName);
                tab.Name = form.Name;
                switch (form.Name)
                {
                    case "FrmSave":
                        form = new FrmSave() { closeOpenedTab = new FrmSave._closeOpenedTab(CloseOpenedTab), form = this, TopLevel = false, Dock = DockStyle.Fill, Text = title };
                        break;
                    case "FrmUserList":
                        form = new FrmUserList() { closeOpenedTab = new FrmUserList._closeOpenedTab(CloseOpenedTab), form = this, TopLevel = false, Dock = DockStyle.Fill, Text = title };
                        break;
                    case "FrmUserChangePassword":
                        form = new FrmUserChangePassword() { closeOpenedTab = new FrmUserChangePassword._closeOpenedTab(CloseOpenedTab), form = this, TopLevel = false, Dock = DockStyle.Fill, Text = title };
                        break;
                    case "FrmLop":
                        form = new FrmLop() { closeOpenedTab = new FrmLop._closeOpenedTab(CloseOpenedTab), form = this, TopLevel = false, Dock = DockStyle.Fill, Text = title };
                        break;
                    case "FrmDanhsachSv":
                        form = new FrmDanhsachSv() { closeOpenedTab = new FrmDanhsachSv._closeOpenedTab(CloseOpenedTab), form = this, TopLevel = false, Dock = DockStyle.Fill, Text = title };
                        break;
                    case "FrmdsSV_Lop":
                        form = new FrmdsSV_Lop() { TopLevel = false, Dock = DockStyle.Fill, Text = title };
                        break;
                    case "FrmPhanQuyen":
                        form = new FrmPhanQuyen() { form = this, TopLevel = false, Dock = DockStyle.Fill, Text = title };
                        break;
                    default:
                        break;
                }
                Console.WriteLine(form.Name);
                tab.AttachedControl.Controls.Add(form);
                form.Show();
                tcDashboard.SelectedTabIndex = tcDashboard.Tabs.Count - 1;
            }
        }
        #endregion


        private void FrmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLogined)
                if (MessageBox.Show("Bạn có muốn tắt chương trình hay không\n Chọn OK để tắt; Chọn Cancel để hủy", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            else
                e.Cancel = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ResetPanelHeight();
                Cls_Main.staticUser = null;
                CallLogin();
            }
        }

        private void btnBackupRestore_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            if (Cls_Main.staticUser.Type != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào tính năng này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenTab(new FrmSave(), "Sao lưu - Phục hồi", true);
        }
        private void btnUsersList_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            if (Cls_Main.staticUser.Type != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào tính năng này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenTab(new FrmUserList(), "Danh sách người dùng", true);
        }

        private void btnUserChangePassword_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            OpenTab(new FrmUserChangePassword(), "Thay đổi mật khẩu", true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            OpenTab(new FrmLop(), "Danh sách lớp", true);
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {

            ResetPanelHeight();
            OpenTab(new FrmDanhsachSv(), "Danh sách sinh viên", true);
        }

        private void tcDashboard_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            OpenTab(new FrmdsSV_Lop(), "DS Lớp", true);
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            OpenTab(new FrmPhanQuyen(), "Phân quyền tài khoản", true);
        }

        private void btnExportStudents_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            if (Cls_Main.staticUser.Type != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào tính năng này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Cls_Main.listStudent.Count > 0)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.InitialDirectory = @"D:\";
                    saveFileDialog.RestoreDirectory = true;

                    saveFileDialog.Filter = "Text files (*.xls)|*.xls|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "xls";
                    saveFileDialog.AddExtension = true;

                    saveFileDialog.Title = "Lưu file Excel";
                    saveFileDialog.FileName = string.Format("liststudent_{0}{1:00}{2:00}{3:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Minute);
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        StudentDao studentDao = new StudentDao();
                        studentDao.listStudent = Cls_Main.listStudent;
                        studentDao.XuatExcel(saveFileDialog.FileName);
                        MessageBox.Show("Xuất file thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi: ", ex.Message);
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            ResetPanelHeight();
            OpenTab(new FrmdsSV_Lop(), "Danh sách lớp", true);
        }

        private void btnBnG_Click(object sender, EventArgs e)
        {
            rp_GT gt = new rp_GT();
            gt.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    FrmHocBong frmhb = new FrmHocBong();
            frmhb.ShowDialog();
      
        }

        private void pnlAccount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }
                private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmdsSV_Lop frmdssv = new FrmdsSV_Lop();
            frmdssv.ShowDialog();
        }
    }
}

