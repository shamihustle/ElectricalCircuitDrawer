using System;
using System.Numerics;

namespace Elemnts.Elements
{
    /// <summary>
    /// Резистор
    /// </summary>
    public class Resistor : IElement
    {
        public event EventHandler ValueChanged;

        /// <summary>
        /// Конструктор резистора
        /// </summary>
        /// <param name="value">Сопротивление</param>
        public Resistor(double value)
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
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Рассчет комплексного сопротивления резистора
        /// </summary>
        /// <param name="angularFrequency">Угловая частота</param>
        /// <returns>Комплексное сопротивление резистора</returns>
        public Complex CalculateZ(double angularFrequency)
        {
            return new Complex(_value ,0);
        }
        
    }
}
