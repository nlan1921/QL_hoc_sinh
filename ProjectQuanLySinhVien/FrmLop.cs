using ProjectQuanLySinhVien.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectQuanLySinhVien
{
    public partial class FrmLop : Form
    {
        ClassDao classDao;
        List<Class> list;
        Class lop;
        public FrmLop()
        {
            InitializeComponent();
        }

        public FrmDashboard form;
        public delegate void _closeOpenedTab();
        public _closeOpenedTab closeOpenedTab;

        private void FromLop_Load(object sender, EventArgs e)
        {
            KetNoi();
            string s = "Select *From Lop";
            SqlCommand cmd = new SqlCommand(s, cnn);
            da.SelectCommand = cmd;
            da.Fill(dt);
            BindingSource bin = new BindingSource();
            bin.DataSource = dt;
            dataview.DataSource = bin;
        }

        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlCommandBuilder cmb;
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection();

        private void KetNoi()
        {
            try
            {
                cnn.ConnectionString = @"Data Source=asus\sqlexpress;Initial Catalog=19CT112_04_05;Integrated Security=True";
                cnn.Open();
                MessageBox.Show("Ket Noi Database Thành Công!");

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Lỗi Ket Noi!");
            }
        }
        private void LoadData()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindingContext[dt].AddNew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String Scon;
            Scon = "UPDATE Lop set MaLop=@MaLop, TenLop=@TenLop";
            SqlCommand cmd1 = new SqlCommand(Scon, cnn);
            cmd1.Parameters.Add("@MaLop", SqlDbType.Int).Value = int.Parse(txtMaLop.Text);
            cmd1.Parameters.Add("@TenLop", SqlDbType.NVarChar).Value = txtTenLop.Text;
            MessageBox.Show("Sua thanh cong!");
            dt.Clear();
            da.Fill(dt);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = dt.GetChanges();
            if (tbl == null)
            {
                MessageBox.Show("Du lieu chua thay doi");
            }
            else
            {
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                da.Update(dt);
                MessageBox.Show("Co " + tbl.Rows.Count + "dong da duoc cap nhat");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            closeOpenedTab();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.BindingContext[dt].RemoveAt(0);
            MessageBox.Show("Xoa thanh cong!");
        }

        private void dgvClassesList_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaLop.Text = Convert.ToString(dataview.CurrentRow.Cells["MaLop"].Value);
                txtTenLop.Text = Convert.ToString(dataview.CurrentRow.Cells["TenLop"].Value);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
