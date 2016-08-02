using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace PrimeFactors.Tests
{
    [TestFixture]
    public class ConsoleLoggerTests
    {
        [Test]
        public void Test_Standard_Out()
        {
            var standardOut = new StringWriter();
            var errorOut = new StringWriter();
            var logger = new ConsoleLogger(standardOut, errorOut);

            logger.Log("Test Message");

            Assert.AreEqual("Test Message\r\n", standardOut.ToString());
            Assert.AreEqual(string.Empty, errorOut.ToString());
        }

        [Test]
        public void Test_Standard_Out_Formatted()
        {
            var standardOut = new StringWriter();
            var errorOut = new StringWriter();
            var logger = new ConsoleLogger(standardOut, errorOut);

            logger.Log("{0}:{1}", 1, 2);

            Assert.AreEqual("1:2\r\n", standardOut.ToString());
            Assert.AreEqual(string.Empty, errorOut.ToString());
        }

        [Test]
        public void Test_Standard_Error()
        {
            var standardOut = new StringWriter();
            var errorOut = new StringWriter();
            var logger = new ConsoleLogger(standardOut, errorOut);

            logger.LogError(new Exception("Test"));

            Assert.AreEqual(string.Empty, standardOut.ToString());
            Assert.AreEqual("System.Exception: Test\r\n", errorOut.ToString());
        }

        [Test]
        public void Test_Standard_Error_With_Message()
        {
            var standardOut = new StringWriter();
            var errorOut = new StringWriter();
            var logger = new ConsoleLogger(standardOut, errorOut);

            logger.LogError(new Exception("Test"), "Test Message");

            Assert.AreEqual(string.Empty, standardOut.ToString());
            Assert.AreEqual("Test Message\r\nSystem.Exception: Test\r\n", errorOut.ToString());
        }
    }
}
