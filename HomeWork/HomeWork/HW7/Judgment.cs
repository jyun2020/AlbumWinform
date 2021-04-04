using HomeWork.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork.HW7
{
    public class Judgment : UserData
    {
        private string ConnString;
        public Judgment(string ConnString)
        {
            this.ConnString = ConnString;
        }
        public bool AllJdg(UserData data, out string AccountMessage, out string PasswordMessage, out string EmailMessage,
            out string PhonenumberMessage, out string IDnumberMessage, out string BirthdayMessage)//全部判斷
        {
            AccountMessage = AccountJdg(data.Account);
            PasswordMessage = PasswordJdg(data.Password1, data.Password2);
            EmailMessage = EmailJdg(data.Email);
            PhonenumberMessage = PhonenumberJdg(data.Phone);
            IDnumberMessage = IDnumberJdg(data.IDnumber);
            BirthdayMessage = BirthdayJdg(data.Date.ToString());
            if (AccountMessage == null && PasswordMessage == null && EmailMessage == null && PhonenumberMessage == null && IDnumberMessage == null && BirthdayMessage == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string AccountJdg(string account)//判斷帳號
        {
            this.Account = account;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    string strSQL = "SELECT * FROM member WHERE account = @account";
                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.Add("@account", SqlDbType.VarChar).Value = account;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return "此帳號已被註冊";
                        }
                        else
                        {
                            var hasNumber = new Regex(@"[0-9]+");
                            var hasMiniMaxChars = new Regex(@".{8,15}");
                            var hasLowerChar = new Regex(@"[a-z]+");
                            //var hasUpperChar = new Regex(@"[A-Z]+");
                            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                            if (string.IsNullOrWhiteSpace(account))
                            {
                                return "請輸入帳號";
                            }
                            else if (!hasLowerChar.IsMatch(account))
                            {
                                return "帳號至少應包含一個小寫字母。";
                            }
                            else if (!hasMiniMaxChars.IsMatch(account))
                            {
                                return "帳號不得少於5個或大於15個字符。";
                            }
                            else if (!hasNumber.IsMatch(account))
                            {
                                return "帳號應至少包含一個數字值。";
                            }
                            /*
                            else if (!hasUpperChar.IsMatch(input))
                            {
                                ErrorMessage = "密碼至少應包含一個大寫字母。";
                                return false;
                            }*/
                            /*
                            else if (!hasSymbols.IsMatch(input))
                            {
                                ErrorMessage = "密碼至少應包含一個特殊字符。 ";
                                return false;
                            }*/
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)//錯誤狀況
            {
                string error = ex.ToString();//印出錯誤況狀
                return "重新輸入";
            }
        }
        public string PasswordJdg(string password1, string password2)//判斷密碼
        {
            this.Password1 = password1;
            this.Password2 = password2;
            var hasNumber = new Regex(@"[0-9]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (string.IsNullOrWhiteSpace(password1) || password1 != password2)
            {
                return "兩次輸入密碼不同";
            }
            else if (!hasLowerChar.IsMatch(password1))
            {
                return "密碼至少應包含一個小寫字母。";
            }
            else if (!hasMiniMaxChars.IsMatch(password1))
            {
                return "密碼不得少於5個或大於15個字符。";
            }
            else if (!hasNumber.IsMatch(password1))
            {
                return "密碼應至少包含一個數字值。";
            }
            else
            {
                return null;
            }
        }
        public string EmailJdg(string email)//判斷email
        {
            this.Email = email;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    string strSQL = "SELECT * FROM member WHERE email = @email";
                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return "此信箱已被註冊";
                        }
                        else
                        {
                            var emailjdg = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                            if (string.IsNullOrWhiteSpace(email))
                            {
                                return "請輸入電子信箱";
                            }
                            else if (!emailjdg.IsMatch(email))
                            {
                                return "請輸入正確的電子信箱==";
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)//錯誤狀況
            {
                string error = ex.ToString();//印出錯誤況狀
                return "重新輸入";
            }
        }
        public string PhonenumberJdg(string Phone)//判斷電話號碼
        {
            this.Phone = Phone;
            var PhonenumberJdg = new Regex(@"^09[0-9]{8}$");
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return "請輸入手機號碼";
            }
            if (!PhonenumberJdg.IsMatch(Phone))
            {
                return "請輸入正確手機號碼";
            }
            else
            {
                return null;
            }
        }
        public string IDnumberJdg(string IDnumber)//判斷身分證字號
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                this.IDnumber = IDnumber;
                string strSQL = "SELECT * FROM member WHERE IDnumber = @IDnumber";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.Add("@IDnumber", SqlDbType.VarChar).Value = IDnumber;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return "此帳號已被註冊";
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(IDnumber))
                        {
                            return "請輸入身分證字號";
                        }
                        else
                        {
                            IDnumber = IDnumber.ToUpper();//把英文字轉成大寫
                            bool IDnumberJdg = Regex.IsMatch(IDnumber, @"^[A-Z]{1}[1-2]{1}[0-9]{8}$");
                            int[] ID = new int[11];
                            int count = 0;
                            if (IDnumberJdg == true)//如果符合格式就進入運算
                            {//先把A~Z的對應值存到陣列裡，分別存進第一個跟第二個位置
                                switch (IDnumber.Substring(0, 1))//取出輸入的第一個字--英文字母作為判斷
                                {   //英文代號轉成數子(規定的 A = 10 台北市,B = 11 台中市....)
                                    case "A": (ID[0], ID[1]) = (1, 0); break;//如果是A,ID[0]就放入1,ID[1]就放入0
                                    case "B": (ID[0], ID[1]) = (1, 1); break;//以下以此類推
                                    case "C": (ID[0], ID[1]) = (1, 2); break;
                                    case "D": (ID[0], ID[1]) = (1, 3); break;
                                    case "E": (ID[0], ID[1]) = (1, 4); break;
                                    case "F": (ID[0], ID[1]) = (1, 5); break;
                                    case "G": (ID[0], ID[1]) = (1, 6); break;
                                    case "H": (ID[0], ID[1]) = (1, 7); break;
                                    case "I": (ID[0], ID[1]) = (3, 4); break;
                                    case "J": (ID[0], ID[1]) = (1, 8); break;
                                    case "K": (ID[0], ID[1]) = (1, 9); break;
                                    case "L": (ID[0], ID[1]) = (2, 0); break;
                                    case "M": (ID[0], ID[1]) = (2, 1); break;
                                    case "N": (ID[0], ID[1]) = (2, 2); break;
                                    case "O": (ID[0], ID[1]) = (3, 5); break;
                                    case "P": (ID[0], ID[1]) = (2, 3); break;
                                    case "Q": (ID[0], ID[1]) = (2, 4); break;
                                    case "R": (ID[0], ID[1]) = (2, 5); break;
                                    case "S": (ID[0], ID[1]) = (2, 6); break;
                                    case "T": (ID[0], ID[1]) = (2, 7); break;
                                    case "U": (ID[0], ID[1]) = (2, 8); break;
                                    case "V": (ID[0], ID[1]) = (2, 9); break;
                                    case "W": (ID[0], ID[1]) = (3, 2); break;
                                    case "X": (ID[0], ID[1]) = (3, 0); break;
                                    case "Y": (ID[0], ID[1]) = (3, 1); break;
                                    case "Z": (ID[0], ID[1]) = (3, 3); break;
                                }
                                for (int z = 2; z <= 10; z++)
                                {
                                    ID[z] = Convert.ToInt32(IDnumber.Substring(z - 1, 1));
                                }
                                for (int i = 2; i <= ID.Length - 1; i++)
                                {
                                    for (int k = 9; k >= 1; k--)
                                    {
                                        count += Convert.ToInt32(ID[i]) * k;
                                    }
                                }
                                count = count + Convert.ToInt32(ID[0]) * 1 + Convert.ToInt32(ID[10]) * 1;
                                if (count % 10 == 0)//餘數是0代表正確
                                {
                                    return null;
                                }
                                else
                                {
                                    return string.Format("身份證不存在");
                                }
                            }
                            else
                            {
                                return "身份證格式不正確";
                            }
                        }
                    }
                }
            }
        }
        public string BirthdayJdg(string Date)
        {
            DateTime dt = DateTime.Now;
            this.Date = Convert.ToDateTime(Date);

            if (DateTime.Compare(dt.Date, this.Date) <= 0)
            {
                return "請輸入正確日期";
            }
            else
            {
                return null;
            }
        }//判斷生日日期是否超過now
    }
}