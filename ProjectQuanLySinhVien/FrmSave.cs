using ProjectQuanLySinhVien.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQuanLySinhVien
{
    public partial class FrmSave : Form
    {
        //list
        List<User> users;
        List<Student> students;
        List<Class> classes;
        //Dao
        UserDao userDao;
        StudentDao studentDao;
        ClassDao classDao;
        public FrmSave()
        {
            InitializeComponent();
        }

        public FrmDashboard form;
        public delegate void _closeOpenedTab();
        public _closeOpenedTab closeOpenedTab;

        private void save_Load(object sender, EventArgs e)
        {
            userDao = new UserDao();
            studentDao = new StudentDao();
            classDao = new ClassDao();
        }

        private void btn_sv_User_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"D:\";
                saveFileDialog.RestoreDirectory = true;

                saveFileDialog.Filter = "Text files All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "ini";
                saveFileDialog.AddExtension = true;

                saveFileDialog.Title = "Sao Lưu";
                saveFileDialog.FileName = string.Format("danhsachtaikhoan_{0}{1:00}{2:00}{3:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Minute);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    userDao.listUser = Cls_Main.listUser;
                    userDao.WriteUsers(Path.GetFullPath(saveFileDialog.FileName));
                    MessageBox.Show("Sao lưu dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi: ", ex.Message);
            }
        }

        private void btn_sv_Student_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"D:\";
                saveFileDialog.RestoreDirectory = true;

                saveFileDialog.Filter = "Text files All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "ini";
                saveFileDialog.AddExtension = true;

                saveFileDialog.Title = "Sao Lưu";
                saveFileDialog.FileName = string.Format("danhsachsinhvien_{0}{1:00}{2:00}{3:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Minute);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    studentDao.listStudent = Cls_Main.listStudent;
                    studentDao.WriteStudents(Path.GetFullPath(saveFileDialog.FileName));
                    MessageBox.Show("Sao lưu dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi: ", ex.Message);
            }
        }

        private void btn_sv_Class_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"D:\";
                saveFileDialog.RestoreDirectory = true;

                saveFileDialog.Filter = "Text files All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "ini";
                saveFileDialog.AddExtension = true;

                saveFileDialog.Title = "Sao Lưu";
                saveFileDialog.FileName = string.Format("danhsachlop_{0}{1:00}{2:00}{3:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Minute);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    classDao.listClass = Cls_Main.listClass;
                    classDao.WriteClasses(Path.GetFullPath(saveFileDialog.FileName));
                    MessageBox.Show("Sao lưu dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi: ", ex.Message);
            }
        }

        private void btn_rstore_User_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file danh sách";
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                userDao.ReadUsers(path);
                userDao.WriteUsers(Cls_Main.pathListUser);
                Cls_Main.listUser = userDao.listUser;
                MessageBox.Show("Khôi phục dữ liệu thành công");
            }
        }

        private void btn_rstore_Student_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file danh sách";
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                studentDao.ReadStudents(path);
                studentDao.WriteStudents(Cls_Main.pathListStudents);
                Cls_Main.listStudent = studentDao.listStudent;
                MessageBox.Show("Khôi phục dữ liệu thành công");
            }
        }
        private void btn_rstore_Class_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file danh sách";
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                classDao.ReadClasses(path);
                classDao.WriteClasses(Cls_Main.pathListClasses);
                Cls_Main.listClass = classDao.listClass;
                MessageBox.Show("Khôi phục dữ liệu thành công");
            }
        }
    }
}
