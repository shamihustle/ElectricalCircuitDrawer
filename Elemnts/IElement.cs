using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts
{
    public interface IElement
    {
        /// <summary>
        /// Уникальное имя элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Значение номинала
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Рассчет комплексного сопротивления элемента
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns></returns>
        Complex CalculateZ(double angularFrequency);
    }
}
