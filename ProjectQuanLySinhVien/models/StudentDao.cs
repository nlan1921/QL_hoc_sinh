using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQuanLySinhVien.common;

namespace ProjectQuanLySinhVien.models
{
    public class StudentDao
    {
        public List<Student> listStudent;
        public StudentDao()
        {
            listStudent = new List<Student>();
        }
        public void WriteStudents(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Student student in listStudent) {
                        sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", student.Id, student.FirstName, student.LastName, student.Gender.ToString(), student.Address, student.Email, student.Phone, student.ClassId));
                    }
                }
            }
        }
        public void ReadStudents(string path)
        {
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    listStudent.Clear();
                    string line = null;
                    Student student;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] arr = line.Split(',');
                            student = new Student();
                            student.Id = Convert.ToInt32(arr[0]);
                            student.FirstName = arr[1];
                            student.LastName = arr[2];
                            student.Gender = Convert.ToBoolean(arr[3].ToString());
                            student.Address = arr[4];
                            student.Email = arr[5];
                            student.Phone = arr[6];
                            student.ClassId = Convert.ToInt32(arr[7]);
                            listStudent.Add(student);
                        }
                    }
                }
            }
        }
        public int getMaxId()
        {
            int max = 0;
            foreach (Student item in listStudent)
            {
                if (item.Id > max)
                    max = item.Id;
            }
            return max;
        }

        internal void XuatExcel(string path)
        {
            List<string> list = new List<string>();
            foreach (Student item in listStudent)
            {
                Class classItem = Cls_Main.listClass.Where(o => o.Id == item.ClassId).FirstOrDefault();

                string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", item.Id, item.FirstName, item.LastName, item.Gender == true ? "Nam" : "Nữ", item.Address, item.Email, item.Phone, classItem.Name);
                list.Add(line);
            }
            string[] title = new string[]{
                "MSSV", "Họ đệm","Tên", "Giới tính", "Địa chỉ", "Email", "Số điện thoại", "Lớp"
            };
            ExportExcel.XuatExcel(path, list, "Danh sách học sinh", "Đã ký", title);
        }
        internal void XuatExcelByGioiTinh(string path)
        {
            List<string> list = new List<string>();
            foreach (Class item in Cls_Main.listClass)
            {
                int boy = 0;
                int girl = 0;
                foreach (Student student in listStudent)
                {
                    if (student.ClassId == item.Id)
                    {
                        if (student.Gender == true)
                            boy++;
                        else
                            girl++;
                    }
                }
                list.Add(string.Format("{0},{1},{2},{3}", item.Name, boy, girl, boy + girl));
            }
            string[] title = new string[]{
                "Lớp", "Sĩ số nam","Sĩ số nữ", "Tổng số"
            };
            ExportExcel.XuatExcel(path, list, "Thống kê số lượng sinh viên từng lớp", "Đã ký", title);
        }
    }
}
