using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW3
{
    public partial class frm3 : Form
    {
        public frm3()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BeginDate.MinDate = new DateTime(1997, 1, 1);
            BeginDate.MaxDate = new DateTime(2004, 1, 1);
            EndDate.MinDate = new DateTime(1997, 1, 1);
            EndDate.MaxDate = new DateTime(2004, 1, 1);
            BeginDate.CustomFormat = "yyyy / MM / dd";
            EndDate.CustomFormat = "yyyy / MM / dd";
            BeginDate.Format = DateTimePickerFormat.Custom;
            EndDate.Format = DateTimePickerFormat.Custom;

            List<DateTime> a = new List<DateTime>();

            this.productPhotoTableAdapter1.FillByYears(aWdataset1.ProductPhoto);
            foreach (DataRow dr in aWdataset1.ProductPhoto.Rows)
            {
                a.Add(dr.Field<DateTime>("ModifiedDate").Date);
            }
            comboBox1.DataSource = a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime begin = BeginDate.Value;
            DateTime end = EndDate.Value;
            this.productPhotoTableAdapter1.FillByDate(this.aWdataset1.ProductPhoto,begin, end);
            this.bindingSource1.DataSource = aWdataset1.ProductPhoto;
            this.bindingNavigator1.BindingSource = bindingSource1;
            this.dataGridView1.DataSource = bindingSource1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter1.FillByYearsResult(this.aWdataset1.ProductPhoto,Convert.ToDateTime( comboBox1.SelectedItem));
            this.bindingSource1.DataSource = this.aWdataset1.ProductPhoto;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.dataGridView1.DataSource = this.bindingSource1;

            label3.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            label3.DataBindings.Add("text", bindingSource1, "ProductPhotoID");
            pictureBox1.DataBindings.Add("Image", bindingSource1, "LargePhoto", true);
        }
    }
}
