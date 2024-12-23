using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQuanLySinhVien.models
{
    public class ClassDao
    {
        public List<Class> listClass;
        public ClassDao()
        {
            listClass = new List<Class>();
        }
        public void WriteClasses(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Class classItem in listClass) {
                        sw.WriteLine(string.Format("{0},{1},{2}", classItem.Id, classItem.Name, classItem.LeaderName));
                    }
                }
            }
        }
        public void ReadClasses(string path)
        {
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    listClass.Clear();
                    string line = null;
                    Class classItem;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] arr = line.Split(',');
                            classItem = new Class();
                            classItem.Id = Convert.ToInt32(arr[0]);
                            classItem.Name = arr[1];
                            classItem.LeaderName = arr[2];
                            listClass.Add(classItem);
                        }
                    }
                }
            }
        }

        public int GetMaxId()
        {
            int max = 0;
            foreach (Class item in listClass)
            {
                if (item.Id > max)
                    max = item.Id;
            }
            return max;
        }
    }
}
