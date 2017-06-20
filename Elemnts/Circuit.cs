using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts
{
    class Circuit
    {
        /// <summary>
        /// Список элементов электрической цепи
        /// </summary>
        public List<IElement> Elements;

        /// <summary>
        /// Рассчет комплексного сопротивления цепи
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns>Массив комплексных сопротивлений для разных частот</returns>
        public Complex[] CalculateZ(double[] angularFrequency)
        {
            Complex[] impedanceArray = new Complex[angularFrequency.Length];

            for (int i = 0; i < angularFrequency.Length; i++)
            {
                for (int j = 0; j < Elements.Count; i++)
                {
                    impedanceArray[i] += Elements[j].CalculateZ(angularFrequency[i]);
                }
            }
            return impedanceArray;
        }
    }
}
