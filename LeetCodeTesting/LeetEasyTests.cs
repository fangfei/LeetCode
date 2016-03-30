using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCodeEasy;
using System.Collections.Generic;

namespace LeetCodeEasy.Tests
{
    [TestClass()]
    public class LeetEasyTests
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "Leet292TestData.CSV",
                    "Leet292TestData#CSV",
                    DataAccessMethod.Sequential)]
        [DeploymentItem("Leet292TestData.CSV")]
        public void Leet292_CanWinNimTest()
        {
            LeetCodeEasySolution leetEasy = new LeetCodeEasySolution();
            int N = Int32.Parse(TestContext.DataRow[0].ToString());
            bool expected = bool.Parse(TestContext.DataRow[1].ToString());
            Assert.AreEqual(expected, leetEasy.Leet292_CanWinNim(N));
        }

        [TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "Leet258TestData.CSV",
                    "Leet258TestData#CSV",
                    DataAccessMethod.Sequential)]
        [DeploymentItem("Leet258TestData.CSV")]
        public void Leet258_AddDigitsTest()
        {
            LeetCodeEasySolution leetEasy = new LeetCodeEasySolution();
            int num = Int32.Parse(TestContext.DataRow[0].ToString());
            int expected = Int32.Parse(TestContext.DataRow[1].ToString());
            Assert.AreEqual(expected, leetEasy.Leet258_AddDigits(num));
        }
    }
}
