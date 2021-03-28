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
using WindowsFormsApp1._1._Overview;

namespace WindowsFormsApp1
{
    public partial class FrmOverview : Form
    {
        public FrmOverview()
        {  
            InitializeComponent();
            // this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
            this.Text = "xxx";

            this.splitContainer2.SplitterDistance = this.splitContainer2.Panel1.Height / 2;
            this.splitContainer3.SplitterDistance = this.splitContainer3.Panel1.Width / 3;
         }

      
        private void button1_Click(object sender, EventArgs e)
        {
            //Connected

            //Step 1: SqlConnecion
            //Step 2: SqlCommand
            //Step 3: SqlDataReader
            //Step 4: UI (control)
            SqlConnection conn = null;

            //int i=8;
            //i = i + 1;
            try
            {
               conn  = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
               conn.Open();

                SqlCommand command = new SqlCommand("Select * from Products", conn);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    //string s = string.Format(......)
                    string s = $"{dataReader["ProductName"],-40} *** {dataReader["UnitPrice"]:c2}";
                    this.listBox1.Items.Add(s);
                }
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {   
                    conn.Close();
                    conn.Dispose(); //釋放 System.ComponentModel.Component 所使用的所有資源。
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Disconnected
            //DataSet

            //Step 1: SqlConnecion
            //Step 2: SqlDataAdapter
            //Step 3: DataSet
            //Step 4: UI (control)

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from  categories", conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);  //Auto conn.open()=>command execute....=>while(...Read().....)...=>dataset=>conn.close()

            this.dataGridView1.DataSource = ds.Tables[0];

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True")) 
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("Select * from Products", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read()) 
                    {
                        //string s = string.Format(......)
                        string s = $"{dataReader["ProductName"],-40} *** {dataReader["UnitPrice"]:c2}";
                        this.listBox1.Items.Add(s);
                    }

                } //Auto conn.Close(); conn.Dispose()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = null;
                using ( conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True"))
                {
                    conn.Open();
                    MessageBox.Show(conn.State.ToString());

                    SqlCommand command = new SqlCommand("Select * from Products", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        //string s = string.Format(......)
                        string s = $"{dataReader["ProductName"],-40} *** {dataReader["UnitPrice"]:c2}";
                        this.listBox1.Items.Add(s);
                    }

                } //Auto conn.Close(); conn.Dispose()
                MessageBox.Show(conn.State.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.dataGridView2.DataSource = this.nwDataSet1.Products;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
            this.dataGridView2.DataSource = this.nwDataSet1.Categories;
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            //TODO　.......
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from  Products where UnitPrice > 30", conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "xxx");  //Auto Connected... conn.open()=>command execute....=>while(...Read().....)...=>dataset=>conn.close()

            this.dataGridView1.DataSource = ds.Tables["xxxx"];

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //FillXXX(...)
            //Auto conn.open()=>command execute....=>while(...Read().....)...=>dataset=>conn.close()
           
           // this.productsTableAdapter1.Connection 可修改

            this.productsTableAdapter1.FillByUnitPrice(this.nwDataSet1.Products, 30);
            this.dataGridView2.DataSource = this.nwDataSet1.Products;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.InsertProduct(DateTime.Now.ToLongTimeString(), true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Update(this.nwDataSet1.Products);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            //this.dataGridView3.DataSource = this.nwDataSet1.Products;

            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);

            this.bindingSource1.DataSource = this.nwDataSet1.Categories;
            this.dataGridView3.DataSource = this.bindingSource1;

            this.bindingNavigator1.BindingSource = this.bindingSource1;

            //==================================================================
            this.textBox1.DataBindings.Add("Text", this.bindingSource1, "CategoryName");
            this.pictureBox1.DataBindings.Add("Image", this.bindingSource1, "Picture", true);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MoveNext();
           // this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.bindingSource1.MovePrevious();
           // this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
            //this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.bindingSource1.Count - 1;
            //this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.customersTableAdapter1.Fill(this.nwDataSet1.Customers);
            this.dataGridView3.DataSource = this.nwDataSet1.Customers;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            FrmTool f = new FrmTool();
            f.Show();
           
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

            this.listBox2.Items.Clear();
            for (int i=0; i<= this.nwDataSet1.Tables.Count-1; i++)
            {
                DataTable table = this.nwDataSet1.Tables[i];
                this.listBox2.Items.Add(table.TableName);

                //table.Columns -資料行 (Column Schema) 
                //table.Rows    -資料列 (資料記錄 Data) 

                string s = "";
                for (int column=0; column<=table.Columns.Count-1; column++)
                {
                    s += $"{table.Columns[column].ColumnName,-40}";
                }

                this.listBox2.Items.Add(s);

                //========================================
                for (int row= 0; row <=table.Rows.Count-1; row++)
                {
                    this.listBox2.Items.Add(table.Rows[row]);
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

            MessageBox.Show(this.nwDataSet1.Products.Rows[0]["ProductName"].ToString());
            MessageBox.Show(this.nwDataSet1.Products.Rows[0][1].ToString());

            DataRow dr = this.nwDataSet1.Products.Rows[0];
            MessageBox.Show(dr[1].ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.nwDataSet1.Products.Rows[0]["ProductName"] += "yyyy";
            this.nwDataSet1.Products.WriteXml("Products.xml",  XmlWriteMode.WriteSchema);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.nwDataSet1.Products.Clear();
            this.nwDataSet1.Products.ReadXml("Products.xml");

            this.dataGridView4.DataSource = this.nwDataSet1.Products;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
    }
}
