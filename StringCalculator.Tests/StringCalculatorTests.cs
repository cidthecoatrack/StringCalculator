using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace StringCalculatorKata.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator Calculator;
        
        [TestInitialize]
        public void Setup()
        {
            Calculator = new StringCalculator();
        }
        
        [TestMethod]
        public void EmptyString_Zero()
        {
            Assert.AreEqual(0, Calculator.Add(""));
        }

        [TestMethod]
        public void OneNumber_Itself()
        {
            Assert.AreEqual(1, Calculator.Add("1"));
        }

        [TestMethod]
        public void TwoNumbers_TheSum()
        {
            Assert.AreEqual(3, Calculator.Add("1,2"));
        }

        [TestMethod]
        public void FiveNumbers_TheSum()
        {
            Assert.AreEqual(25, Calculator.Add("5,5,5,5,5"));
        }

        [TestMethod]
        public void NewLineAsDelimiter_StillSumAddends()
        {
            Assert.AreEqual(6, Calculator.Add("1\n2,3"));
        }

        [TestMethod]
        public void CreatingCustomDelimiter_AllowDelimiterInAddendsString()
        {
            Assert.AreEqual(3, Calculator.Add("//;\n1,2"));
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void NegativeNumbers_ThrowExceptionNegativesNotAllowed()
        {
            Calculator.Add("-1");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InvalidNumbers_ShouldBeIncludedInException()
        {
            try
            {
                Calculator.Add("1,-2,-7");
            }
            catch (ArgumentException exception)
            {
                Assert.IsTrue(exception.Message.Contains("-2"));
                Assert.IsTrue(exception.Message.Contains("-7"));
                throw new ArgumentException();
            }
        }

        [TestMethod]
        public void DashAsDelimiter_ShouldWorkFine()
        {
            Assert.AreEqual(6, Calculator.Add("//-\n1-2-3"));
        }
    }
}
