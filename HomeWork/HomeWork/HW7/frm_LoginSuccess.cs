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
        public frm_LoginSuccess(string memberName)
        {
            InitializeComponent();
            label2.Text = memberName;
        }
        public string memberName
        {
            set
            {
                label2.Text = value;
            }
            get
            {
                return label2.Text;
            }
        }
    }
}
