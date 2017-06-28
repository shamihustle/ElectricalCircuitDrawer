using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Elemnts.Elements;

namespace Elemnts.Curcuit
{
    /// <summary>
    /// Последовательное соединение
    /// </summary>
    public class SerialCircuit : ICircuit
    {
        //TODO xml комментарий
        public List<IComponent> Components
        {
            get { return _components; }
            set { _components = value; }
        }

        /// <summary>
        /// Уникальное имя соединения
        /// </summary>
        //TODO проверка на string.Empty
        public string Name { get; set; }
        
        /// <summary>
        /// Список компонентов в соединении
        /// </summary>
        private List<IComponent> _components = new List<IComponent>();

        /// <summary>
        /// Добавить в список
        /// </summary>
        /// <param name="component">Компонент</param>
        public void Add(IComponent component)
        {
        //TODO Проверка _component на == null
            _components.Add(component);
        }
        
        /// <summary>
        /// Удалить из списка
        /// </summary>
        /// <param name="component">Компонент</param>
        public void Remove(IComponent component)
        {
        //TODO Проверка _component на == null
            _components.Remove(component);
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns>Уомплексное сопротивление цепи последоватенльно соединения</returns>
        public Complex CalculateZ(double angularFrequency)
        {
        //TODO Проверка double переменной на == double.NaN, double.Infinity и <= 0
            Complex сonduction = new Complex();

            for (int i = 0; i < _components.Count; i++)
            {
                сonduction += _components[i].CalculateZ(angularFrequency);
            }

            return сonduction;
        }
        
        //TODO xml комментарий
        public void ModifyComponent(IComponent componentOld, IComponent componentNew)
        {
            if (componentOld is IElement)
            {
                componentNew = componentOld;
            }
            if (componentOld is ICircuit)
            {
                if (componentOld is SerialCircuit)
                {
                    var subcircuitSerial = (SerialCircuit)componentOld;
                    ModifyComponent(subcircuitSerial, componentNew);
                }
                if (componentOld is ParallelCircuit)
                {
                    var subcircuitParallel = (ParallelCircuit)componentOld;
                    ModifyComponent(subcircuitParallel, componentNew);
                }
            }
        }
    }
}
