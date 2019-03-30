using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StartMenuCleaner
{
    /// <summary>
    /// Start Menu Cleaner Class.
    /// </summary>
    public class SMCleaner
    {
        #region Private Attributes
        /// <summary>
        /// String that contains the windows-start-menu path
        /// </summary>
        private static readonly List<string> StartMenuPath = new List<string>(){
            String.Format(@"{0}\Microsoft\Windows\Start Menu\Programs\", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)),
            String.Format(@"{0}\Microsoft\Windows\Start Menu\Programs\", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
        };

        /// <summary>
        /// List that contains several words to search for. (Fixed Dictionnary)
        /// </summary>
        private static readonly List<string> DefaultWordsToRemove = new List<string>() { "Uninstall", "Delete", "Remove" };

        #endregion

        #region Public Methods

        /// <summary>
        /// Enumerate all LNK files in all start menu folder paths.
        /// </summary>
        /// <returns>List of .lnk fileinfo.</returns>
        public static List<FileInfo> EnumerateAllLnkFiles()
        {
            List<FileInfo> fileInfos = new List<FileInfo>();

            try
            {
                foreach (FileInfo fi in StartMenuPath.SelectMany(x => new DirectoryInfo(x).EnumerateFiles("*.lnk", SearchOption.AllDirectories)))
                {
                    fileInfos.Add(fi);
                }
                return fileInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the list of every file found in the start menu path and apply a filter.
        /// e.g check for file name "Uninstall".       
        /// </summary>
        /// <param name="searchResult">List of every file found in the start menu path.</param>
        /// <returns>returnResults</returns>
        public static List<string> NormalScanFilter(List<FileInfo> searchResult)
        {
            List<string> returnResults = new List<string>();

            try
            {
                foreach (string wordToRemove in DefaultWordsToRemove)
                {
                    searchResult.ForEach(delegate (FileInfo result)
                    {
                        if ((result.Name.IndexOf(wordToRemove, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            returnResults.Add(result.FullName);
                        }
                    });
                }
                return returnResults;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the list of every file found in the start menu path and apply a user custom made filter
        /// via the customSearchTextBox.
        /// </summary>
        /// <param name="searchResult">List of every file found in the start menu path.</param>
        /// <param name="customSearchEntry">The custom search entry.</param>
        /// <returns></returns>
        public static List<string> CustomScanFilter(List<FileInfo> searchResult, string customSearchEntry)
        {
            List<string> returnResults = new List<string>();
            List<string> customDictionnary = new List<string>();

            try
            {
                customDictionnary = customSearchEntry.Split(';').ToList();
                foreach (string dicWord in customDictionnary)
                {
                    searchResult.ForEach(delegate (FileInfo result)
                    {
                        if ((result.Name.IndexOf(dicWord, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            returnResults.Add(result.FullName);
                        }
                    });
                }
                return returnResults;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Removes the shortcut file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public static bool RemoveShortcutFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
