using HomeWork.HW5;
using HomeWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW7
{
    public partial class frm_LoginSuccess : Form
    {
        string account = "";
        public frm_LoginSuccess(string account)
        {
            InitializeComponent();
            this.Text= "親愛的" + account + "歡迎回來";
            this.account = account;
        }

        private void btn_MyAlbum_Click(object sender, EventArgs e)
        {
            frm5 f = new frm5(account);
            f.Show();
            this.Close(); //跳轉頁面
        }
    }
}
