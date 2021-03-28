using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW4
{
    public partial class frm4 : Form
    {
        public frm4()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.nWdataset1.Products);
            this.categoriesTableAdapter1.Fill(this.nWdataset1.Categories);
            this.customersTableAdapter1.Fill(this.nWdataset1.Customers);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < nWdataset1.Tables.Count; i++)
            {
                // 把dataset的table轉成datatable
                DataTable dataTable = nWdataset1.Tables[i];
                //加入TableName
                listBox1.Items.Add(dataTable.TableName);
                //加入欄位
                string cols = "";
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    cols += $"{dataTable.Columns[col],-60}";
                }
                listBox1.Items.Add(cols);
                //加入每一列資料
                for (int row = 0; row <dataTable.Rows.Count; row++)
                {
                    string datas = "";
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        datas += $"{dataTable.Rows[row][col],-60}";
                    }
                    listBox1.Items.Add(datas);
                }
                listBox1.Items.Add("  ");
                listBox1.Items.Add("  ");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            nWdataset1.Products.WriteXml("Products.xml", XmlWriteMode.WriteSchema);
            nWdataset1.Categories.WriteXml("Categories.xml", XmlWriteMode.WriteSchema);
            nWdataset1.Customers.WriteXml("Customers.xml",XmlWriteMode.WriteSchema);

            MessageBox.Show("Write XML Success!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nWdataset1.Clear();
            nWdataset1.Products.ReadXml("Products.xml");
            nWdataset1.Categories.ReadXml("Categories.xml");
            nWdataset1.Customers.ReadXml("Customers.xml");

            dataGridView1.DataSource = nWdataset1.Products;
            dataGridView2.DataSource = nWdataset1.Categories;
            dataGridView3.DataSource = nWdataset1.Customers;

            MessageBox.Show("Read XML Success!");
        }
    }
}
