using System;
using System.Numerics;

namespace Elemnts.Elements
{
    /// <summary>
    /// Индуктивный элемент
    /// </summary>
    public class Inductor : IElement
    {
        public event EventHandler ValueChanged;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"></param>
        public Inductor(double value)
        {
            _value = value;
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
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Рассчет комплексного индуктивного элемента
        /// </summary>
        /// <param name="angularFrequency">Угловая частота</param>
        /// <returns>Комплексное сопротивление индуктивного элемента</returns>
        public Complex CalculateZ(double angularFrequency)
        {
            return new Complex(0, 2*Math.PI*angularFrequency*_value);
        }
    }
}
