using StartMenuCleaner.Classes.FormTools;
using StartMenuCleaner.Classes.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StartMenuCleaner
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// List that contains the search result, and then the scan result.
        /// </summary>
        private List<string> SearchResult = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        private const string CustomSearchTextBoxDefaultText = "Enter a custom pattern, e.g : remove;uninstall;something";

        /// <summary>
        /// Boolean to check if customSearchTextBox has been typedInto or not.
        /// </summary>
        private bool _TypedInto = false;

        /// <summary>
        /// Boolean to check if the previous state was checked or not
        /// </summary>
        private bool _StateChecked = true;

        /// <summary>
        /// The list box log
        /// </summary>
        private static ListBoxLog MyListBoxLog;

        /// <summary>
        /// Form and fixed dictionnary init
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            MyListBoxLog = new ListBoxLog(logLB);
        }

        /// <summary>
        /// Populate the CheckedListBox with the filtered files list.
        /// </summary>
        /// <param name="list">List of the filtered files list.</param>
        private void AddResultToCheckedListBox(List<string> list)
        {
            try
            {
                if (resultsCheckedListBox != null && resultsCheckedListBox.Items != null)
                {
                    resultsCheckedListBox.Items.Clear();
                }

                if(list != null && list.Any())
                {
                    list.ForEach(delegate (string file)
                    {
                        resultsCheckedListBox.Items.Add(file);
                    });
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                MyListBoxLog.Log(Enums.LogLevel.Error, excpt.Message);
            }
        }

        #region Form Events

        /// <summary>
        /// MainForm load event (clean the checkedListBox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (resultsCheckedListBox != null && resultsCheckedListBox.Items != null)
                {
                    resultsCheckedListBox.Items.Clear();
                }

                customSearchTextBox.Text = CustomSearchTextBoxDefaultText;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                MyListBoxLog.Log(Enums.LogLevel.Error, excpt.Message);
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
            try
            {
                if (resultsCheckedListBox != null && resultsCheckedListBox.Items != null)
                {
                    resultsCheckedListBox.Items.Clear();
                }

                var fileInfos = SMCleaner.EnumerateAllLnkFiles();
                this.SearchResult = SMCleaner.NormalScanFilter(fileInfos);
                AddResultToCheckedListBox(this.SearchResult);

                MyListBoxLog.Log(Enums.LogLevel.Info, String.Format("Regular Scan: Found {0} items.", this.SearchResult.Count()));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MyListBoxLog.Log(Enums.LogLevel.Error, ex.Message);
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
            try
            {
                if (customSearchTextBox.Text == CustomSearchTextBoxDefaultText) { }
                else
                {
                    if (resultsCheckedListBox != null && resultsCheckedListBox.Items != null)
                    {
                        resultsCheckedListBox.Items.Clear();
                    }

                    var fileInfos = SMCleaner.EnumerateAllLnkFiles();
                    this.SearchResult = SMCleaner.CustomScanFilter(fileInfos, customSearchTextBox.Text);
                    AddResultToCheckedListBox(this.SearchResult);

                    MyListBoxLog.Log(Enums.LogLevel.Info, String.Format("Custom Scan: Found {0} items.", this.SearchResult.Count()));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                MyListBoxLog.Log(Enums.LogLevel.Error, excpt.Message);
            }
        }

        /// <summary>
        /// Function called when "Remove" button is hit, will remove each checked files from the resultsCheckedListBox.
        /// Print a dialog form before erasing, asking the user to confirm the operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (resultsCheckedListBox.CheckedItems.Count > 0)
                {
                    var confirmResult = MessageBox.Show("Are you sure you want to completly delete this item ?",
                                             "Confirm Delete",
                                             MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        foreach (var item in resultsCheckedListBox.CheckedItems.OfType<string>().ToList())
                        {
                            try
                            {
                                File.Delete(item.ToString());
                                resultsCheckedListBox.Items.Remove(item);

                                MyListBoxLog.Log(Enums.LogLevel.Info, String.Format("Item {0} deleted.", item.ToString()));
                            }
                            catch (System.Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MyListBoxLog.Log(Enums.LogLevel.Error, ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MyListBoxLog.Log(Enums.LogLevel.Info, "User cancelled the operation.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                MyListBoxLog.Log(Enums.LogLevel.Error, ex.Message);
            }
        }

        /// <summary>
        /// Function called when "Select All/None" button is hit, will select/deselect all checkboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectCheckboxButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsCheckedListBox.Items.Count; i++)
                resultsCheckedListBox.SetItemCheckState(i, (_StateChecked ? CheckState.Checked : CheckState.Unchecked));
            if (_StateChecked == true)
                _StateChecked = false;
            else if (_StateChecked == false)
                _StateChecked = true;
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
            if (!_TypedInto) { customSearchTextBox.Text = String.Empty; }
            else if (customSearchTextBox.Text == CustomSearchTextBoxDefaultText) { customSearchTextBox.Text = String.Empty; }
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
                customSearchTextBox.Text = CustomSearchTextBoxDefaultText;
            }
        } 
        #endregion
    }
}
