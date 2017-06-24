using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elemnts
{
    public class Inductor : IElement
    {
        public Inductor(double value)
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
        /// Индуктивность
        /// </summary>
        public double Value
        {
            get { return _value; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(@"The inductance must be greater than zero");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Рассчет комплексного индуктивного элемента
        /// </summary>
        /// <param name="angularFrequency">Угловая частота</param>
        /// <returns></returns>
        public Complex CalculateZ(double angularFrequency)
        {
            return new Complex(0, 2*Math.PI*angularFrequency*_value);
        }
    }
}
