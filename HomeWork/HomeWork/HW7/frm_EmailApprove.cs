using HomeWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW7
{
    public partial class frm_EmailApprove : Form
    {
        string connstring = Settings.Default.MyAlbumConnectionString;
        string email = "";
        string email_id = "";
        string account = "";
        public frm_EmailApprove(string account,string email , string email_id)
        {
            InitializeComponent();
            this.email = email;
            this.email_id = email_id;
            this.account = account;
        }

        private void LoadUserEmail()
        { 
            
        }

        private void btn_SendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage("jyun1091201@gmail.com", email);
                mm.Subject = "洪秉鈞的登入系統實作,email認證信";
                mm.Body = "認證碼 : " + email_id;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                NetworkCredential networkCredential = new NetworkCredential("jyun1091201@gmail.com", "j3465197");
                smtp.Credentials = networkCredential;
                smtp.EnableSsl = true;
                smtp.Send(mm);
                label2.Visible = true;
                btn_SendEmail.Enabled = false;
                btn_SendEmail.Text = "認證碼已發送";
            }
            catch (Exception ex)
            {
                MessageBox.Show("發送認證碼錯誤"+ex.Message);
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = $"SELECT * FROM member WHERE email_id = '{tb_Eamil_ID.Text}'" +";"+
                        $"UPDATE member SET approve=1 WHERE email='{email}'";
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.NextResult();
                        reader.Close();
                        command.ExecuteNonQuery();
                        MessageBox.Show("認證成功!  正在為您跳轉頁面");
                        frm_LoginSuccess frm_LoginSuccess = new frm_LoginSuccess(account);
                        frm_LoginSuccess.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("認證碼錯誤");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            frm7 f = new frm7();
            f.Show();
            this.Close();
        }

    }
}
