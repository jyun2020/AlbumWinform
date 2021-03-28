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
using System.Web.Security;
using System.Windows.Forms;

namespace HomeWork.HW7
{
    public partial class frm_registered : Form
    {
        public frm_registered()
        {
            InitializeComponent();
            birthdayPicker.MaxDate = DateTime.Today;
            birthdayPicker.MinDate = new DateTime(1921, 1, 1);
            birthdayPicker.CustomFormat = "yyyy-MM-dd";
            birthdayPicker.Format = DateTimePickerFormat.Custom;
        }
        string connString = Settings.Default.NorthwindConnectionString; //連線字串

        private void btn_registered_Click(object sender, EventArgs e)
        {
            Judgment jdg = new Judgment(); //建立判斷物件
            UserData data = new UserData(); //建立使用者
            data.Account = tb_account.Text; 
            data.Password1 = tb_password.Text;
            data.Password2 = tb_password2.Text;
            data.Email = tb_email.Text;
            data.Phone = tb_phone.Text;
            data.IDnumber = tb_id.Text;
            data.Date = birthdayPicker.Value;  //設定使用者資訊

            if (checkBox1.Checked == true)  //會員權益說明
            {
                if (!jdg.AllJdg(data, out string AccountMessage, out string PasswordMessage, out string EmailMessage,
            out string PhonenumberMessage, out string IDnumberMessage, out string BirthdayMessage)) 
            //使用者資訊丟進jdg判斷,無錯誤回傳true,有錯則回傳false,並傳回錯誤訊息
                {
                    lb_account.Visible = true;
                    lb_account.Text = AccountMessage;
                    lb_password.Visible = true;
                    lb_password.Text = PasswordMessage;
                    lb_email.Visible = true;
                    lb_email.Text = EmailMessage;
                    lb_phone.Visible = true;
                    lb_phone.Text = PhonenumberMessage;
                    lb_id.Visible = true;
                    lb_id.Text = IDnumberMessage;
                    lb_birthday.Visible = true;
                    lb_birthday.Text = BirthdayMessage;
                    //打開錯誤訊息,顯示錯誤資訊
                }
                else
                {
                    if (AddUserData(data))//如果正確就丟進AddUserData方法裡加進資料庫
                    {
                        MessageBox.Show("註冊成功!為您跳轉登入頁面!");
                        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                        t.Start();
                        this.Close(); //跳轉頁面
                    }
                    else
                    {
                        MessageBox.Show("註冊失敗...");//其他狀況就顯示註冊失敗
                        tb_account.Text = data.Account;
                        tb_password.Text = data.Password1;
                        tb_email.Text = data.Email;
                        tb_phone.Text = data.Phone;
                        tb_id.Text = data.IDnumber; //保持使用者輸入資訊,不要求重複輸入
                    }
                }
            }
            else
            {
                MessageBox.Show("請確認會員權益及說明");
            }
        }
        public bool AddUserData(UserData data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string strSQL = @"INSERT INTO member(Account,Password,email,IDnumber,date,phone)
                          VALUES (@Account,@Password,@email,@IDnumber,@date,@phone)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, conn);

                    string password = data.Password1;
                    for (int i = 0; i < 100; i++)
                    {
                        password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA256");
                    } //跑100次雜湊

                    cmd.Parameters.Add("@Account", SqlDbType.VarChar).Value = data.Account;//前端傳進來的資料
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;//剛剛雜湊完的結果
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = data.Email;//前端傳進來的資料
                    cmd.Parameters.Add("@IDnumber", SqlDbType.VarChar).Value = data.IDnumber;//前端傳進來的資料
                    cmd.Parameters.Add("@date",SqlDbType.Date).Value = data.Date;//前端傳進來的資料
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = data.Phone;//前端傳進來的資料
                    cmd.ExecuteNonQuery();//最後一定要有這個,不然不會報錯也不會加進資料庫
                                          //ExecuteNonQuery方法主要用來更新數據，當然也可以用來執行目標操作
                    return true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public static void ThreadProc()
        {
            Application.Run(new frm7());//設定要跳轉的視窗       
        }

        private void frm_registered_Load(object sender, EventArgs e)
        {

        }
    }
}
