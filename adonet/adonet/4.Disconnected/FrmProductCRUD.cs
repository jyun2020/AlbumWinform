using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonet._4.Disconnected
{
    public partial class FrmProductCRUD : Form
    {
        public FrmProductCRUD()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataset);

        }

        private void FrmProductCRUD_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'northwindDataset.Products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.northwindDataset.Products);

        }

        private void Button13_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.MoveFirst();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.MoveLast();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.MovePrevious();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.MoveNext();
        }
        bool flag = true;
        private void Button23_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                productsBindingSource.Sort = "ProductID ASC";
            }
            else
            {
                productsBindingSource.Sort = "ProductID DESC";
            }
            flag = !flag;
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            productsBindingSource.AddNew();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            FrmAddProduct f = new FrmAddProduct();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(f.pdname))
                {
                    //弱型別
                    //    DataRow dr = northwindDataset.Products.NewRow();
                    //dr["ProductName"] = f.pdname;
                    //dr["Discontinued"] = f.discontinued;
                    //northwindDataset.Products.Rows.Add(dr);
                    //productsBindingSource.Position = northwindDataset.Products.Rows.Count - 1;


                    NorthwindDataset.ProductsRow productsRow = northwindDataset.Products.NewProductsRow();
                    productsRow.ProductName = f.pdname;
                    productsRow.Discontinued = f.discontinued;
                    northwindDataset.Products.Rows.Add(productsRow);
                    productsBindingSource.Position = northwindDataset.Products.Rows.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("Testcancel");
            }
       }
    }
}
