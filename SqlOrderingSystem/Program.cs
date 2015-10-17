using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOrderingSystem
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
            LoginForm loginform = new LoginForm();
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                loginform.Dispose();
                Application.Run(new MainForm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
