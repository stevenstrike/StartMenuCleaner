using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartMenuCleaner
{
    public partial class MainForm : Form
    {
        private List<String> dictionnary = new List<string>();
        private List<string> Result = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            //Normal Scan words
            dictionnary.Add("Uninstall");
            dictionnary.Add("Delete");
            dictionnary.Add("Remove");
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            resultsCheckedListBox.Items.Clear();
            Result = dirSearch("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\");
            Result = normalScanCleanResults(Result);
            addResultToCheckedListBox(Result);
        }

        private List<String> dirSearch(string sDir)
        {
            List<String> sReturnList = new List<string>();
            try
            {
                foreach (string file in Directory.EnumerateFiles(sDir, "*.*", SearchOption.AllDirectories))
                {
                    sReturnList.Add(file);
                }
                return sReturnList;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                return sReturnList;
            }
        }

        private List<String> normalScanCleanResults(List<String> list)
        {
            List<String> returnResults = new List<string>();
            try {
                foreach (string dicword in dictionnary)
                {
                    list.ForEach(delegate(string word)
                    {
                        if ((word.IndexOf(dicword, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            returnResults.Add(word);
                        }
                    });                    
                }
                return returnResults;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                return list;
            }
        }

        private List<String> customScanCleanResults(List<String> list)
        {
            List<String> returnResults = new List<string>();
            List<String> customDictionnary = new List<string>();
            try {
                string customSearchEntry = customSearchTextBox.Text;
                customDictionnary = customSearchEntry.Split(';').ToList();
                foreach (string dicword in customDictionnary)
                {
                    list.ForEach(delegate (string word)
                    {
                        if ((word.IndexOf(dicword, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            returnResults.Add(word);
                        }
                    });
                }
                return returnResults;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                return list;
            }
        }

        private void addResultToCheckedListBox(List<string> list)
        {
            try
            {
                resultsCheckedListBox.Items.Clear();
                list.ForEach(delegate (string file)
                {
                    resultsCheckedListBox.Items.Add(file);
                });
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                resultsCheckedListBox.Items.Clear();
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to completly delete this item ?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                foreach (var item in resultsCheckedListBox.CheckedItems.OfType<string>().ToList())
                    try
                    {
                        File.Delete(item.ToString());
                        resultsCheckedListBox.Items.Remove(item);
                    }
                    catch (System.Exception excpt)
                    {
                        Console.WriteLine(excpt.Message);
                    }
            }
        }

        private void scanCustomButton_Click(object sender, EventArgs e)
        {
            resultsCheckedListBox.Items.Clear();
            Result = dirSearch("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\");
            Result = customScanCleanResults(Result);
            addResultToCheckedListBox(Result);
        }

        private void customSearchTextBox_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = scanCustomButton;
        }
    }
}
