using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmWarmUp : Form
    {
        public FrmWarmUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hello
            MessageBox.Show("Hello, " + textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hi
            MessageBox.Show("Hi, " + textBox1.Text);
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 999;

            Form2 f= new Form2();
            f.Show();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            FrmWarmUp f = new FrmWarmUp();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0120 需要有物件參考，才可使用非靜態欄位、方法或屬性 'Form.Text'。	WindowsFormsApp1 C:\Shared\ADO.NET\WindowsFormsApp1\WindowsFormsApp1\Form1.cs    52  作用中
            //Form1.Text = "Hello, " + textBox1.Text;

            FrmWarmUp f = new FrmWarmUp();
            f.Text = "Hello, " + textBox1.Text;
            f.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //static 靜態
            MessageBox.Show( SystemInformation.ComputerName);

            //嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0200 無法指派為屬性或索引子 'SystemInformation.ComputerName'-- 其為唯讀 WindowsFormsApp1    C:\Shared\ADO.NET\WindowsFormsApp1\WindowsFormsApp1\Form1.cs    60  作用中
            //SystemInformation.ComputerName = "xzxz";

            //instance 非靜態
            btnHello.Text = "xxxx";
            button2.Text = "yyyy";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Text = "Hello " + this.textBox1.Text;

           // Text = "Hello " + textBox1.Text;
        }
    }
}
