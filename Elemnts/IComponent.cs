using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Elemnts
{
    /// <summary>
    /// Общий интерфейс
    /// </summary>
    public interface IComponent
    {

        /// <summary>
        /// Имя компонента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns>Комплексное сопротивление</returns>
        Complex CalculateZ(double angularFrequency);
        
        
    }
}
