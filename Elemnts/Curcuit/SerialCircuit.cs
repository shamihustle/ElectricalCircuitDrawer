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
        public event EventHandler CircuitChanged;
        
        /// <summary>
        /// Список компонентов
        /// </summary>
        public List<IComponent> Components
        {
            get { return _components; }
            set
            {
                _components = value;
                CircuitChanged?.Invoke(this, new EventArgs());

            }
        }
        
        /// <summary>
        /// Уникальное имя соединения
        /// </summary>
        //TODO проверка на string.Empty
        public string Name { get; } = "Serial circuit";
        
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
            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Удалить из списка
        /// </summary>
        /// <param name="component">Компонент</param>
        public void Remove(IComponent component)
        {
        //TODO Проверка _component на == null
            _components.Remove(component);
            CircuitChanged?.Invoke(this, new EventArgs());
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
        public void ModifyComponent(IElement componentOld, IElement componentNew, ICircuit mainCircuit)
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
                        mainCircuit.CircuitChanged += OnCircuitChanged;
                        break;
                    }
                }
                if (component is ICircuit)
                {
                    var circuit = (ICircuit)component;
                    circuit.ModifyComponent(componentOld, componentNew, mainCircuit);
                }
            }
            CircuitChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveComponent(IElement element, ICircuit mainCircuit)
        {
            foreach (var component in _components)
            {
                if (component is IElement)
                {
                    var el = (IElement)component;
                    if (el == element)
                    {
                        _components.Remove(el);
                        mainCircuit.CircuitChanged += OnCircuitChanged;
                        break;
                    }
                }
                if (component is ICircuit)
                {
                    var circuit = (ICircuit)component;
                    circuit.RemoveComponent(element, mainCircuit);
                }
            }
            CircuitChanged?.Invoke(this, EventArgs.Empty);

        }

        public void ModifyCircuit(ICircuit componentOld, ICircuit componentNew, ICircuit mainCircuit)
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
                        if (mainCircuit.Components != _components)
                        {
                            mainCircuit.CircuitChanged += OnCircuitChanged;
                        }
                        break;
                    }
                    el.ModifyCircuit(componentOld, componentNew, mainCircuit);
                }
            }
            CircuitChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveCircuit(ICircuit components, ICircuit mainCircuit)
        {
            foreach (var component in _components)
            {
                if (component is ICircuit)
                {
                    var el = (ICircuit)component;
                    if (el == components)
                    {
                        _components.Remove(el);
                        if (mainCircuit.Components != _components)
                        {
                            mainCircuit.CircuitChanged += OnCircuitChanged;
                        }
                        break;
                    }
                    el.RemoveCircuit(components, mainCircuit);
                }
            }
            CircuitChanged?.Invoke(this, EventArgs.Empty);
        }

        public void OnCircuitChanged(object sender, EventArgs args)
        {
            CircuitChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
