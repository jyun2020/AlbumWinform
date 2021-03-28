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
using WindowsFormsApp1.Properties;
using System.Threading;

namespace Starter

{
    public partial class FrmSqlConnection : Form
    {
        public FrmSqlConnection()
        {
            InitializeComponent();

            this.BackColor = Settings.Default.MyBackColor;

            this.tabControl1.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True";

                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                MessageBox.Show("successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message );
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = "Data Source=.;Initial Catalog=Northwind;User ID=sa; Password=sa";

                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                MessageBox.Show("successfully");
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
                string  connString = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.NorthwindConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from products", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["ProductName"]);
                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            try
            {
                //加密

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection section = config.Sections["connectionStrings"];
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                config.Save();
                MessageBox.Show("加密成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            try
            {
                //解密
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection section = config.Sections["connectionStrings"];
                section.SectionInformation.UnprotectSection();
                config.Save();

                MessageBox.Show("解密成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //set
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.MyBackColor = this.colorDialog1.Color;
                 Settings.Default.Save();

                this.BackColor = this.colorDialog1.Color;
            }
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            this.BackColor = Settings.Default.MyBackColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
         //Read
            try
            {
               string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Desktop\新增資料夾\Database1.mdf; Integrated Security = True";
          
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from MyMember", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["UserName"]);
                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Read
            try
            {
                //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Database1.mdf; Integrated Security = True";
                string connString = Settings.Default.MyLocalDB;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from MyMember", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["UserName"]);
                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Read
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
                builder.AttachDBFilename = Application.StartupPath + @"\Database1.mdf";
                builder.IntegratedSecurity = true;

                string connString = builder.ConnectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from MyMember", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["UserName"]);
                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(this.productsTableAdapter1.Connection.ConnectionString);
            this.productsTableAdapter1.Connection.StateChange += Connection_StateChange;
          
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products); //Auto ...open()..........close()
            this.dataGridView1.DataSource = this.nwDataSet1.Products;

        }

        private void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
            //this.statusStrip1.Items[0]. Text=  e.CurrentState.ToString();
            this.toolStripStatusLabel1.Text = e.CurrentState.ToString();

            Application.DoEvents();
            Thread.Sleep(600);
        }
     
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = Settings.Default.NorthwindConnectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                { 
                    conn.StateChange += Connection_StateChange;
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from products", conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        this.listBox1.Items.Add(dataReader["ProductName"]);
                    }
                } //Auto call  conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //int[] nums =new int[100];
            //System.InvalidOperationException: '已超過連接逾時的設定。在取得集區連接之前超過逾時等待的時間，可能的原因為所有的共用連接已在使用中，並已達共用集區大小的最大值。'
           
            
            
            SqlConnection[] conns = new SqlConnection[100];
            SqlDataReader[] readers = new SqlDataReader[100];

            for (int i=0; i<=conns.Length-1; i++)
            {
                conns[i] = new SqlConnection(Settings.Default.NorthwindConnectionString);

                conns[i].Open();

                this.label3.Text = $"{i+1}"; //(i + 1).ToString(); 

                Application.DoEvents();
                Thread.Sleep(10);

                //==================================================================
                SqlCommand command = new SqlCommand("select * from products", conns[i]);
               readers[i] =  command.ExecuteReader();

                while (readers[i].Read())
                {
                    this.listBox3.Items.Add(readers[i]["ProductName"]);
                }

            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            const int MAX = 200;
            
            this.label3.BorderStyle = BorderStyle.Fixed3D;

            SqlConnection[] conns = new SqlConnection[MAX];
            SqlDataReader[] readers = new SqlDataReader[MAX];

            //===========================
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "AdventureWorks";
            builder.IntegratedSecurity = true;

            builder.MaxPoolSize = MAX;
            builder.ConnectTimeout = 1;
            //=============================

            for (int i = 0; i <= conns.Length - 1; i++)
            {
                conns[i] = new SqlConnection(builder.ConnectionString);

                conns[i].Open();

                this.label3.Text = $"{i + 1}"; //(i + 1).ToString(); 

                Application.DoEvents();
                Thread.Sleep(10);

                //==================================================================
                SqlCommand command = new SqlCommand("select * from  Production.Product", conns[i]);
                readers[i] = command.ExecuteReader();

                while (readers[i].Read())
                {
                    this.listBox3.Items.Add(readers[i]["Name"]);
                }

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            const int MAX = 100;

            this.label3.BorderStyle = BorderStyle.Fixed3D;

            SqlConnection[] conns = new SqlConnection[MAX];
            SqlDataReader[] readers = new SqlDataReader[MAX];

            //===========================
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "AdventureWorks";
            builder.IntegratedSecurity = true;

            builder.Pooling = true;
            builder.MaxPoolSize = MAX;
            builder.ConnectTimeout = 1;
            //=============================

            //DateTime T1 = DateTime.Now;

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            for (int i = 0; i <= conns.Length - 1; i++)
            {
                conns[i] = new SqlConnection(builder.ConnectionString);

                conns[i].Open();

                this.label3.Text = $"{i + 1}"; //(i + 1).ToString(); 

                //Application.DoEvents();
                //Thread.Sleep(10);

                //==================================================================
                SqlCommand command = new SqlCommand("select * from  Production.Product", conns[i]);
                readers[i] = command.ExecuteReader();

                while (readers[i].Read())
                {
                    this.listBox3.Items.Add(readers[i]["Name"]);
                }

                //Pooling = True
                //conn Return to POOL
                conns[i].Close();

            }

            watch.Stop();
            this.label1.Text = $"{watch.Elapsed.TotalSeconds} 秒";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            const int MAX = 100;

            this.label3.BorderStyle = BorderStyle.Fixed3D;

            SqlConnection[] conns = new SqlConnection[MAX];
            SqlDataReader[] readers = new SqlDataReader[MAX];

            //===========================
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "AdventureWorks";
            builder.IntegratedSecurity = true;

            builder.Pooling = false;
            builder.MaxPoolSize = MAX;
            builder.ConnectTimeout = 1;
            //=============================

            //DateTime T1 = DateTime.Now;

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            for (int i = 0; i <= conns.Length - 1; i++)
            {
                conns[i] = new SqlConnection(builder.ConnectionString);

                conns[i].Open();

                this.label3.Text = $"{i + 1}"; //(i + 1).ToString(); 

                //Application.DoEvents();
                //Thread.Sleep(10);

                //==================================================================
                SqlCommand command = new SqlCommand("select * from  Production.Product", conns[i]);
                readers[i] = command.ExecuteReader();

                while (readers[i].Read())
                {
                    this.listBox3.Items.Add(readers[i]["Name"]);
                }

                //Pooling =  false
                //conn NOT Return to POOL
                conns[i].Close();

            }

            watch.Stop();
            this.label2.Text = $"{watch.Elapsed.TotalSeconds} 秒";
        }

        #region Demo
        private void button23_Click(object sender, EventArgs e)
        {

            SqlConnection conn = null;


            try

            {
                string connString = "Data Source=.;Initial Catalog=Northwindxxx;Integrated Security=True";

                conn = new SqlConnection(connString);

                SqlCommand command = new SqlCommand("Select * from Products", conn);
                SqlDataReader dr = null;
                conn.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Add(dr["ProductName"]);
                }

                this.comboBox2.SelectedIndex = 0;
            }


            catch (SqlException ex)
            {
                //ex.Number
                string s = "";
                for (int i = 0; i <= ex.Errors.Count - 1; i++)
                {
                    //$"{}{}"
                    s += string.Format("{0} : {1}\n", ex.Errors[i].Number, ex.Errors[i].Message) ;
                }
                MessageBox.Show("error count:" + ex.Errors.Count + Environment.NewLine + s);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=.;Initial Catalog=Northwindxx;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);

            SqlCommand command = new SqlCommand("Select * from Products", conn);
            SqlDataReader dr = null;

            try
            {
                conn.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Add(dr["ProductName"]);
                }

                this.comboBox2.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 17:
                        MessageBox.Show("Wrong Server");
                        break;
                    case 4060:
                        MessageBox.Show("Wrong DataBase");
                        break;
                    case 18456:
                        MessageBox.Show("Wrong User");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {


                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        #endregion
    }
}
