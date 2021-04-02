using System;
using System.Windows.Forms;
using HomeWork.exam;
using HomeWork.HW1;
using HomeWork.HW2;
using HomeWork.HW3;
using HomeWork.HW4;
using HomeWork.HW5;
using HomeWork.HW6;
using HomeWork.HW7;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1 f = new frm1();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm2 f = new frm2();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm3 f = new frm3();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm4 f = new frm4();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm5 f = new frm5(" ");
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm6 f = new frm6();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm7 f = new frm7();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmExam f = new frmExam();
            f.Show();
        }
    }
}
