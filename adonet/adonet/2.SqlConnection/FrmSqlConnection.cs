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
using System.Configuration;
using adonet.Properties;
using System.Threading;

namespace Starter

{
    public partial class FrmSqlConnection : Form
    {
        public FrmSqlConnection()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 2;
        }
        //Windows 驗證
        private void button1_Click(object sender, EventArgs e)
        {
            string ConnString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(ConnString);
                conn.Open();
                MessageBox.Show("success");
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }
        //SQL Server 驗證
        private void button2_Click(object sender, EventArgs e)
        {
            string ConnString = "Data Source=.;" +
                "Initial Catalog=Northwind;" +
                "User Id = sa;" +
                "Password = 123;" +
                "Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(ConnString);
                conn.Open();
                MessageBox.Show("success");
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }
        //.Config  組態黨 - Class Settings
        private void button3_Click(object sender, EventArgs e)
        {
            Settings.Default.MyBackColor = Color.Red; //範圍設定使用者可get set
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.MyBackColor = this.colorDialog1.Color;
            }
            this.BackColor = Settings.Default.MyBackColor;
            
            string Connstring = Settings.Default.MyConnectionString;
            //應用程式>設定 系統會new一個settings的物件,裡面存放值和屬性,新增後也會加到組態檔
            try
            {
                using (SqlConnection conn = new SqlConnection(Connstring))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Products", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["ProductName"]);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Connstring = ConfigurationManager.ConnectionStrings["adonet.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(Connstring))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Products", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["ProductName"]);
                    }            
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            string Connstring = ConfigurationManager.ConnectionStrings["adonet.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(Connstring))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Products", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["ProductName"]);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ConnString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = F:\adonet\adonet\adonet\Database1.mdf; Integrated Security = True";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM MyMembers", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["UserName"]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string ConnString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Database1.mdf; Integrated Security = True";//相對路徑 |DataDirectory|
            string ConnString = Settings.Default.MyLocalDB; //組態檔
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM MyMembers", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["UserName"]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.AttachDBFilename = Application.StartupPath+@"\Database1.mdf";
            builder.IntegratedSecurity = true;
            string ConnString = builder.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM MyMembers", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["UserName"]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Connection.StateChange += Connection_StateChange;
            this.productsTableAdapter1.Fill(this.northwindDataset1.Products);
            dataGridView1.DataSource = this.northwindDataset1.Products;
        }

        private void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
            this.toolStripStatusLabel1.Text = e.CurrentState.ToString();
            Application.DoEvents();
            Thread.Sleep(500);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string Connstring = Settings.Default.MyConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(Connstring))
                {
                    conn.StateChange += Connection_StateChange;
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Products", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader["ProductName"]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            const int Max = 100;
            //預設連接池最大上限為100
            SqlConnection[] conns = new SqlConnection[Max];
            SqlDataReader[] readers = new SqlDataReader[Max];
            for (int i = 0; i < conns.Length; i++)
            {
                conns[i] = new SqlConnection(Settings.Default.NorthwindConnectionString);
                conns[i].Open();
                label3.Text = (i+1).ToString();
                Application.DoEvents();//做完所有事情

                SqlCommand command = new SqlCommand("SELECT * FROM Products",conns[i]);
                readers[i] = command.ExecuteReader();
                while (readers[i].Read())
                {
                    listBox3.Items.Add(readers[i]["ProductName"]);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            const int Max = 200;
            //預設連接池最大上限為100
            SqlConnection[] conns = new SqlConnection[Max];
            SqlDataReader[] readers = new SqlDataReader[Max];
            for (int i = 0; i < conns.Length; i++)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = ".";
                builder.InitialCatalog = "AdventureWorks";
                builder.IntegratedSecurity = true;
                builder.MaxPoolSize = Max;
                builder.ConnectTimeout = 1;

                conns[i] = new SqlConnection(builder.ConnectionString);
                
                label3.Text = (i + 1).ToString();
                
                Application.DoEvents();//做完所有事情

                conns[i].Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Production].[Product]", conns[i]);
                readers[i] = command.ExecuteReader();
                while (readers[i].Read())
                {
                    listBox3.Items.Add(readers[i]["Name"]);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            const int Max = 100;
            //預設連接池最大上限為100
            SqlConnection[] conns = new SqlConnection[Max];
            SqlDataReader[] readers = new SqlDataReader[Max];
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "AdventureWorks";
            builder.IntegratedSecurity = true;
            builder.Pooling = true;
            builder.MaxPoolSize = Max;
            builder.ConnectTimeout = 1;

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for (int i = 0; i < conns.Length; i++)
            {
                conns[i] = new SqlConnection(builder.ConnectionString);
                label3.Text = (i + 1).ToString();
                conns[i].Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Production].[Product]", conns[i]);
                readers[i] = command.ExecuteReader();
                while (readers[i].Read())
                {
                    listBox3.Items.Add(readers[i]["Name"]);
                }
                conns[i].Close();
            }
            watch.Stop();
            label1.Text = watch.Elapsed.TotalSeconds+"秒";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            const int Max = 100;
            //預設連接池最大上限為100
            SqlConnection[] conns = new SqlConnection[Max];
            SqlDataReader[] readers = new SqlDataReader[Max];
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "AdventureWorks";
            builder.IntegratedSecurity = true;
            builder.Pooling = false;
            builder.MaxPoolSize = Max;
            builder.ConnectTimeout = 1;

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for (int i = 0; i < conns.Length; i++)
            {
                conns[i] = new SqlConnection(builder.ConnectionString);
                label3.Text = (i + 1).ToString();
                conns[i].Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Production].[Product]", conns[i]);
                readers[i] = command.ExecuteReader();
                while (readers[i].Read())
                {
                    listBox3.Items.Add(readers[i]["Name"]);
                }
                conns[i].Close();
            }
            watch.Stop();
            label2.Text = watch.Elapsed.TotalSeconds + "秒";
        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }
    }
    }
