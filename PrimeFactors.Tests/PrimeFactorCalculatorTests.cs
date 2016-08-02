using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PrimeFactors.Tests
{
    /// <summary>
    /// Just a couple sanity checks that the PrimeFactorCalculator does the same as the FactorizationCalculator 
    /// that it wraps.
    /// </summary>
    [TestFixture]
    public class PrimeFactorCalculatorTests
    {
        private readonly PrimeFactorCalculator calculator = new PrimeFactorCalculator();

        [Test]
        public void Test_For_One()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(1), new List<int>() { });
        }

        [Test]
        public void Test_For_Two()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(2), new List<int>() { 2 });
        }

        [Test]
        public void Test_For_Three()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(3), new List<int>() { 3 });
        }

        [Test]
        public void Test_For_Four()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(4), new List<int>() { 2, 2 });
        }

        [Test]
        public void Test_For_Five()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(5), new List<int>() { 5 });
        }

        [Test]
        public void Test_For_Six()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(6), new List<int>() { 2, 3 });
        }

        [Test]
        public void Test_For_Seven()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(7), new List<int>() { 7 });
        }

        [Test]
        public void Test_For_Eight()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(8), new List<int>() { 2, 2, 2 });
        }

        [Test]
        public void Test_For_Nine()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(9), new List<int>() { 3, 3 });
        }

        [Test]
        public void Test_For_NintySix()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(96), new List<int>() { 2, 2, 2, 2, 2, 3 });
        }

        [Test]
        public void Test_For_OneHundredTwenty()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(120), new List<int>() { 2, 2, 2, 3, 5 });
        }

        [Test]
        public void Test_For_OneThousandEightHundredTwentyThree()
        {
            CollectionAssert.AreEqual(this.calculator.Execute(1820), new List<int>() { 2, 2, 5, 7, 13 });
        }
    }
}
