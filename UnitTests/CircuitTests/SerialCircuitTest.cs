using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elemnts.Curcuit;
using Elemnts.Elements;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Тестирование последовательного соединения
    /// </summary>
    class SerialCircuitTest
    {
        [Test, TestCaseSource(nameof(ComplexValueTest))]
        public void GetImpedanceTest(double resultReal, double resulrImaginary, double angularFrequency, IElement element1, IElement element2)
        {
            var serial = new SerialCircuit();
            serial.Add(element1);
            serial.Add(element2);
            var impedance = serial.CalculateZ(angularFrequency);

            Assert.AreEqual(resultReal, impedance.Real);
            Assert.AreEqual(resulrImaginary, impedance.Imaginary);
        }

        static readonly TestCaseData[] ComplexValueTest =
        {

        new TestCaseData(12, -1/(288*Math.PI), 12, new Resistor(12), new Capacitor(12)),
        new TestCaseData(1, -1/(2*Math.PI), 1, new Resistor(1), new Capacitor(1))
        };
    }
}
