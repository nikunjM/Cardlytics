using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardlyticsTest;
using System.Dynamic;
using System.Collections.Generic;

namespace CardlyticsTestProject
{
    [TestClass]
    public class LinkedListTest
    {

        private LinkedListType<int> createIntTypeListWithValues(int values)
        {
            LinkedListType<int> lnew = new LinkedListType<int>();
            for (int i = 0; i < values; i++)
            {
                lnew.add(i);
            }
            return lnew;
        }
        private LinkedListType<string> createStringTypeListWithValues(int values)
        {
            LinkedListType<String> lnew = new LinkedListType<String>();
            for (int i = 0; i < values; i++)
            {
                lnew.add("StringVAl" + i);
            }
            return lnew;
        }
        [TestMethod]
        // Test Case#1: Values more then 5 ... 
        public void LinkedListTestCase1()
        {
            LinkedListType<int> lnew = createIntTypeListWithValues(8);
            Assert.AreEqual(4, lnew.print5thFromLast());
        }
        [TestMethod]
        //where values are string StringVAl4
        public void LinkedListTestCase2()
        {
            LinkedListType<String> lnew = createStringTypeListWithValues(8);
            Assert.AreEqual("StringVAl4", lnew.print5thFromLast());
        }
        [TestMethod]
        //where values are string StringVAl4
        public void LinkedListTestCase5()
        {
            LinkedListType<String> lnew = createStringTypeListWithValues(2);
            Assert.Fail();
        }

        //where values are less then five with int type 
        public void LinkedListTestCase3()
        {
            LinkedListType<int> lnew = createIntTypeListWithValues(2);
            try 
            {
                lnew.print5thFromLast();
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
            }
        }
    }
}

