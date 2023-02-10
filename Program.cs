using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hi_Tech_Management_Final_Project.GUI;

namespace Hi_Tech_Management_Final_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new FormBook());
            //Application.Run(new FormCustomerMaintenance());
            //Application.Run(new FormCustomerOrder());
            //Application.Run(new FormEmployeeManagement());
            //Application.Run(new FormOrders());
            Application.Run(new FormLogin());
            //Application.Run(new FormUserManagement());
        }
    }
}
