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
        string connstring = Settings.Default.NorthwindConnectionString;
        List<TreeNode> nodes = new List<TreeNode>();
        List<TreeNode> nodes2 = new List<TreeNode>();
        List<string> nodesName = new List<string>();

        public frmExam()
        {
            InitializeComponent();
            AddTreeViewNode();
            LoadColumns();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode TN = e.Node;
            FillDataGridView(TN);
            LoadListViewData(TN);
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
                        DataSet dataSet = new DataSet();
                        dataSet.Tables.Add(dataTable);
                        bindingSource1.DataSource = dataSet.Tables[0];
                        bindingNavigator1.BindingSource = bindingSource1;
                        dataGridView1.DataSource = bindingSource1;
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
        private void LoadColumns()
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
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);//自動調整欄位寬度
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void LoadListViewData(TreeNode TN)
        {
            this.listView1.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    SqlCommand command = new SqlCommand($"SELECT * FROM Customers WHERE Country = '{TN.Name}'", conn);
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ListViewItem lvi = this.listView1.Items.Add(dataReader["CustomerID"].ToString());
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
