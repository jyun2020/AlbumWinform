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
    public partial class FrmProductDetail : Form
    {
        int id;
        public FrmProductDetail(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataset);

        }

        private void productsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataset);

        }

        private void FrmProductDetail_Load(object sender, EventArgs e)
        {
            this.productsTableAdapter.FillByProductID(this.northwindDataset.Products,id);
        }
    }
}
