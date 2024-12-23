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
    public partial class FrmHocBong : Form
    {
        public FrmHocBong()
        {
            InitializeComponent();
        }

        private void FrmHocBong_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
