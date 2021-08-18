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
            FileProcess fb = new FileProcess();
            bool fromCall;

            fromCall = fb.FileExists(@"C:\Windows\PFRO.log");

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            FileProcess fb = new FileProcess();
            bool fromCall;

            fromCall = fb.FileExists(@"C:\Windows\PFRO.txt");

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        public void FileNameNullOrEmpty_usingAtribute()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void FileNameNullOrEmpty_usingTryCatch()
        {
            Assert.Inconclusive();
        }
    }
}
