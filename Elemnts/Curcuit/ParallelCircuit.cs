﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Elemnts.Elements;

namespace Elemnts.Curcuit
{
    /// <summary>
    /// Параллельное соединение
    /// </summary>
    public class ParallelCircuit : ICircuit
    {
        public event EventHandler CircuitChanged;

        public List<IComponent> Components
        {
            get { return _components; }
            set { _components = value; }
        }

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
        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        /// <summary>
        /// Удалить из списка
        /// </summary>
        /// <param name="component">Компонент</param>
        public void Remove(IComponent component)
        {
            _components.Remove(component);
        }

        /// <summary>
        /// Рассчет комплексного сопротивления 
        /// </summary>
        /// <param name="angularFrequency">Частота сигнала</param>
        /// <returns>Комплексное сопротивление цепи параллельного соединения</returns>
        public Complex CalculateZ(double angularFrequency)
        {
            Complex сonduction = new Complex();

            for (int i = 0; i < _components.Count; i++)
            {
                сonduction += 1 / _components[i].CalculateZ(angularFrequency);
            }
            
            return 1 / сonduction;
        }

        public void ModifyComponent(IComponent componentOld, IComponent componentNew)
        {
            if (componentOld is IElement)
            {
                componentOld = componentNew;
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
