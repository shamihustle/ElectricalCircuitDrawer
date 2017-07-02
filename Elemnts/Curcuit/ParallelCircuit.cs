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
    /// Параллельное соединение
    /// </summary>
    public class ParallelCircuit : CircuitBase
    {
        
        /// <summary>
        /// Рассчет комплексного сопротивления 
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns>Комплексное сопротивление цепи параллельного соединения</returns>
        public override Complex CalculateZ(double angularFrequency)
        {
            Complex сonduction = new Complex();

            for (int i = 0; i < Components.Count; i++)
            {
                сonduction += 1 / Components[i].CalculateZ(angularFrequency);
            }
            
            return 1 / сonduction;
        }
        public override string Name { get; } = "Parallel Circuit";
    }
}
