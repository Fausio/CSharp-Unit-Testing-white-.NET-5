using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    public class BaseTest
    {
        protected string _GOOD_FILE_NAME;
        protected const string BAD_FILE_NAME = @"C:\Windows\PFRO.txt";
        protected const string GOOD_FILE_NAME = @"C:\Windows\PFRO.log";
        public DataTable TestDataTable { get; set; } 
        private TestContext testContextInstance1;

        



        public DataTable LoadDataTable(string sql, string connection)
        {
            TestDataTable = null;

            try
            {
                // Create a connection
                using (SqlConnection ConnectionObject = new SqlConnection(connection))
                {
                    // Create command object
                    using (SqlCommand CommandObject = new SqlCommand(sql, ConnectionObject))
                    {
                        // Create a SQL Data Adapter
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandObject))
                        {
                            // Fill DataTable using Data Adapter
                            TestDataTable = new DataTable();
                            da.Fill(TestDataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Error in LoadDataTable() method." + Environment.NewLine + ex.ToString());
            }

            return TestDataTable;
        }




        //used to call the base methods of TestContext
        public TestContext TestContext
        {
            get { return testContextInstance1; }
            set { testContextInstance1 = value; }
        }
       

        protected void set_BAD_FILE_NAME()
        {
            _GOOD_FILE_NAME = TestContext.Properties["GoodFileName"].ToString();

            if (_GOOD_FILE_NAME.Contains("[AppPath]"))
            {
                _GOOD_FILE_NAME = _GOOD_FILE_NAME.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }


        protected  void WriteDescription(Type type)
        {
            string TestName = TestContext.TestName;
            MemberInfo method = type.GetMethod(TestName);

            if (method !=null)
            {
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
             
                if (attr !=null)
                {
                    // Cast the attribte to a DescriptionAttribute
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;

                    TestContext.WriteLine("Test Description: " + dattr.Description);
                }
            }
        }
    }
}
