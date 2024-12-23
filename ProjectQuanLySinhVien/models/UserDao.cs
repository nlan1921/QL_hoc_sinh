using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQuanLySinhVien.models
{
    public class UserDao
    {
        public List<User> listUser;
        public UserDao ()
        {
            listUser = new List<User>();
        }
        public void WriteUsers(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (User user in listUser) {
                        string strSave = string.Format("{0},{1},{2},{3},{4},{5},{6}", user.ID, user.FullName, user.Gender.ToString(), user.UserName, user.PassWord, user.Remember.ToString(), user.Type);
                        Console.WriteLine(strSave);
                        sw.WriteLine(strSave);
                    }
                }
            }
        }

        public void ReadUsers(string path)
        {
            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    listUser.Clear();
                    string line = null;
                    User user;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] arr = line.Split(',');
                            user = new User(); 
                            user.ID = Convert.ToInt32(arr[0]);
                            user.FullName = arr[1];
                            user.Gender = Convert.ToBoolean(arr[2].ToString());
                            user.UserName = arr[3];
                            user.PassWord = arr[4];
                            user.Remember = Convert.ToBoolean(arr[5].ToString());
                            user.Type = Convert.ToInt32(arr[6]);
                            listUser.Add(user);
                        }
                    }
                }
            }
        }

        public int GetMaxId()
        {
            int max = 0;
            foreach (User item in listUser)
            {
                if (item.ID > max)
                    max = item.ID;
            }
            return max;
        }
    }
}
