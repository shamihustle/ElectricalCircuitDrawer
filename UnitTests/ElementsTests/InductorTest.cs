using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elemnts.Elements;
using NUnit.Framework;

namespace UnitTests.ElementsTest
{
    /// <summary>
    /// Тестирование класса Inductor
    /// </summary>
    [TestFixture]
    class InductorTest
    {
        [Test, TestCaseSource(nameof(ComplexValueTest))]
        public void GetImpedanceTest(double resultReal, double resulrImaginary, double angularFrequency, double value)
        {
            var inductor = new Inductor(value);
            var impedance = inductor.CalculateZ(angularFrequency);

            Assert.AreEqual(resultReal, impedance.Real);
            Assert.AreEqual(resulrImaginary, impedance.Imaginary);
        }

        static readonly TestCaseData[] ComplexValueTest =
        {
        new TestCaseData(0, 288.0*Math.PI , 12, 12),
        new TestCaseData(0, 2*Math.PI, 1, 1)
        };
    }
}
