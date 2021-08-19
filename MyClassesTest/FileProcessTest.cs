using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.IO;
using System;
using System.Threading;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : BaseTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            // TODO: before all methods run
            tc.WriteLine("ClassInitialize In FileProcessTest");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            // TODO: clean up after all method run
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("TestInitialize In FileProcessTest");

            WriteDescription(this.GetType());

            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                set_BAD_FILE_NAME();

                if (!string.IsNullOrEmpty(_GOOD_FILE_NAME))
                {
                    // create the 'Good' file
                    File.AppendAllText(_GOOD_FILE_NAME, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {

            TestContext.WriteLine("TestCleanup In FileProcessTest");

            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                if (File.Exists(_GOOD_FILE_NAME))
                    File.Delete(_GOOD_FILE_NAME);
            }
        }


        [TestMethod()]
        [Description("Check to see if a file exists.")]
        [Owner("Fausio")]
        [TestCategory("ForFile")]
        [Priority(4)]
        public void FileNameDoesExists()
        {


            FileProcess fb = new FileProcess();
            bool fromCall;

            TestContext.WriteLine(@"Checking " + _GOOD_FILE_NAME);

            fromCall = fb.FileExists(_GOOD_FILE_NAME);



            Assert.IsTrue(fromCall);


        }

        [TestMethod]
        [Description("Check to see if a file doesnt exists.")]
        [Owner("Fausio")]
        [TestCategory("ForFile")]
        [Priority(3)]
        //[Ignore]
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
        [Description("Check for a FileNameNullOrEmpty With ArgumentNullException  Attribute.")]
        [Owner("Luis")]
        [TestCategory("ForException")]
        [Priority(2)]
        public void FileNameNullOrEmpty_usingAtribute()
        {
            FileProcess fb = new FileProcess();
            fb.FileExists("");
        }



        [TestMethod]
        [Description("Check for a FileNameNullOrEmpty Whit try...catch.")]
        [Owner("Luis")]
        [TestCategory("ForException")]
        [Priority(1)]
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


        [TestMethod]
        [Timeout(3000)]
        public void RunningTimeTest()
        {
            Thread.Sleep(1000);
        }

        [TestMethod]
        [DataRow(1, 1, DisplayName = "First Test (1,1)")]
        [DataRow(23, 23, DisplayName = "Second Test (23,23)")]
        public void AreNumberEqual(int num1, int num2)
        {
            Assert.AreEqual(num1, num2);
        }

        [TestMethod]
        [DeploymentItem("FilefTodePloy.txt")]
        [DataRow(@"C:\windows\regedit.exe",DisplayName = "regedit.exe")]
        [DataRow("FileToDePloy.txt", DisplayName ="Deployment Item: FileToDeploy")]
        public void FileNameUsingDataRow(string FileName)
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            if (!FileName.Contains(@"\"))
            {
                FileName = TestContext.DeploymentDirectory + @"\" + FileName;
            }

            TestContext.WriteLine("Checking File" + FileName);
            fromCall = fp.FileExists(FileName);

            Assert.IsTrue(fromCall);
        }

    }
}
