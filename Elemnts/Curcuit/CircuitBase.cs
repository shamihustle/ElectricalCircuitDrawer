using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Elemnts;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace Elements.Curcuit
{
    /// <summary>
    /// Базовый класс цепи
    /// </summary>
    public abstract class CircuitBase : ICircuit
    {
        /// <summary>
        /// Событие изменине цепи
        /// </summary>
        public event EventHandler CircuitChanged;

        /// <summary>
        /// Список компонентов
        /// </summary>
        public List<IComponent> Components
        {
            get { return _components; }
            set { _components = value; }
        }

        /// <summary>
        /// Имя соединения
        /// </summary>
        public virtual string Name { get; } = "";

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
            if (_components == null)
            {
                throw new ArgumentException(@"List is empty");
            }
            _components.Add(component);
        }

        /// <summary>
        /// Удалить из списка
        /// </summary>
        /// <param name="component">Компонент</param>
        public void Remove(IComponent component)
        {
            if (_components == null)
            {
                throw new ArgumentException(@"List is empty");
            }
            _components.Remove(component);
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns>Уомплексное сопротивление цепи последоватенльно соединения</returns>
        public virtual Complex CalculateZ(double frequency) => new Complex(0, 0);

        /// <summary>
        /// Изменить элемент
        /// </summary>
        /// <param name="componentOld">Элемент который надо изменить</param>
        /// <param name="componentNew">Элемент на который надо заменить</param>
        /// <param name="mainCircuit">Основная цепь</param>
        public void ModifyElement(IElement componentOld, IElement componentNew, ICircuit mainCircuit)
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
                        if (mainCircuit.Components != _components)
                        {
                            mainCircuit.CircuitChanged += OnCircuitChanged;
                        }
                        break;
                    }
                }
                if (component is ICircuit)
                {
                    var circuit = (ICircuit)component;
                    circuit.ModifyElement(componentOld, componentNew, mainCircuit);
                }
            }
            CircuitChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="element">Элемент, который нужно удалить</param>
        /// <param name="mainCircuit">Основная цепь</param>
        public void RemoveElement(IElement element, ICircuit mainCircuit)
        {
            foreach (var component in _components)
            {
                if (component is IElement)
                {
                    var el = (IElement)component;
                    if (el == element)
                    {
                        _components.Remove(el);
                        if (mainCircuit.Components != _components)
                        {
                            mainCircuit.CircuitChanged += OnCircuitChanged;
                        }
                        break;
                    }
                }
                if (component is ICircuit)
                {
                    var circuit = (ICircuit)component;
                    circuit.RemoveElement(element, mainCircuit);
                }
            }
            CircuitChanged?.Invoke(this, EventArgs.Empty);

        }

        /// <summary>
        /// Изменит элемент
        /// </summary>
        /// <param name="componentOld">Элемент который надо изменить</param>
        /// <param name="componentNew">Элемент на который надо заменить</param>
        /// <param name="mainCircuit">Основная цепь</param>
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

        /// <summary>
        /// Удалить цепь
        /// </summary>
        /// <param name="components">Цепь, которую надо удалить</param>
        /// <param name="mainCircuit">Основная цепь</param>
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

        /// <summary>
        /// Зажигание события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnCircuitChanged(object sender, EventArgs args)
        {
            CircuitChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
