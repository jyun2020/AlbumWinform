using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW2
{
    public partial class frm2 : Form
    {
        public frm2()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True";
        string SelectTable = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
        string CategoryName = "SELECT CategoryName FROM Categories";
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = null;
                using (conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SelectTable, conn);
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr[0].ToString());
                    }
                    conn.Close();
                    SqlCommand command1 = new SqlCommand(CategoryName, conn);
                    conn.Open();
                    SqlDataReader dr1 = command1.ExecuteReader();
                    while (dr1.Read())
                    {
                        comboBox2.Items.Add(dr1[0].ToString());
                    }
                }
                comboBox2.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox1.SelectedIndex = 0;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string Select = string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", comboBox1.Text);
            try
            {
                SqlConnection conn = null;
                using (conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(Select, conn);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox3.Items.Add(dr["COLUMN_NAME"]);
                    }
                }
                comboBox3.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = null;
                using (conn = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Customers", conn);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Select = string.Format("SELECT * FROM Products JOIN Categories ON Products.CategoryID = Categories.CategoryID WHERE Categories.CategoryName='{0}'", comboBox2.Text);
            try
            {
                SqlConnection conn = null;
                using (conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(Select, conn);
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView3.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string Select = string.Format("SELECT DISTINCT [{0}] FROM [{1}]", comboBox3.Text, comboBox1.Text);
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(Select, conn);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        listBox1.Items.Add(dr[comboBox3.Text]);
                    }
                    if (listBox1.Items.Count == 0)
                    {
                        listBox1.Items.Add("無資料");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
