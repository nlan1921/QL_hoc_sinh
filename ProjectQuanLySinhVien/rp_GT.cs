using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQuanLySinhVien
{
    public partial class rp_GT : Form
    {
        public rp_GT()
        {
            InitializeComponent();
        }

        private void rp_GT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_19CT112_04_05DataSet.Diem1' table. You can move, or remove it, as needed.
            this.diem1TableAdapter.Fill(this._19CT112_04_05DataSet.Diem1);

            this.reportViewer1.RefreshReport();
        }
    }
}
