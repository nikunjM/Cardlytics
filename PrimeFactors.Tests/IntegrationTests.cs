using System;
using NUnit.Framework;
using System.IO;

namespace PrimeFactors.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Test_End_To_End()
        {
            string input = "9\r\n" +
                           "8\r\n" +
                           "nothing\r\n" + 
                           "13\r\n" +
                           "-87\r\n" +
                           "2";

            string expected = "9:3,3\r\n" +
                              "8:2,2,2\r\n" +
                              "13:13\r\n" +
                              "-87:1\r\n" +
                              "2:2\r\n";

            var standardOut = new StringWriter();
            var errorOut = new StringWriter();
            var logger = new ConsoleLogger(standardOut, errorOut);

            IPrimeFactorCalculator calculator = new PrimeFactorCalculator(); // The main calculator.
            calculator = new PrimeFactorOutputWriter(calculator, logger);    // Our formatter for dumping to the console
            calculator = new PrimeFactorExceptionLogger(calculator, logger); // An exception handler that can log errors for us.

            var path = TempFileHelpers.CreateTestFile(input);
            IIntegerReader reader = new IntegerFileReader(path);

            int? number;
            while ((number = reader.ReadNext()) != null)
            {
                calculator.Execute(number.Value);
            }

            Assert.AreEqual(expected, standardOut.ToString());
            Assert.AreEqual(string.Empty, errorOut.ToString());
        }
    }
}
