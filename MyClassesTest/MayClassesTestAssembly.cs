using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class MayClassesTestAssembly
    {

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            // TODO: before all testes
            tc.WriteLine("Running AssemblyInitialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // TODO: after all testes
        }

    }
}
