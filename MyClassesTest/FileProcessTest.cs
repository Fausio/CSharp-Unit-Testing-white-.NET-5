using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExists()
        {
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
        }

        [TestMethod]
        public void FileNameNullOrEmpty(string fileName)
        {
            throw new ArgumentNullException(nameof(fileName));
        }
    }
}
