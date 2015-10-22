using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StartMenuCleaner
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DateTime compileDate = new DateTime();
            compileDate = DateTime.Now;
            string sDate = compileDate.ToShortDateString();
            string[] applicationInfo = new string[4] { Application.ProductName, Application.ProductVersion, "Steven Jalabert", sDate  };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mf1 = new MainForm();
            mf1.Text = applicationInfo[0] + " " + applicationInfo[1] + " - " + applicationInfo[2] + " - " + applicationInfo[3];
            mf1.ShowDialog();
        }
    }
}
