using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PrimeFactors.Tests
{
    [TestFixture]
    public class ArgumentValidationTests
    {
        [Test]
        public void Test_Not_Null()
        {
            ArgumentValidation.NotNullCheck(string.Empty, string.Empty);
        }

        [Test]
        public void Test_Null()
        {
            string nullValue = null;
            Assert.Throws<ArgumentNullException>(() => 
                ArgumentValidation.NotNullCheck(nullValue, string.Empty),
                "A argument of null was inappropriately allowed."
            );
        }
    }
}
