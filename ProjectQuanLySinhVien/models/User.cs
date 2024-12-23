using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQuanLySinhVien.models
{
    public class User:IComparable
    {
        private int id;
        private string fullName;
        private bool gender;
        private string username;
        private string password;
        private bool remenber;
        private int type;

        public int ID
        {
            get => id;
            set => id = value;
        }

        public string FullName
        {
            get => fullName;
            set => fullName = value;
        }

        public bool Gender
        {
            get => gender;
            set => gender = value;
        }

        public string UserName
        {
            get => username;
            set => username = value;
        }

        public string PassWord
        {
            get => password;
            set => password = value;
        }

        public bool Remember
        {
            get => remenber;
            set => remenber = value;
        }

        public int Type
        {
            get => type;
            set => type = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
                return this.ID.Equals(((User)obj).ID);
            return false;
         }

        public int CompareTo(object obj)
        {
            return this.ID.CompareTo(((User)obj).ID);
        }
    }
}
