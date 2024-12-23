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
    public partial class FrmDanhsachSv : Form
    {
        public FrmDanhsachSv()
        {
            InitializeComponent();
        }
        StudentDao studentDao;
        List<Student> list;

        List<Class> listClass;
        Student student;

        public FrmDashboard form;
        public delegate void _closeOpenedTab();
        public _closeOpenedTab closeOpenedTab;

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


        private void FrmDanhsachSv_Load(object sender, EventArgs e)
        {
            studentDao = new StudentDao();
            LoadData();
        }
        private void LoadData()
        {

            KetNoi();
            string s = "Select *From SinhVien";
            SqlCommand cmd = new SqlCommand(s, cnn);
            da.SelectCommand = cmd;
            da.Fill(dt);
            BindingSource bin = new BindingSource();
            bin.DataSource = dt;
            DataView.DataSource = bin;
        }

        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaSV.Text = Convert.ToString(DataView.CurrentRow.Cells["MaSV"].Value);
                txtTenSV.Text = Convert.ToString(DataView.CurrentRow.Cells["TenSV"].Value);
                txtMaLop.Text = Convert.ToString(DataView.CurrentRow.Cells["MaLop"].Value);
                txtGioiTinh.Text = Convert.ToString(DataView.CurrentRow.Cells["GioiTinh"].Value);
                txtNgaySinh.Text = Convert.ToString(DataView.CurrentRow.Cells["NgaySinh"].Value);               
                txtDTB.Text = Convert.ToString(DataView.CurrentRow.Cells["DTB"].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindingContext[dt].AddNew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String Scon;
            Scon = "UPDATE SinhVien set MaSV=@MaSV, TenSV=@TenSV,MaLop= @MaLop, NgaySinh= @NgaySinh ,GioiTinh= @GioiTinh, DTB=@DTB";
            SqlCommand cmd1 = new SqlCommand(Scon, cnn);
            cmd1.Parameters.Add("@MaSV", SqlDbType.Int).Value = int.Parse(txtMaSV.Text);
            cmd1.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = txtTenSV.Text;
            cmd1.Parameters.Add("@MaLop", SqlDbType.Int).Value = int.Parse(txtMaLop.Text);
            cmd1.Parameters.Add("@GioiTinh", SqlDbType.NChar).Value = txtGioiTinh.Text;
            cmd1.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = DateTime.Parse(txtNgaySinh.Text);
            cmd1.Parameters.Add("@DTB", SqlDbType.Float).Value = float.Parse(txtDTB.Text);
            int count = cmd1.ExecuteNonQuery();
            //add client
            //DataRowView row = (DataTable)dt.;
            //row["MaNV"] = float.Parse(txtmanv.Text);
            //row["Ho"] = float.Parse(txtho.Text);
            //row["Ten"] = float.Parse(txtten.Text);
            //row["GioiTinh"] = float.Parse(txtgioitinh.Text);
            //row["LuongCB"] = float.Parse(txtluong.Text);
            //row["CongViec"] = float.Parse(txtcv.Text);
            //row["MaKV"] = float.Parse(txtkv.Text);
            //dataview.ResetCurrentItem();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.BindingContext[dt].RemoveAt(0);
            MessageBox.Show("Xoa thanh cong!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            closeOpenedTab();
        }

        private void txtSearchInput_TextChanged(object sender, EventArgs e)
        {
           if (list.Count > 0)
           {
                List<Student> result = new List<Student>();

                foreach (Student student in list)
                {
                    if (string.IsNullOrEmpty(txtSearchInput.Text) || student.FirstName.ToLower().Contains(txtSearchInput.Text.ToLower()) || student.LastName.ToLower().Contains(txtSearchInput.Text.ToLower()) || student.Id.ToString().ToLower().Contains(txtSearchInput.Text.ToLower()) || student.Address.ToLower().Contains(txtSearchInput.Text.ToLower())  || student.Email.ToLower().Contains(txtSearchInput.Text.ToLower()) || student.Phone.ToLower().Contains(txtSearchInput.Text.ToLower()) || student.ClassName.ToLower().Contains(txtSearchInput.Text.ToLower())) 
                        result.Add(student);
                }

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = result;
                //dgvUsersList.DataSource = bindingSource;
           }
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            this.BindingContext[dt].Position = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.BindingContext[dt].Position --;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.BindingContext[dt].Position ++;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int last = this.BindingContext[dt].Count - 1;
            this.BindingContext[dt].Position = last;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }      
    }
}
