using ProjectQuanLySinhVien.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQuanLySinhVien
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserDao _userDao = new UserDao();
            _userDao.ReadUsers(Cls_Main.pathListUser);
            Cls_Main.listUser = _userDao.listUser;

            StudentDao studentDao = new StudentDao();
            studentDao.ReadStudents(Cls_Main.pathListStudents);
            Cls_Main.listStudent = studentDao.listStudent;

            ClassDao classDao = new ClassDao();
            classDao.ReadClasses(Cls_Main.pathListClasses);
            Cls_Main.listClass = classDao.listClass;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new FrmDashboard();
            Application.Run();
        }
    }
}
