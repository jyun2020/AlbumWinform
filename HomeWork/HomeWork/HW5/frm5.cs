using HomeWork.Properties;
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

namespace HomeWork.HW5
{
    public partial class frm5 : Form
    {
        string ConnString = Settings.Default.MyCityConnectionString;
        string CityId = "";
        public frm5()
        {
            InitializeComponent();
            AddComboboxItem();
            LoadImage();
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel1.DragDrop += FlowLayoutPanel1_DragDrop;
            flowLayoutPanel1.DragEnter += FlowLayoutPanel1_DragEnter;
        }

        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] x = (string[])e.Data.GetData(DataFormats.FileDrop);//丟進來的檔案,取得路徑
            for (int i = 0; i < x.Length; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile(x[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Click += Pic_Click;
                this.flowLayoutPanel1.Controls.Add(pic);
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox s = sender as PictureBox;
            if (s != null)
            {
                Form f = new Form();
                f.BackgroundImage = s.Image;
                f.BackgroundImageLayout = ImageLayout.Stretch;
                f.Show();
            }
        }

        private void AddComboboxItem()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM City", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["CityName"]);
                    }
                    this.comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadImage()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Image FROM CityImage WHERE CityId = {comboBox1.SelectedIndex+1}", conn);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM City WHERE CityName = N'{comboBox1.Text}'", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CityId = reader["CityId"].ToString();
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            LoadImage();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "*.jpg|*.jpg|*.gif|*.gif";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();
                        //INSERT INTO CityImage  values (1,123, (SELECT * FROM OPENROWSET(BULK N'C:\\Users\\User\\Pictures\\preview.jpg', SINGLE_BLOB) as T1))
                        command.CommandText = $"INSERT INTO CityImage values ({Convert.ToInt32(CityId)},{CityId}, (SELECT * FROM OPENROWSET(BULK N'{this.openFileDialog1.FileName.ToString()}', SINGLE_BLOB) as T1))";
                        //command.Parameters.Add("@CityId", SqlDbType.Int,4).Value = CityId;
                        //command.Parameters.Add("@ImageFileName", SqlDbType.NVarChar, 50).Value = "123";
                        command.Connection = conn;
                        int a = command.ExecuteNonQuery();
                        MessageBox.Show("Add Success!"+a);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadImage();
            }
        }
    }
}
