using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQuanLySinhVien.models;
using System.Windows.Forms;

namespace ProjectQuanLySinhVien
{
    public class Cls_Main
    {
        public static User staticUser = new User();

        public static List<User> listUser = new UserDao().listUser;
        public static List<Student> listStudent = new StudentDao().listStudent;
        public static List<Class> listClass = new ClassDao().listClass;
      
        public static string pathListUser = string.Format(@"{0}\listUsers.ini", Application.StartupPath);
        public static string pathListStudents = string.Format(@"{0}\listStudents.ini", Application.StartupPath);
        public static string pathListClasses = string.Format(@"{0}\listClasses.ini", Application.StartupPath);
    }
}