using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public  class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\Windows\PFRO.txt";
        private const string GOOD_FILE_NAME = @"C:\Windows\PFRO.log";


        private TestContext testContextInstance1;

        //used to call the base methods of TestContext
        public TestContext TestContext
        {
            get { return testContextInstance1; }
            set { testContextInstance1 = value; }
        }


        [TestMethod()]
        public void FileNameDoesExists()
        {
           

            FileProcess fb = new FileProcess();
            bool fromCall;

          

            fromCall = fb.FileExists(GOOD_FILE_NAME);

            Assert.IsTrue(fromCall);

            TestContext.WriteLine(@"Checking "+ GOOD_FILE_NAME);
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
           

            FileProcess fb = new FileProcess();
            bool fromCall;

            fromCall = fb.FileExists(BAD_FILE_NAME);

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
