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
    public partial class FrmPhanQuyen : Form
    {
        public FrmPhanQuyen()
        {
            InitializeComponent();
        }

        public FrmDashboard form;
        public delegate void _closeOpenedTab();
        public _closeOpenedTab closeOpenedTab;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
