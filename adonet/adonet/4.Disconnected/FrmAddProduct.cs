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
    public partial class FrmAddProduct : Form
    {
        public string pdname = "";
        public bool discontinued;
        public FrmAddProduct()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                pdname = textBox1.Text;
                discontinued = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
