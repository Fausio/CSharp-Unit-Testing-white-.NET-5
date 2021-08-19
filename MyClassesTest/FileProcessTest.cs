using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public  class FileProcessTest
    {
        protected string _GOOD_FILE_NAME;
        private const string BAD_FILE_NAME = @"C:\Windows\PFRO.txt";
        private const string GOOD_FILE_NAME = @"C:\Windows\PFRO.log";


        private TestContext testContextInstance1;

        //used to call the base methods of TestContext
        public TestContext TestContext
        {
            get { return testContextInstance1; }
            set { testContextInstance1 = value; }
        }


        public void set_BAD_FILE_NAME()
        {
            _GOOD_FILE_NAME = TestContext.Properties["GoodFileName"].ToString();

            if (_GOOD_FILE_NAME.Contains("[AppPath]"))
            {
                _GOOD_FILE_NAME = _GOOD_FILE_NAME.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }


        [TestMethod()]
        public void FileNameDoesExists()
        {
           

            FileProcess fb = new FileProcess();
            bool fromCall;


            set_BAD_FILE_NAME();
            TestContext.WriteLine(@"Checking " + _GOOD_FILE_NAME);

            fromCall = fb.FileExists(_GOOD_FILE_NAME);

            Assert.IsTrue(fromCall);
            
            
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
           

            FileProcess fb = new FileProcess();
            bool fromCall;

            fromCall = fb.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
             
           TestContext.WriteLine(@"Checking "+ BAD_FILE_NAME);
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
