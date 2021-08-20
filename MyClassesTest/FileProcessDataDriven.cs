using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{

    [TestClass]
   public class FileProcessDataDriven :BaseTest
    {
        //private const string connectionString = @"data source=DESKTOP-C8733BB\MSSQLSERVER01;initial catalog=master;User Id=sa1;Password=medi;integrated security=false;MultipleActiveResultSets=True;App=EntityFramework";
        //private  string connectionString = TestContext.Properties["connectionString"].ToString();

          [TestMethod]
        public void FileExistsTestFromDB()
        {
          

            FileProcess fp = new FileProcess();
             

            bool fromCall = false;
            bool testFaled = false;

            #region db table props
            string FileName;
            bool ExpectedValue;
            bool CouseException;
            #endregion

            string sql = "SELECT * FROM test.FileProcessTest";
            string conn = TestContext.Properties["connectionString"].ToString();

            // load data from db
            LoadDataTable(sql, conn);

            if (TestDataTable != null)
            {
                foreach (DataRow row in TestDataTable.Rows)
                {
                    // get values from data row
                    FileName = row["FileName"].ToString();
                    ExpectedValue = Convert.ToBoolean(row["ExpectedValue"]);
                    CouseException = Convert.ToBoolean(row["CouseException"]);

                    try
                    {
                        fromCall = fp.FileExists(FileName);
                    }
                    catch (ArgumentException)
                    {
                        if (!CouseException)
                        {
                            testFaled = true;
                        }
                    }
                    catch (Exception)
                    {
                        testFaled = true;
                    }

                    TestContext.WriteLine("Testing File: '{0}', expected value: '{1}', Actual Value: '{2}', Result: '{3}'",FileName, ExpectedValue,fromCall,(ExpectedValue == fromCall ? "Sucess":"Failed"));

                    // check assertion
                    if (ExpectedValue != fromCall)
                    {
                        testFaled = true;
                    }

                    if (testFaled)
                    {
                        Assert.Fail("Data Driven Test Have Failed, Checked Additional OutPut For More Information");
                    }
                
                }


            }



            if (true)
            {

            }
        }



    }
}
