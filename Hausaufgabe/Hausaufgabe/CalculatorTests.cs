using System;
using Hausaufgabe;
using NUnit.Framework;

namespace Tests
{
    public class CalculatorTests
    {
        [Test]
        public void GivenEmptyString_WhenAdd_ThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add(string.Empty));
        }

        [Test]
        public void GivenNull_WhenAdd_ThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add(null));
        }

        [Test]
        [TestCase("5,1,7", ExpectedResult = 13)]
        [TestCase(@"5\n2,7", ExpectedResult = 14)]
        [TestCase(@"//wurst\n,5,3wurst7\n4", ExpectedResult = 19)]
        [TestCase("5", ExpectedResult = 5)]
        public int GivenValidCalculationString_WhenAdd_ThenReturnSum(string calcString)
        {
            return Calculator.Add(calcString);
        }

        [Test]
        [TestCase("-5,3,4")]
        [TestCase("-5")]
        public void GivenNegativeNumberInCalculationString_WhenAdd_ThenThrowArgumentException(string calcString)
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add(calcString));
        }
        [Test]
        public void GivenNumberGreaterThanIntMaxInCalculationString_WhenAdd_ThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add("12345678901234567890,3,4"));
        }

        [Test]
        public void GivenInvalidCustomDelimiterInCalculationString_WhenAdd_ThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add("//wurst,5,5,6"));
        }
    }
}
