using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace ConsoleApp1
{
    //5 種小零件
    //struct
    //enum
    //class
    //interface
    //delegate


    //===================================
    // 用 .NET Framework 小零件

    // 1. 參考 dll
    // 2. using Namespace

    //===================================
    // 存取修飾子 Access Modifiers: public / internal / private 

    // static vs intance

    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.Write("Please input your name: ");
            string s = Console.ReadLine();

            Console.WriteLine("Hello, WarmUP " + s);

            MessageBox.Show("Hello !" + s);


            //full name
            System.Windows.Forms.MessageBox.Show("Hello, full name　"+s);
        }
    }
}
