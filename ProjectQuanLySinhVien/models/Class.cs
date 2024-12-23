using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQuanLySinhVien.models
{
    public class Class
    {
        private int id;
        private string name;
        private string leaderName;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string LeaderName
        {
            get => leaderName;
            set => leaderName = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Class)
                return this.Id.Equals(((Class)obj).Id);
            return false;
        }

        public int CompareTo(object obj)
        {
            return this.Id.CompareTo(((Class)obj).Id);
        }
    }
}
