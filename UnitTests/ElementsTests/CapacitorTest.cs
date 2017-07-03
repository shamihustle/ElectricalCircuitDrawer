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
    /// Набор тестов для класса Capacitor
    /// </summary>
    [TestFixture]
    class CapacitorTest
    {
        [Test, TestCaseSource(nameof(ComplexValueTest))]
        public void GetImpedanceTest(double resultReal, double resulrImaginary, double angularFrequency, double value)
        {
            var capacitor = new Capacitor(value);
            var impedance = capacitor.CalculateZ(angularFrequency);

            Assert.AreEqual(resultReal, impedance.Real);
            Assert.AreEqual(resulrImaginary, impedance.Imaginary);
        }

        static readonly TestCaseData[] ComplexValueTest =
        {
            new TestCaseData(0, -1/(288*Math.PI), 12, 12), // Тестирование в позитивном ключе 
            new TestCaseData(0, -1/(Math.PI*2147.9) , 23.5, 45.7),
            new TestCaseData(0, -1/(Math.PI*4000) , 2, 1000)
        };

    }
}
