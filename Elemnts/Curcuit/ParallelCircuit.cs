using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts.Curcuit
{
    /// <summary>
    /// Параллельное соединение
    /// </summary>
    public class ParallelCircuit : ICircuit
    {
        /// <summary>
        /// Уникальное имя соединения
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Список компонентов в соединении
        /// </summary>
        private List<IComponent> _components  = new List<IComponent>();

        /// <summary>
        /// Добавить в список
        /// </summary>
        /// <param name="component">Компонент</param>
        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        /// <summary>
        /// Удалить из списка
        /// </summary>
        /// <param name="component">Компонент</param>
        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        /// <summary>
        /// Рассчет комплексного сопротивления 
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns>Компексное сопротивление цепи параллельного соединения</returns>
        public Complex CalculateZ(double angularFrequency)
        {
            Complex result = new Complex();

            for (int i = 0; i < _components.Count; i++)
            {
                result += 1 / _components[i].CalculateZ(angularFrequency);
            }
            
            return 1 / result;
        }


    }
}
