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
        /// <summary>
        /// List that contains several words to search for. (Fixed Dictionnary)
        /// </summary>
        private List<string> dictionnary = new List<string>();

        /// <summary>
        /// List that contains the search result, and then the scan result.
        /// </summary>
        private List<string> Result = new List<string>();

        /// <summary>
        /// String that contains the windows-start-menu path
        /// </summary>
        private string startMenuPath = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\";

        /// <summary>
        /// 
        /// </summary>
        private string customSearchTextBoxDefaultText = "Enter a custom pattern, e.g : remove;uninstall;something";

        /// <summary>
        /// 
        /// </summary>
        private bool _TypedInto = false;

        /// <summary>
        /// Form and fixed dictionnary init
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //Default Scan words
            dictionnary.Add("Uninstall");
            dictionnary.Add("Delete");
            dictionnary.Add("Remove");
        }

        /// <summary>
        /// MainForm load event (clean the checkedListBox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                resultsCheckedListBox.Items.Clear();
                customSearchTextBox.Text = customSearchTextBoxDefaultText;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        /// <summary>
        /// Search through a given path for files recursively, 
        /// return a list of string with the path of every files.
        /// </summary>
        /// <param name="sDir">Fixed Dictionnary</param>
        /// <returns>sReturnList</returns>
        private List<string> dirSearch(string sDir)
        {
            List<string> sReturnList = new List<string>();
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
                return null;
            }
        }

        /// <summary>
        /// Get the list of every file found in the start menu path and apply a filter.
        /// e.g check for file name "Uninstall".       
        /// </summary>
        /// <param name="list">List of every file found in the start menu path.</param>
        /// <returns>returnResults</returns>
        private List<string> normalScanCleanResults(List<string> list)
        {
            List<string> returnResults = new List<string>();
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
                return null;
            }
        }

        /// <summary>
        /// Get the list of every file found in the start menu path and apply a user custom made filter
        /// via the customSearchTextBox.
        /// </summary>
        /// <param name="list">List of every file found in the start menu path.</param>
        /// <returns></returns>
        private List<string> customScanCleanResults(List<string> list)
        {
            List<string> returnResults = new List<string>();
            List<string> customDictionnary = new List<string>();
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

        /// <summary>
        /// Populate the CheckedListBox with the filtered files list.
        /// </summary>
        /// <param name="list">List of the filtered files list.</param>
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

        /// <summary>
        /// Function called when "Scan" button is hit, will perform a search, then filter the result,
        /// and print that result in a CheckedListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scanButton_Click(object sender, EventArgs e)
        {
            resultsCheckedListBox.Items.Clear(); //CheckedListbox Init
            Result = dirSearch(startMenuPath);
            Result = normalScanCleanResults(Result);
            addResultToCheckedListBox(Result);
        }

        /// <summary>
        /// Function called when "Remove" button is hit, will remove each checked files from the resultsCheckedListBox.
        /// Print a dialog form before erasing, asking the user to confirm the operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            try {
                if(resultsCheckedListBox.CheckedItems.Count != 0)
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
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        /// <summary>
        /// Function called when "Scan Custom" button is hit, will perform a search based on a user custom query, then filter the result,
        /// and print that result in a CheckedListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scanCustomButton_Click(object sender, EventArgs e)
        {
            try { 
                if(customSearchTextBox.Text == customSearchTextBoxDefaultText) { }
                else {
                    resultsCheckedListBox.Items.Clear();
                    Result = dirSearch(startMenuPath);
                    Result = customScanCleanResults(Result);
                    addResultToCheckedListBox(Result);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        /// <summary>
        /// Set focus on "Scan Custom" Button when clicking the TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customSearchTextBox_Enter(object sender, EventArgs e)
        {
            AcceptButton = scanCustomButton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(customSearchTextBox.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            _TypedInto = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customSearchTextBox_Click(object sender, EventArgs e)
        {
            if (!_TypedInto) { customSearchTextBox.Text = ""; }
            else if (customSearchTextBox.Text == customSearchTextBoxDefaultText) { customSearchTextBox.Text = ""; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customSearchTextBox_Leave(object sender, EventArgs e)
        {
            if (!_TypedInto)
            {
                customSearchTextBox.Text = customSearchTextBoxDefaultText;
            }
        }

    }
}
