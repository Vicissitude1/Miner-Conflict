using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HighLow;

namespace TestHighLow
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDiceRoll0()
        {
            bool dice;
            StaticDice d = new StaticDice(0);
            int result = d.Roll();
            if (result > 0)
            {
                dice = true;
            }
            else
            {
                dice = false;
            }
            Assert.IsFalse(dice);
        }

        [TestMethod]
        public void TestDiceRoll7()
        {
            bool dice;
            StaticDice d = new StaticDice(7);
            int result = d.Roll();
            if (result < 7)
            {
                dice = true;
            }
            else
            {
                dice = false;
            }
            Assert.IsFalse(dice);
        }

        [TestMethod]
        public void TestDiceRoll1()
        {
            StaticDice d = new StaticDice(1);
            int result = d.Roll();
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestDiceRoll2()
        {
            StaticDice d = new StaticDice(2);
            int result = d.Roll();
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void TestDiceRoll3()
        {
            StaticDice d = new StaticDice(3);
            int result = d.Roll();
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void TestDiceRoll4()
        {
            StaticDice d = new StaticDice(4);
            int result = d.Roll();
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestDiceRoll5()
        {
            StaticDice d = new StaticDice(5);
            int result = d.Roll();
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void TestDiceRoll6()
        {
            StaticDice d = new StaticDice(6);
            int result = d.Roll();
            Assert.AreEqual(6, result);
        }
    }
}
