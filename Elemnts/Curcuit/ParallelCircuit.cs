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
        public string Name { get; } = "Parallel circuit";
        
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

        public void ModifyComponent(IElement componentOld, IElement componentNew)
        {
            foreach (var component in _components)
            {
                if (component is IElement)
                {
                    var el = (IElement)component;
                    if (el == componentOld)
                    {
                        int index = _components.IndexOf(component);
                        _components.RemoveAt(index);
                        _components.Insert(index, componentNew);
                        break;
                    }
                }
                if (component is ICircuit)
                {
                    var circuit = (ICircuit)component;
                    circuit.ModifyComponent(componentOld, componentNew);
                }
            }
        }

        public void RemoveComponent(IElement element)
        {
            foreach (var component in _components)
            {
                if (component is IElement)
                {
                    var el = (IElement)component;
                    if (el == element)
                    {
                        _components.Remove(el);
                        break;
                    }
                }
                if (component is ICircuit)
                {
                    var circuit = (ICircuit)component;
                    circuit.RemoveComponent(element);
                }
            }
        }

        public void ModifyCircuit(ICircuit componentOld, ICircuit componentNew)
        {
            foreach (var component in _components)
            {
                if (component is ICircuit)
                {
                    var el = (ICircuit)component;
                    if (el == componentOld)
                    {
                        int index = _components.IndexOf(component);
                        _components.RemoveAt(index);
                        _components.Insert(index, componentNew);
                        break;
                    }
                    else
                    {
                        el.ModifyCircuit(componentOld, componentNew);
                    }
                }
            }
        }
    }
}
