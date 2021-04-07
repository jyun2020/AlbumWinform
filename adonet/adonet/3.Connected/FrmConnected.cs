using adonet.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmConnected : Form
    {
        public FrmConnected()
        {
            InitializeComponent();
            LoadCountry();
            CreatListViewColums();
            this.tabControl1.SelectedIndex = 3;
            this.tabControl2.SelectedIndex = 2;
            pictureBox1.AllowDrop = true;
            pictureBox1.DragDrop += PictureBox1_DragDrop;
            pictureBox1.DragEnter += PictureBox1_DragEnter;
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
        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            //拉到目標上的事件
            e.Effect = DragDropEffects.Copy;//預設為None,先解開
        }
        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] x = (string[])e.Data.GetData(DataFormats.FileDrop);//丟進來的檔案,取得路徑
            this.pictureBox1.Image = Image.FromFile(x[0]);//FormFile(路徑)
        }
        string connstring = Settings.Default.NorthwindConnectionString;
        private void LoadCountry()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT DISTINCT Country  FROM Customers ", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    comboBox1.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["Country"]);
                    }
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void CreatListViewColums()
        {
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.listView1.View = View.Details;
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT *  FROM Customers ", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = reader.GetSchemaTable();
                    dataGridView1.DataSource = dataTable;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        listView1.Columns.Add(dataTable.Rows[i]["ColumnName"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Random r = new Random();
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT *  FROM Customers WHERE Country = '{comboBox1.SelectedItem.ToString()}'", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem viewItem = listView1.Items.Add(reader["CustomerID"].ToString());//第一個欄位資料都設成item,並先用變數接住
                        viewItem.ImageIndex = r.Next(0, this.ImageList2.Images.Count);//每個viewitem都加入圖片
                        if (viewItem.Index % 2 == 0)
                        {
                            viewItem.BackColor = Color.White;
                        }
                        else
                        {
                            viewItem.BackColor = Color.LightPink;
                        }
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            if (reader[i].ToString() == "")
                            {
                                viewItem.SubItems.Add("空值");//之後的欄位用Subitems列出
                            }
                            else
                            {
                                viewItem.SubItems.Add(reader[i].ToString());//之後的欄位用Subitems列出
                            }
                        }
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
        }
        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.SmallIcon;
        }
        private void detialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
        }
        //===================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string insert = $"INSERT INTO member(UserName,Password) VALUES('{textBox1.Text}','{textBox2.Text}')";
                    string insert2 = $"INSERT INTO member(UserName,Password) VALUES('{textBox1.Text}','{textBox2.Text}')";
                    SqlCommand command = new SqlCommand(insert, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("新增成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT * FROM member WHERE UserName = '{textBox1.Text}'AND Password='{textBox2.Text}'";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("Login Success");
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO member(UserName,Password) VALUES(@Username,@Password)";
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                    command.Connection = conn;
                    int a = command.ExecuteNonQuery();
                    MessageBox.Show("新增成功" + a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM member WHERE UserName=@UserName AND Password=@Password";
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("Login Success");
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
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
                    conn.Open();
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "InsertMember";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                    //=======================================
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@Return_Value";
                    p1.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(p1);
                    //=======================================
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    MessageBox.Show("新增成功,MemberID=" + p1.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "LoginMember";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("Login Success");
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
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
                    conn.Open();
                    string username = textBox1.Text;
                    string password = FormsAuthentication.HashPasswordForStoringInConfigFile(textBox2.Text, "SHA256");
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "InsertMember";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                    //=======================================
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@Return_Value";
                    p1.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(p1);
                    //=======================================
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    MessageBox.Show("新增成功,MemberID=" + p1.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    conn.Open();
                    command.CommandText = "SELECT COUNT (*) FROM Products";
                    listBox1.Items.Add($"Count = {command.ExecuteScalar()}");

                    command.CommandText = "SELECT MAX (Unitprice) FROM Products";
                    listBox1.Items.Add($"MAX = {command.ExecuteScalar():C2}");

                    command.CommandText = "SELECT MIN (Unitprice) FROM Products";
                    listBox1.Items.Add($"MIN = {command.ExecuteScalar():C2}");

                    command.CommandText = "SELECT Avg (Unitprice) FROM Products";
                    listBox1.Items.Add($"Average = {command.ExecuteScalar():C2}");

                    command.CommandText = "SELECT Avg (Unitprice) FROM Products";
                    listBox1.Items.Add($"Average = {command.ExecuteScalar():C2}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "SELECT CategoryName FROM Categories ; Select ProductName FROM Products";
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0]);
                    }
                    //===============================================
                    reader.NextResult(); //執行下一個查詢字串
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "SELECT CategoryName FROM Categories";
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0]);
                    }
                    //===============================================
                    reader.Close();//同一個連線只能有一個datareader,所以要先關掉
                    command.CommandText = "Select ProductName FROM Products";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "SELECT CategoryName FROM Categories";
                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())//使用using自動關閉reader
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader[0]);
                        }
                    }
                    //===============================================
                    command.CommandText = "Select ProductName FROM Products";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //===================================================================
        private void button24_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO MyImageTable(description,Image) VALUES(@Description,@Image)";

                    MemoryStream ms = new MemoryStream();//建立一個資料流物件
                    pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存成jpeg格式到ms
                    byte[] bytes = ms.GetBuffer();//將資料流轉換成byte[]陣列

                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = textBox4.Text;
                    command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = bytes;

                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Login Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM MyImageTable ";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox3.Items.Add(reader["description"]);
                        listBox4.Items.Add(reader["ImageId"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string a = listBox3.Text;
            //try
            //{
            //    string connString = Settings.Default.NorthwindConnectionString;
            //    using (SqlConnection conn = new SqlConnection(connString))
            //    {
            //        SqlCommand command = new SqlCommand();
            //        command.CommandText = $"SELECT ImageId FROM MyImageTable WHERE description = {a}";
            //        command.Connection = conn;
            //        conn.Open();
            //        SqlDataReader reader = command.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            reader.Read();
            //            string  imageid = reader["ImageId"].ToString();
            //            LoadImage(Convert.ToInt32(imageid));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed " + ex.Message);
            //}
            int imageid = (int)this.listBox4.Items[this.listBox3.SelectedIndex];
            LoadImage(imageid);
        }
        private void LoadImage(int Imageid)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT Image FROM MyImageTable  WHERE ImageId = {Imageid}";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        byte[] bytes = (byte[])reader["Image"];
                        MemoryStream ms = new MemoryStream(bytes);
                        this.pictureBox2.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT * FROM MyImageTable";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    listBox5.Items.Clear();
                    while (reader.Read())
                    {
                        MyImage x = new MyImage((int)reader["ImageId"], reader["description"].ToString());
                        this.listBox5.Items.Add(x);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int imageid = ((MyImage)listBox5.SelectedItem).ImageId;
            //LoadImage(imageid);
            MyImage x = this.listBox5.SelectedItem as MyImage;
            if (x != null)
            {
                int ImageID = x.ImageId;
                LoadImage(ImageID);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;

                    command.CommandText = "INSERT INTO Region(RegionID,RegionDescription)VALUES(100,'100')";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Region(RegionID,RegionDescription)VALUES(101,'101')";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SqlTransaction txn = null;
            string connString = Settings.Default.NorthwindConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                txn = conn.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Transaction = txn;
                command.Connection = conn;

                command.CommandText = "INSERT INTO Region(RegionID,RegionDescription)VALUES(100,'100')";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Region(RegionID,RegionDescription)VALUES(100,'100')";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Region(RegionID,RegionDescription)VALUES(101,'101')";
                command.ExecuteNonQuery();
                txn.Commit();
            }
            catch (Exception ex)
            {
                txn.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        class MyImage : Object
        {
            public int ImageId;
            public string Description;
            public MyImage(int ImageId, string Description)
            {
                this.ImageId = ImageId;
                this.Description = Description;
            }
            public override string ToString()
            {
                return $"{this.ImageId}----{this.Description}";
            }
        }
    }
}

