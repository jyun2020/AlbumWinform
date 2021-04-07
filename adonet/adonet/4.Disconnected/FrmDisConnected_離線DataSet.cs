using adonet._4.Disconnected;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmDisConnected_離線DataSet : Form
    {
        public FrmDisConnected_離線DataSet()
        {
            InitializeComponent();
            productsTableAdapter1.Fill(this.northwindDataset1.Products);
            categoriesTableAdapter1.Fill(this.northwindDataset1.Categories);
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(this.northwindDataset1.Products);
            categoriesTableAdapter1.Fill(this.northwindDataset1.Categories);
            dataGridView1.DataSource = northwindDataset1.Products;
            //-----------------------------------------------------------
            //dataGridView1.DataSource = northwindDataset1;
            //dataGridView1.DataMember = "Products";
            //-----------------------------------------------------------
            dataGridView7.DataSource = northwindDataset1.Products;
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            dataGridView7.AllowUserToAddRows = false;
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            dataGridView7.Rows[2].Frozen = true;
            dataGridView7.Columns[2].Frozen = true;
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView7.CurrentCell.Value.ToString());
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView7.CurrentRow.Cells[2].Value.ToString());
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            if (e.ColumnIndex == 0)//直的第一行
            {
                id = (int)dataGridView7.Rows[e.RowIndex].Cells["ProductID"].Value;
                MessageBox.Show("ProductID = "+dataGridView7.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
                //點到的那一列 , 並顯示出productid的資料
                FrmProductDetail f = new FrmProductDetail(id);
                f.Show();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            dataGridView8.DataSource = this.northwindDataset1.Products;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataColumn col1 = new DataColumn("TotalPrice", typeof(Int32));
            col1.Expression = "UnitPrice * UnitsInStock";
            northwindDataset1.Products.Columns.Add(col1);
            dataGridView8.CellFormatting += DataGridView8_CellFormatting;
        }

        private void DataGridView8_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView8.Columns[e.ColumnIndex].Name == "TotalPrice")
            {
                e.CellStyle.Format = "C2";
                e.CellStyle.BackColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProductCRUD f = new FrmProductCRUD();
            f.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            FrmLookUP f = new FrmLookUP();
            f.Show();
        }
    }
}
