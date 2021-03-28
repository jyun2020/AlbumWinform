using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace Starter
{
    public partial class FrmConnected : Form
    {
        public FrmConnected()
        {
            InitializeComponent();

            LoadCountryToComBox();

            this.listView1.View = View.Details;
            CreateListViewColumns();

            this.tabControl1.SelectedIndex = 3;
            this.tabControl2.SelectedIndex = 1;

            //====================================
            this.pictureBox1.AllowDrop = true;
            this.pictureBox1.DragEnter += PictureBox1_DragEnter;
            this.pictureBox1.DragDrop += PictureBox1_DragDrop;

            //==================================
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.DragEnter += FlowLayoutPanel1_DragEnter;
            this.flowLayoutPanel1.DragDrop += FlowLayoutPanel1_DragDrop;

        }

        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop);

            for (int i=0; i<= filenames.Length-1; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile(filenames[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                pic.Click += Pic_Click;

                this.flowLayoutPanel1.Controls.Add(pic);
            }
           
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {
                Form f = new Form();
                f.BackgroundImage = pic.Image;
                f.BackgroundImageLayout = ImageLayout.Stretch;
                f.Show();
            }
        }

        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            //MessageBox.Show("Drop");
            string[] filenames = (string[]) e.Data.GetData(DataFormats.FileDrop);
            this.pictureBox1.Image = Image.FromFile(filenames[0]);
        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void CreateListViewColumns()
        {
            //Select
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from customers", conn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    DataTable table1 = dataReader.GetSchemaTable();

                    for (int i = 0; i <= table1.Rows.Count - 1; i++)
                    {
                        this.listView1.Columns.Add(table1.Rows[i][0].ToString());
                    }

                    this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    this.dataGridView1.DataSource = table1;


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void LoadCountryToComBox()
        {
            //Select
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select distinct country from Customers", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    this.comboBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        this.comboBox1.Items.Add(dataReader["Country"]);
                    }
                    this.comboBox1.SelectedIndex = 0;
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        //void Method(.......)
        //{

        //    //LoadData();
        //    //ShowData();
        //    //PrintData();
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            //Insert
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string UserName = this.textBox1.Text;
                    string Password = this.textBox2.Text;

                    //SqlCommand command = new SqlCommand("Insert into Member(UserName, Password) values ('" + UserName +"', '"+ Password + "')", conn);
                    SqlCommand command = new SqlCommand($"Insert into Member(UserName, Password) " +
                                                        $"values ('{UserName}', '{Password}')", conn);

                    command.ExecuteNonQuery();
                    MessageBox.Show("successfully");


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Select
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand($"select * from customers where country='{this.comboBox1.Text}'", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listView1.Items.Clear();

                    Random r = new Random();

                    while (dataReader.Read())
                    {

                        ListViewItem lvi = this.listView1.Items.Add(dataReader["CustomerID"].ToString());

                        lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);

                        if (lvi.Index % 2 == 0)
                        {
                            lvi.BackColor = Color.Orange;
                            lvi.ForeColor = Color.Black;
                        }
                        else
                        {
                            lvi.BackColor = Color.White;
                        }

                        for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                        {
                            if (dataReader.IsDBNull(i))
                            {
                                lvi.SubItems.Add("空值");
                            }
                            else
                            {
                                lvi.SubItems.Add(dataReader[i].ToString());
                            }

                        }

                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void llklkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
        }

        private void sdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.SmallIcon;
        }

        private void sdfToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Add("xxxx");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Select
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string UserName = this.textBox1.Text;
                    string Password = this.textBox2.Text;

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"Select * from Member where UserName='{UserName}' and Password ='{Password}'";
                    command.Connection = conn;

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("Logon successfully");
                    }
                    else
                    {
                        MessageBox.Show("Logon failed");
                    }

                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Insert
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {


                    string UserName = this.textBox1.Text;
                    string Password = this.textBox2.Text;

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into Member(UserName, Password) values (@UserName, @Password)";
                    command.Connection = conn;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = UserName;
                    //command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = Password;

                    //====================================
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@Password";
                    p1.SqlDbType = SqlDbType.NVarChar;
                    p1.Size = 40;
                    p1.Value = Password;
                    command.Parameters.Add(p1);
                    //===================================

                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("successfully");


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {


                    string UserName = this.textBox1.Text;
                    string Password = this.textBox2.Text;

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "InsertMember";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = UserName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = Password;

                    //===========================
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@Return_Value";
                    p1.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(p1);
                    //===========================

                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show($"successfully MemerID = {p1.Value}");


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {


                    string UserName = this.textBox1.Text;
                    string Password = FormsAuthentication.HashPasswordForStoringInConfigFile
                                          (this.textBox2.Text, System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "InsertMember";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conn;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = UserName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = Password;

                    //===========================
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@Return_Value";
                    p1.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(p1);
                    //===========================

                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show($"successfully MemerID = {p1.Value}");


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }

        }

        private void button30_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ComputeHash("abcd"));
        }

        //for FormsAuthentication.HashPasswordForStoringInConfigFile  過時 Solution
        public string ComputeHash(string value)
        {
            //MD5 algorithm = MD5.Create();
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string hashString = "";
            for (int i = 0; i < data.Length; i++)
            {
                hashString += data[i].ToString("x2").ToUpperInvariant();
            }
            return hashString; //"abcd" =>81FE8BFE87576C3ECB22426F8E57847382917ACF
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        string UserName = textBox1.Text;
                        string Password = textBox2.Text;

                        //=====================
                        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                        byte[] buf = new byte[15];
                        rng.GetBytes(buf); //要將在密碼編譯方面強式的隨機位元組填入的陣列。 
                        string salt = Convert.ToBase64String(buf);

                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password + salt, "sha1");
                        //======================

                        command.CommandText = "Insert into Member (UserName, Password, Salt) values (@UserName, @Password, @Salt)";
                        command.Connection = conn;

                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = UserName;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = Password;
                        command.Parameters.Add("@Salt", SqlDbType.NVarChar).Value = salt;

                        conn.Open();

                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.memberTableAdapter1.InsertMember("555", "555", "sdf");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1:app.config 寫好 連線字串  <add name=“LocalSqlServer”  ...預設可不寫
                //Step 2: create 好 DB  - ASPNET_REGSQL.exe工具建立的資料庫名稱, 預設名稱為aspnetdb

                //< connectionStrings >
                //     < clear />
                //     < add name = "LocalSqlServer"      connectionString = "Data Source=.;Initial Catalog=資料庫名稱;
                //                   Integrated Security = True; Connect Timeout = 30"  providerName="System.Data.SqlClient" />



                MembershipCreateStatus status;
                Membership.CreateUser("ccc", "@1234567", "fionwang@iii.org.tw", "color", "black", true, out status);
                MessageBox.Show(status.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Membership.ValidateUser("cccc", "@1234567").ToString());

        }
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {

                        command.Connection = conn;

                        conn.Open();

                        command.CommandText = "select Max (UnitPrice) from products";
                        this.listBox1.Items.Add($"MAX Unitprice = {command.ExecuteScalar():c2}");

                        command.CommandText = "select Min (UnitPrice) from products";
                        this.listBox1.Items.Add("MIN Unitprice =" + command.ExecuteScalar());

                        command.CommandText = "select Sum (UnitPrice) from products";
                        this.listBox1.Items.Add("Sum Unitprice =" + command.ExecuteScalar());

                        command.CommandText = "select Avg (UnitPrice) from products";
                        this.listBox1.Items.Add("Avg Unitprice =" + command.ExecuteScalar());

                        command.CommandText = "select Count (*) from products";
                        this.listBox1.Items.Add("Count =" + command.ExecuteScalar());

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Select
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("Select * from Categories; select * from products", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["CategoryName"]);
                    }
                    //==============================================
                    dataReader.NextResult();

                    while (dataReader.Read())
                    {
                        this.listBox2.Items.Add(dataReader["ProductName"]);
                    }


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Select
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from products", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["ProductName"]);
                    }

                    //====================================
                    //Exception "已經開啟一個與這個 Command 相關的 DataReader，必須先將它關閉。

                    command.CommandText = "select * from categories";
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["CategoryName"]);
                    }


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from products", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["ProductName"]);
                    }

                    //====================================

                    dataReader.Close();

                    command.CommandText = "select * from categories";
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        this.listBox2.Items.Add(dataReader["CategoryName"]);
                    }


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from products", conn);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            this.listBox1.Items.Add(dataReader["ProductName"]);
                        }
                    } //Auto dataReader.close(); =>dataReader.Dispose();

                    //====================================

                    command.CommandText = "select * from categories";
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            this.listBox2.Items.Add(dataReader["CategoryName"]);
                        }
                    }



                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string commandText =
            "CREATE TABLE[dbo].[MyImageTable]" +
            "(" +

   "[ImageID] INT NOT NULL PRIMARY KEY IDENTITY," +

   "[Description] NVARCHAR(50) NULL, " +
    "[Image] VARBINARY(MAX) NULL" +
