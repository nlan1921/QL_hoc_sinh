using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQuanLySinhVien.models
{
    public class Student
    {
        private int id;
        private string firstName;
        private string lastName;
        private bool gender;
        private string address;
        private string email;
        private string phone;
        private int classId;
        private string className;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string FullName
        {
            get => firstName + " " + lastName;
        }
        public bool Gender
        {
            get => gender;
            set => gender = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public int ClassId
        {
            get => classId;
            set => classId = value;
        }

        public string ClassName
        {
            get => className;
            set => className = value;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is Student)
                return this.Id.Equals(((Student)obj).Id);
            return false;
        }

        public int CompareTo(object obj)
        {
            return this.Id.CompareTo(((Student)obj).Id);
        }
    }
}
