using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements.Elements;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class ValueCheckerTest
    {
        /// <summary>
        /// Тестирование класса ValueChecker
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1, ExpectedResult = 1, TestName = "Testing Count for Assignment 1")]
        [TestCase(-1, ExpectedException = typeof(ArgumentException), TestName = "Testing Count for Assignment -1")]
        [TestCase(0, ExpectedResult = 0, TestName = "Testing Count for Assignment 0")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(ArgumentException),
            TestName = "Testing Count for Assignment PositiveInfifnity")]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException),
            TestName = "Testing Count for Assignment NaN")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException),
            TestName = "Testing Count for Assignment NegativeInfinity")]
        public double ValueCheckTest(double value)
        {
            return ValueChecker.CheckValue(value);

        }
    }
}
