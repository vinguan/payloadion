using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayLoadion.Microsoft.PayLoadBuilder;

namespace PayLoadion.Microsoft.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var payloadbuilder = new WnsPayLoadBuilder();

            Console.WriteLine(payloadbuilder.Build());
        }
    }
}
