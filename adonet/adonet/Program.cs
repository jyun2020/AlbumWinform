using adonet._1.Overview;
using Demo;
using Starter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonet
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmOverview());
            //Application.Run(new FrmSqlConnection());
            //Application.Run(new FrmConnected());
            //Application.Run(new FrmTransactionIsolation());
            Application.Run(new FrmDisConnected_離線DataSet());
        }
    }
}
