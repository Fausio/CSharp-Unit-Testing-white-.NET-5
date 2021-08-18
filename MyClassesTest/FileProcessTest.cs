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
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_usingAtribute()
        {
            FileProcess fb = new FileProcess();
            fb.FileExists("");
        }



        [TestMethod]
        public void FileNameNullOrEmpty_usingTryCatch()
        {
            FileProcess fb = new FileProcess();


            try
            {
                fb.FileExists("");
            }
            catch (ArgumentNullException)
            {
                // Test was a sucess
                return;
            }

            // Fail the test
            Assert.Fail("Call to FileExists did Not throw an ArgumentNullException");

        }
    }
}
