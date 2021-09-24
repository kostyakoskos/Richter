using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBox.Show("App2 ", AppDomain.CurrentDomain.FriendlyName);
            throw new Exception("Exception in app2");

            MessageBox.Show("App2 after exception ");
        }
    }
}
