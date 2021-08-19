using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.IO;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : BaseTest
    {

        [TestMethod()]
        public void FileNameDoesExists()
        {


            FileProcess fb = new FileProcess();
            bool fromCall;


            set_BAD_FILE_NAME();

            if (!string.IsNullOrEmpty(_GOOD_FILE_NAME))
            {
                // create the 'Good' file
                File.AppendAllText(_GOOD_FILE_NAME, "Some Text");
            }

            TestContext.WriteLine(@"Checking " + _GOOD_FILE_NAME);

            fromCall = fb.FileExists(_GOOD_FILE_NAME);

            if (File.Exists(_GOOD_FILE_NAME))
                File.Delete(_GOOD_FILE_NAME);

            Assert.IsTrue(fromCall);


        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {


            FileProcess fb = new FileProcess();
            bool fromCall;

            fromCall = fb.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);

            TestContext.WriteLine(@"Checking " + BAD_FILE_NAME);
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
