using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaiTapVN

{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=QUANLYKHACHSAN;Integrated Security=True";
            con.ConnectionString = connectionString;
            con.Open();
            string sql = "select * from Phong";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable tablePhong = new DataTable();
            adp.Fill(tablePhong);
          dataGridView1.DataSource = tablePhong;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtDonGia.Text = "";
            txtMaPhong.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã phòng");
                txtMaPhong.Focus();
                return;
            }

            if (txtTenPhong.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên phòng");
                txtTenPhong.Focus();
                return;
            }
            else
            {
                string sql = "insert into Phong values ('" + txtMaPhong.Text + "', '" + txtTenPhong.Text + "'";
                if (txtDonGia.Text != "")
                    sql = sql + "," + txtDonGia.Text.Trim();
                sql = sql + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.BeginExecuteNonQuery();
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = dataGridView1.Rows[1].Cells[1].Value.ToString();
            txtTenPhong.Text = dataGridView1.Rows[1].Cells[2].Value.ToString();
            txtDonGia.Text = dataGridView1.Rows[1].Cells[3].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = "delete from Phong where maPhong= '" + txtMaPhong.Text + "'";
            
        }
    }
}
