using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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


        private TestContext testContextInstance1;

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
