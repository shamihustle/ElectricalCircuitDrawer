using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Elements.Curcuit;
using Elemnts.Elements;

namespace Elemnts.Curcuit
{
    /// <summary>
    /// Последовательное соединение
    /// </summary>
    public class SerialCircuit : CircuitBase
    {
        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns>Уомплексное сопротивление цепи последоватенльно соединения</returns>
        public override Complex CalculateZ(double angularFrequency)
        {
        //TODO Проверка double переменной на == double.NaN, double.Infinity и <= 0
            Complex сonduction = new Complex();

            for (int i = 0; i < Components.Count; i++)
            {
                сonduction += Components[i].CalculateZ(angularFrequency);
            }

            return сonduction;
        }

        public override string Name { get; } = "Serial Circuit";
    }
}
