using System;
using CardlyticsTest;
using NUnit.Framework;

namespace CardlyticsTestProject
{
    [TestFixture]
    public class TriangleTest
    {
        [SetUp]
        public void Init()
        {
            //All initializations
        }
        public void triangleTest(Triangle<int, decimal, double> lnew1, TypeofTriangle expected)
        {
            TypeofTriangle valq = lnew1.triangleType(lnew1);
            Assert.AreEqual(expected, valq);
        }
        [Test]
        public void checkNumberFormateExpection() {
            //for every type of exception we pass certain parameter and match the output
            throw new NotImplementedException();
        }
        [Test]
        public void checkClassTypeExpection() {
            //for every type of exception we pass certain parameter and match the output
            throw new NotImplementedException();
        }
        [Test]
        public void run() 
        {
              Triangle<int, decimal, double> lnew1      = new Triangle<int, decimal, double>(1, 1.1M, 1.1);
              Triangle<double, decimal, double> lnew2   = new Triangle<double, decimal, double>(2.1, 1.1M, 1.1);
              Triangle<decimal, decimal, double> lnew3  = new Triangle<decimal, decimal, double>(2.1m, 1.1M, 1.1);
              Triangle<string, decimal, double> lnew4   = new Triangle<string, decimal, double>("nikunj", 1.1M, 1.1);

        }
    }
}
