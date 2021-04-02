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

namespace HomeWork.exam
{
    public partial class frmExam : Form
    {
        public frmExam()
        {
            InitializeComponent();
            AddListViewColumns();
            AddTreeViewNode();
        }
        string connstring = Settings.Default.NorthwindConnectionString;
        List<TreeNode> nodes = new List<TreeNode>();
        List<TreeNode> nodes2 = new List<TreeNode>();
        List<string> nodesName = new List<string>();
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode TN = e.Node;
            FillDataGridView(TN);
        }
        private void AddTreeViewNode()
        {
            try
            {
                //加入第一層
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    SqlCommand command = new SqlCommand("SELECT DISTINCT Country FROM Customers", conn);
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TreeNode node = treeView1.Nodes.Add(dataReader["Country"].ToString());
                        node.Name = dataReader["Country"].ToString();
                        nodes.Add(node);
                        nodesName.Add(node.Name);
                    }
                }
                //加入第二層
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    SqlCommand command = new SqlCommand("SELECT CustomerID  FROM Customers WHERE Country = @Country", conn);
                    foreach (TreeNode TN in nodes)
                    {
                        command.Parameters.Add("@Country", SqlDbType.NVarChar, 15).Value = TN.Name;
                        conn.Open();
                        SqlDataReader dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            TreeNode TN2 = TN.Nodes.Add(dataReader["CustomerID"].ToString());
                            TN2.Name = dataReader["CustomerID"].ToString();
                            nodes2.Add(TN2);
                        }
                        command.Parameters.Clear();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillDataGridView(TreeNode TN)
        {
            string commandString = "";
            if (nodesName.Contains(TN.Name))
            {
                try
                {
                    commandString = "SELECT *  FROM Customers WHERE Country = @Country";
                    using (SqlConnection conn = new SqlConnection(connstring))
                    {
                        SqlCommand command = new SqlCommand(commandString, conn);
                        command.Parameters.Add("@Country", SqlDbType.NVarChar, 15).Value = TN.Name;
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    commandString = "SELECT *  FROM Customers WHERE CustomerID = @CustomerID";
                    using (SqlConnection conn = new SqlConnection(connstring))
                    {
                        SqlCommand command = new SqlCommand(commandString, conn);
                        command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5).Value = TN.Name;
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        dataGridView1.DataSource = bindingSource1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void AddListViewColumns()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Customers", conn);
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    DataTable dataTable = dataReader.GetSchemaTable();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        listView1.Columns.Add(dataTable.Rows[i][0].ToString());
                    }
                    //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);//自動調整欄位寬度
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
