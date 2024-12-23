using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQuanLySinhVien.models
{
    class UserType
    {
        private int id;
        private string type;
       
        public int ID
        {
            get => id;
            set => id = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }
    }
}
