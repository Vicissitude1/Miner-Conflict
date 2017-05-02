using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalc;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTset
    {
        [TestMethod]
        public void TestAdd()
        {
            Calculator c = new MyCalc.Calculator();
            int a = 3;
            int b = 5;
            int result = c.Add(a, b);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestSubtract()
        {
            Calculator c = new MyCalc.Calculator();
            int a = 3;
            int b = 5;
            int result = c.Subtract(a, b);
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void TestMultiply()
        {
            Calculator c = new MyCalc.Calculator();
            int a = 3;
            int b = 5;
            int result = c.Multiply(a, b);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestDivide()
        {
            Calculator c = new MyCalc.Calculator();
            float a = 3;
            float b = 5;
            float result = c.Divide(a, b);
            Assert.AreEqual(a/b, result);
        }

    }
}
