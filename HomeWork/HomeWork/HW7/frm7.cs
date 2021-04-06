﻿using HomeWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace HomeWork.HW7
{
    public partial class frm7 : Form
    {
        public frm7()
        {
            InitializeComponent();
            cb_DBchange.SelectedIndex = 0;
        }
        string ConnString = "";

        private void cb_DBchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DBchange.SelectedIndex == 0)
            {
                ConnString = Settings.Default.LocalMyAlbumConnectionString;
            }
            else
            {
                ConnString = Settings.Default.MyAlbumConnectionString;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text;
            string password = textBox2.Text;
            for (int i = 0; i < 100; i++)
            {
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA256");
            } //跑100次雜湊
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM member WHERE Account = @Account AND Password = @Password",conn);
                    command.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if ((bool)reader["approve"] == true)
                        {
                            frm_LoginSuccess frmLoginSuccess = new frm_LoginSuccess(account);
                            frmLoginSuccess.Show();
                            this.Close(); //跳轉頁面
                        }
                        else
                        {
                            frm_EmailApprove frm_EmailApprove = new frm_EmailApprove(ConnString,account,reader["email"].ToString(),reader["email_id"].ToString());
                            frm_EmailApprove.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        label4.Visible = true;
                        Random ran = new Random((int)DateTime.Now.Ticks);
                        Point point = this.Location;
                        for (int i = 0; i <5; i++)
                        {
                            this.Location = new Point(point.X + ran.Next(8) - 4, point.Y + ran.Next(8) - 4);
                            System.Threading.Thread.Sleep(5);
                            this.Location = point;
                            System.Threading.Thread.Sleep(5);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Registered_Click(object sender, EventArgs e)
        {
            frm_registered frmRegistered = new frm_registered(ConnString);
            frmRegistered.Show();
            this.Close();
        }
    }
}
