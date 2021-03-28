using adonet._1.Overview;
using adonet.NorthwindDatasetTableAdapters;
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

namespace adonet
{
    public partial class FrmOverview : Form
    {
        public FrmOverview()
        {
            InitializeComponent();
        }
        string connString = "Data Source=127.0.0.1,1434;Initial Catalog=Northwind;Integrated Security=True";
        string commendString = "SELECT * FROM PRODUCTS";
        string commendString1 = "SELECT * FROM Categories";
        private void button1_Click(object sender, EventArgs e)
        {
            //step1:SqlConneted
            //step2:SqlCommand
            //step3:SqlDataReader
            //step4:Ui
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                SqlCommand command = new SqlCommand(commendString, conn);

                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string s = $"{dataReader["ProductName"],-35} *** {dataReader["UnitPrice"]:c2}";
                    this.listBox1.Items.Add(s);
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(commendString, conn);

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string s = $"{dataReader["ProductName"],-35} *** {dataReader["UnitPrice"]:c2}";
                        this.listBox1.Items.Add(s);
                    }
                }//自動化close&dispose
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void status_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = null;
                using (conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(commendString, conn);
                    conn.Open();
                    MessageBox.Show(conn.State.ToString());
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string s = $"{dataReader[0],-35} *** {dataReader[1]:c2}";
                        this.listBox1.Items.Add(s);
                    }
                }//自動化close&dispose
                MessageBox.Show(conn.State.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Step1:sqlconnection
            //Step2:sqlDataAdapter
            //Step3:Dataset
            //Step4:Fill
            //Step5:UI
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commendString,conn);
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(commendString1, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds,"products");
            
            dataAdapter1.Fill(ds, "Categories");
            dataGridView1.DataSource = (ds.Tables["Categories"]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.northwindDataset1.Products);
            dataGridView2.DataSource = this.northwindDataset1.Products;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CategoriesTableAdapter ct = new CategoriesTableAdapter();
            NorthwindDataset dataset = new NorthwindDataset();
            ct.Fill(dataset.Categories);
            dataGridView2.DataSource = dataset.Categories;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string commendString1 = "SELECT * FROM Products WHERE UnitPrice>30";
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commendString1, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds,"ProductsUnitPrice");
            dataGridView1.DataSource = ds.Tables["ProductsUnitPrice"];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.FillByUnitPrice(this.northwindDataset1.Products,30);
            dataGridView2.DataSource = this.northwindDataset1.Products;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.InsertProducts(DateTime.Now.ToString(), true);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Update(this.northwindDataset1.Products);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.northwindDataset1.Categories);
            this.bindingSource1.DataSource = this.northwindDataset1.Categories;
            this.dataGridView3.DataSource = bindingSource1;
            this.bindingNavigator1.BindingSource = bindingSource1;

            pictureBox1.DataBindings.Clear();
            label4.DataBindings.Clear();
            pictureBox1.DataBindings.Add("Image", bindingSource1, "Picture", true);
            label4.DataBindings.Add("Text", bindingSource1, "CategoryName");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bindingSource1.Position -= 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bindingSource1.Position += 1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = bindingSource1.Count-1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.customersTableAdapter1.Fill(northwindDataset1.Customers);
            this.bindingSource2.DataSource = northwindDataset1.Customers;
            this.bindingNavigator1.BindingSource = bindingSource2;
            this.dataGridView3.DataSource = bindingSource2;

            pictureBox1.DataBindings.Clear();
            pictureBox1.Image = null;
            label4.DataBindings.Clear();
            label4.DataBindings.Add("Text", bindingSource2, "CompanyName");
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            label3.Text = $"{this.bindingSource1.Position + 1 } / {this.bindingSource1.Count}";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmTool f = new frmTool();
            f.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            categoriesTableAdapter1.Fill(northwindDataset1.Categories);
            productsTableAdapter1.Fill(northwindDataset1.Products);
            for (int i = 0; i < this.northwindDataset1.Tables.Count; i++)
            {
                DataTable table =  northwindDataset1.Tables[i];
                listBox2.Items.Add(table.TableName);
                string s = "";
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    s += $"{ table.Columns[col],-50}  ";
                }
                listBox2.Items.Add(s);

                string s2 = "";
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col <table.Columns.Count; col++)
                    {
                     
                        s2 += $"{table.Rows[row][col].ToString(),-50}" ;
                    }
                    listBox2.Items.Add(s2);
                    s2 = "";
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            northwindDataset1.Products.Rows[0]["ProductName"] += "123";
            northwindDataset1.Products.WriteXml("Products.xml",XmlWriteMode.WriteSchema);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            northwindDataset1.Products.Clear();
            northwindDataset1.Products.ReadXml("Products.xml");
            dataGridView4.DataSource = northwindDataset1.Products;
        }
    }
}
