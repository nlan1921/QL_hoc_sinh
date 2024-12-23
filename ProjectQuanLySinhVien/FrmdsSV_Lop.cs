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
    public partial class FrmdsSV_Lop : Form
    {
        public FrmdsSV_Lop()
        {
            InitializeComponent();
        }
        public FrmDashboard form;
        public delegate void _closeOpenedTab();
        public _closeOpenedTab closeOpenedTab;

        SqlDataAdapter da;
        SqlDataAdapter da2;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlCommandBuilder cmb;
        DataSet ds;
        DataTable dt = new DataTable();
        BindingSource bin = new BindingSource();
        SqlConnection cnn = new SqlConnection();
        private void FrmdsSV_Lop_Load(object sender, EventArgs e)
        {
            KetNoi();
            Datquanhe("Lop", "SinhVien", "MaLop", "MaLop", "Lop_SinhVien");

            Buoccacdieukhien();
        }
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

            private void Buoccacdieukhien()
            {
                listBox1.DataSource = ds;
                listBox1.DisplayMember = "Lop.MaLop";
                dataview.DataSource = ds;
            dataview.DataMember = "Lop.Lop_SinhVien";
                txtMaLop.DataBindings.Add("Text", ds, "Lop.Lop_SinhVien.MaLop");
                txtTenLop.DataBindings.Add("Text", ds, "Lop.Lop_SinhVien.TenLop");
                txtMaSV.DataBindings.Add("Text", ds, "Lop.Lop_SinhVien.MaSV");
                txtTenSV.DataBindings.Add("Text", ds, "Lop.Lop_SinhVien.TenSV");

            }
            private void Datquanhe(string bangchinh, string bangphu, string khoachinh, string khoaphu, string tenquanhe)
            {

                cmd = new SqlCommand("select * from " + bangchinh, cnn);
                da = new SqlDataAdapter(cmd);
                cmd2 = new SqlCommand("select * from " + bangphu, cnn);
                da2 = new SqlDataAdapter(cmd2);
                ds = new DataSet();
                da.Fill(ds, bangchinh);
                da2.Fill(ds, bangphu);
                DataColumn chinh = ds.Tables[bangchinh].Columns[khoachinh];
                DataColumn phu = ds.Tables[bangphu].Columns[khoaphu];
                DataRelation r = new DataRelation(tenquanhe, chinh, phu);
                ds.Relations.Add(r);

            }
        }
}
