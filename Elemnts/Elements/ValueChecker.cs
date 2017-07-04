using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Elements
{
    public static class ValueChecker
    {
        /// <summary>
        /// Проверка номинала элемента
        /// </summary>
        /// <param name="value">Номинал</param>
        /// <returns></returns>
        public static double CheckValue(double value)
        {
            if ((value >= 0) && (!double.IsNaN(value)) && (!double.IsPositiveInfinity(value)))
            {
                return value;
            }
            throw new ArgumentException("Элекстроемкость должна быть положительной, но не Nan и не PositiveInfinity ");
        }
    }
}
