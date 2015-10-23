using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StartMenuCleaner
{
    static class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Get compiling date
            DateTime compileDate = new DateTime();
            compileDate = DateTime.Now;
            string sDate = compileDate.ToShortDateString();
            //Get App name + version (+fixed name and current date) from assembly
            string[] applicationInfo = new string[4] { Application.ProductName, Application.ProductVersion, "Steven Jalabert", sDate  };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Overload the Main Form to change its text dynamically (version, date..)
            MainForm mf1 = new MainForm();
            mf1.Text = applicationInfo[0] + " " + applicationInfo[1] + " - " + applicationInfo[2] + " - " + applicationInfo[3];
            mf1.ShowDialog();
        }
    }
}
