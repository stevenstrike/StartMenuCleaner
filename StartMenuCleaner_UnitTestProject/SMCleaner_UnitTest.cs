using Microsoft.VisualStudio.TestTools.UnitTesting;
using StartMenuCleaner;
using System.IO;
using System.Linq;

namespace StartMenuCleaner_UnitTestProject
{
    [TestClass]
    public class SMCleaner_UnitTest
    {
        [TestMethod]
        public void EnumerateAllLnkFiles()
        {
            var lnkFiles = SMCleaner.EnumerateAllLnkFiles();
            Assert.IsTrue(lnkFiles != null);
        }

        [TestMethod]
        public void NormalScanFilter()
        {
            // Step 1 : Find lnks.
            var lnkFiles = SMCleaner.EnumerateAllLnkFiles();
            Assert.IsTrue(lnkFiles != null && lnkFiles.Any());

            // Step 2 : Filter items, using default ruleset.
            var returnResults = SMCleaner.NormalScanFilter(lnkFiles);
            Assert.IsTrue(returnResults != null && returnResults.Any());
        }

        [TestMethod]
        public void CustomScanFilter()
        {
            // Step 1 : Find lnks.
            var lnkFiles = SMCleaner.EnumerateAllLnkFiles();
            Assert.IsTrue(lnkFiles != null && lnkFiles.Any());

            // Step 2 : Filter items, using custom ruleset.
            var returnResults = SMCleaner.CustomScanFilter(lnkFiles, "Désinstaller");
            Assert.IsTrue(returnResults != null && returnResults.Any());
        }

        [TestMethod]
        public void RemoveShortcutFile()
        {
            string fileToRemove = "";

            bool isFileDeleted = SMCleaner.RemoveShortcutFile(fileToRemove);

            Assert.IsFalse(isFileDeleted);
        }
    }
}
