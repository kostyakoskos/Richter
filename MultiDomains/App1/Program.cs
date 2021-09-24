using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBox.Show("App1 ", AppDomain.CurrentDomain.FriendlyName);
            throw new Exception("Exception in app1");

            MessageBox.Show("App1 after exception ");
        }
    }
}
