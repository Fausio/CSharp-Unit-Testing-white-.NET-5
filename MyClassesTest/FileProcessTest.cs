﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.IO;
using System;

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
        public void FileNameNullOrEmpty_usingAtribute()
        {
            FileProcess fb = new FileProcess();
            fb.FileExists("");
        }



        [TestMethod]
        [Description("Check for a FileNameNullOrEmpty Whit try...catch.")]
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