")";

            //Insert
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {


                    SqlCommand command = new SqlCommand();
                    command.CommandText = commandText;
                    command.Connection = conn;

                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Image Table....");


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }

        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //Insert
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into MyImageTable(Description, Image) values (@Desc, @Image)";
                    command.Connection = conn;

                    //======================
                    byte[] bytes;//= { 1, 3 };
                
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bytes = ms.GetBuffer();

                    //=======================

                    command.Parameters.Add("@Desc", SqlDbType.NVarChar, 50).Value = this.textBox4.Text;
                    command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = bytes;

                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("successfully");


                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
 //Select
            try
            {
               
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from MyImageTable", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox3.Items.Clear();
                   // List<int> idLIst = new List<int>();
                    this.listBox4.Items.Clear();
                    while (dataReader.Read())
                    {
                        this.listBox3.Items.Add(dataReader["Description"]);
                        this.listBox4.Items.Add(dataReader["ImageID"]);
                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ImageID = (int)this.listBox4.Items[this.listBox3.SelectedIndex];
            ShowImage(ImageID);
        }

        private void ShowImage(int imageID)
        {
             //Select
            try
            {
               
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand($"select * from MyImageTable where ImageID={imageID}", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                       
                        //==================================
                        byte[] bytes = (byte[]) dataReader["Image"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                        this.pictureBox2.Image = Image.FromStream(ms);
                        //===================================
                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //Select
            try
            {

                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from MyImageTable", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    this.listBox5.Items.Clear();
                   
                    while (dataReader.Read())
                    {
                        MyImage x = new MyImage();
                        x.ImageID = (int) dataReader["ImageID"];
                        x.ImageDesc = dataReader["Description"].ToString(); 

                        this.listBox5.Items.Add(x);
                    }

                    //===
                    this.listBox5.Items.Add("1111111111111");

                 
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.listBox5.Items[this.listBox5.SelectedIndex]

            // int ImageID = ((MyImage)this.listBox5.SelectedItem).ImageID;

            //int n = int.Parse("123mlklk");
            //int.TryParse

            MyImage x = this.listBox5.SelectedItem as MyImage;
            if (x != null)
            {
                int ImageID = x.ImageID;
                ShowImage(ImageID);
            }
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }
    }

    class MyImage : Object
    {
        internal int ImageID;
        internal string ImageDesc;

        public override string ToString()
        {
            return $"{this.ImageID} - {this.ImageDesc}";
        }
    }
}
