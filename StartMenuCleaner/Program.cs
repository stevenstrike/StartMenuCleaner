using System;
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
            //Get App name + version (+fixed name and current build date) from assembly
            string[] applicationInfo = new string[4] { Application.ProductName, Application.ProductVersion, "StevenStrike", Properties.Resources.BuildDate };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Overload the Main Form to change its text dynamically (version, date..)
            MainForm mf1 = new MainForm
            {
                Text = String.Format("{0} {1} {2} {3}", applicationInfo[0], applicationInfo[1], applicationInfo[2], applicationInfo[3])
            };
            mf1.ShowDialog();
        }
    }
}
