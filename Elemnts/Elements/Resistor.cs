using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts
{
    public class Resistor : IElement
    {
        public Resistor(double value)
        {
            _value = value;
        }

        private List<IComponent> _components = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        private string _name;

        private double _value;

        /// <summary>
        /// Уникальное имя элемента
        /// </summary>
        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        /// <summary>
        /// Сопротивление резистора
        /// </summary>
        public double Value
        {
            get { return _value; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(@"The resistance must be greater than zero");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Рассчет комплексного сопротивления резистора
        /// </summary>
        /// <param name="angularFrequency">Угловая частота</param>
        /// <returns></returns>
        public Complex CalculateZ(double angularFrequency)
        {
            return new Complex(_value ,0);
        }
    }
}
