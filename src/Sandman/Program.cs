using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sandman
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

            bool createdNew;
            using (new System.Threading.Mutex(true, "C4F-Sandman", out createdNew))
            {
                if (createdNew)
                {
                    MainForm mf = new MainForm();
                    Application.Run();
                }
                else MessageBox.Show("An instance is already running.", "Sandman");
            }
        }
    }
}