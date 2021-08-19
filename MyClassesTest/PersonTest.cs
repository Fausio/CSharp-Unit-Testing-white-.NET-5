using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
   public class PersonTest
    {
        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            PersonManager pmg = new PersonManager();
            Person per;

            per = pmg.CreatePerson("Faizal","Isuffo", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNull()
        {
            PersonManager pmg = new PersonManager();
            Person per;

            per = pmg.CreatePerson("", "Isuffo", true);

            Assert.IsNull(per);
        }
    }
}
