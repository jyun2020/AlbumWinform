using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW1
{
    public partial class frm1 : Form
    {
        public frm1()
        {
            InitializeComponent();
        }
        List<string> NameList = new List<string>() { "MARINA", "JUSTIN", "NICHOLAS", "Cathrine", "JORDYN", "JUNE", "MOLLY", "ALEXIS", "WILLIAM", "Janeslie" };
        List<int> ScoreList = new List<int>() { 60, 62, 65, 69, 80, 99, 70, 71, 85, 66, 20, 0, 87, 98, };

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string item in NameList)
            {
                listBox1.Items.Add(item);
            }
            foreach (int item in ScoreList)
            {
                listBox2.Items.Add(item);
            }
        }

        private void btnFor_Click(object sender, EventArgs e)
        {
                if (Int32.TryParse(Begin.Text, out int begin) && Int32.TryParse(End.Text, out int end) && Int32.TryParse(Step.Text, out int step))
                {
                    if (begin > end)
                    {
                        if (step < 0)
                        {
                            int SumNumber = 0;
                            for (int i = begin; i >= end; i += step)
                            {
                                SumNumber += i;
                            }
                            MessageBox.Show("總合為:" + SumNumber);
                        }
                        else
                        {
                            MessageBox.Show("您的等差值有問題");
                        }
                    }
                    else if (end > begin)
                    {
                        if (step > 0)
                        {
                            int SumNumber = 0;
                            for (int i = begin; i <= end; i += step)
                            {
                                SumNumber += i;
                            }
                            MessageBox.Show("總合為:" + SumNumber);
                        }
                        else
                        {
                            MessageBox.Show("您的等差值有問題");
                        }
                    }
                    else if (begin == end)
                    {
                        MessageBox.Show("您輸入的數值有問題");
                    }
                    else
                    {
                        MessageBox.Show("您的等差值有問題");
                    }
                }
                else
                {
                    MessageBox.Show("請輸入整數");
                }
            }
        private void btnWhile_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(Begin.Text, out int begin) && Int32.TryParse(End.Text, out int end) && Int32.TryParse(Step.Text, out int step))
            {
                if (begin > end)
                {
                    if (step < 0)
                    {
                        int SumNumber = 0;
                        while (begin >= end)
                        {
                            SumNumber += begin;
                            begin += step;
                        }
                        MessageBox.Show("總合為:" + SumNumber);
                    }
                    else
                    {
                        MessageBox.Show("您的等差值有問題");
                    }
                }
                else if (end > begin)
                {
                    if (step > 0)
                    {
                        int SumNumber = 0;
                        int i = begin;
                        while (i <= end)
                        {
                            SumNumber += i;
                            i += step;
                        }
                        MessageBox.Show("總合為:" + SumNumber);
                    }
                    else
                    {
                        MessageBox.Show("您的等差值有問題");
                    }
                }
                else if (begin == end)
                {
                    MessageBox.Show("請輸入正確的數值");
                }
            }
            else
            {
                MessageBox.Show("請輸入整數");
            }
        }
        private void btnDoWhile_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(Begin.Text, out int begin) && Int32.TryParse(End.Text, out int end) && Int32.TryParse(Step.Text, out int step))
            {
                if (begin > end)
                {
                    if (step < 0)
                    {
                        int SumNumber = 0;
                        do
                        {
                            SumNumber += begin;
                            begin += step;
                        } while (begin >= end);
                        MessageBox.Show("總合為:" + SumNumber);
                    }
                    else
                    {
                        MessageBox.Show("您的等差值有問題");
                    }
                }
                else if (end > begin)
                {
                    if (step > 0)
                    {
                        int SumNumber = 0;
                        do
                        {
                            SumNumber += begin;
                            begin += step;
                        } while (begin <= end);
                        MessageBox.Show("總合為:" + SumNumber);
                    }
                    else
                    {
                        MessageBox.Show("您的等差值有問題");
                    }
                }
                else if (begin == end)
                {
                    MessageBox.Show("您輸入的數值有問題");
                }
                else
                {
                    MessageBox.Show("您的等差值有問題");
                }
            }
            else
            {
                MessageBox.Show("請輸入整數");
            }
            }
        
        private void btnAddName_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(AddName.Text, @"^[A-Za-z]+$");
            if (match.Success)
            {
                NameList.Add(AddName.Text);
                listBox1.Items.Add(AddName.Text);
                MessageBox.Show("加入成功");
            }
            else
            {
                MessageBox.Show("請輸入英文名字");
            }
            AddName.Text = "";
        }
        private void btnAddint_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(Addint.Text, @".*[0-9].*");
            if (match.Success)
            {
                if (Convert.ToInt32(Addint.Text) <= 100)
                {
                    ScoreList.Add(Convert.ToInt32(Addint.Text));
                    listBox2.Items.Add(Convert.ToInt32(Addint.Text));
                    MessageBox.Show("加入成功");
                    Addint.Text = "";
                }
                else
                {
                    MessageBox.Show("請輸入小於100的數");
                }
            }
            else
            {
                MessageBox.Show("請輸入整數");
            }
            Addint.Text = "";
        }
        private void btnFindName_Click(object sender, EventArgs e)
        {
            string ans = "";
            int maxlength = NameList[0].Length;
            for (int i = 1; i < NameList.Count; i++)
            {
                if (NameList[i].Length >= maxlength)
                {
                    maxlength = NameList[i].Length;
                }
            }
            for (int i = 0; i < NameList.Count; i++)
            {
                if (NameList[i].Length == maxlength)
                {
                    ans += NameList[i] + "\r\n";
                }
            }
            ans.Remove(ans.Length - 1);
            MessageBox.Show("名字最長為" + maxlength + "個字\r\n\r\n" + "名單為:\r\n" + ans);
        }
        private void btnContains_Click(object sender, EventArgs e)
        {
            string ans = "";
            string temp;
            int count = 0;
            for (int i = 0; i < NameList.Count; i++)
            {
                temp = NameList[i];
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] == 'C' || temp[j] == 'c')
                    {
                        ans += temp + "\r\n";
                        count += 1;
                        break;
                    }
                }
            }
            MessageBox.Show("名字包含c或C的有" + count + "位\r\n\r\n" + "名單為:\r\n" + ans);
        }
        private void btnOdd_Click(object sender, EventArgs e)
        {
            string ans = "";
            int Odd = 1;
            for (int i = 0; i < ScoreList.Count; i++)
            {
                if (ScoreList[i] % 2 != 0)
                {
                    ans += ScoreList[i].ToString() + "\r\n";
                    Odd += 1;
                }
            }
            MessageBox.Show("此名單的奇數有" + Odd + "個\r\n" + "名單為\r\n" + ans);
        }
        private void btnEven_Click(object sender, EventArgs e)
        {
            string ans = "";
            int Even = 1;
            for (int i = 0; i < ScoreList.Count; i++)
            {
                if (ScoreList[i] % 2 == 0)
                {
                    ans += ScoreList[i].ToString() + "\r\n";
                    Even += 1;
                }
            }
            MessageBox.Show("此名單的偶數有" + Even + "個\r\n" + "名單為\r\n" + ans);
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            int max = ScoreList[0];
            for (int i = 0; i < ScoreList.Count; i++)
            {
                if (ScoreList[i] >= max)
                {
                    max = ScoreList[i];
                }
            }
            MessageBox.Show("最高分為" + max);
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            int min = ScoreList[0];
            for (int i = 0; i < ScoreList.Count; i++)
            {
                if (ScoreList[i] <= min)
                {
                    min = ScoreList[i];
                }
            }
            MessageBox.Show("最低分為" + min);
        }
    }
}