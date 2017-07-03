using System;
using System.Numerics;
using Elements.Elements;

namespace Elemnts.Elements
{
    /// <summary>
    /// Резистор
    /// </summary>
    public class Resistor : IElement
    {

        /// <summary>
        /// Конструктор резистора
        /// </summary>
        /// <param name="value">Сопротивление</param>
        public Resistor(double value)
        {
            _value = value;
        }

        public Resistor()
        {
        }

        private string _name;

        private double _value;

        /// <summary>
        /// Имя элемента
        /// </summary>
        public string Name
        {
            get { return "Resistor"; }
        }

        /// <summary>
        /// Сопротивление резистора
        /// </summary>
        public double Value
        {
            get { return _value; }

            set { _value = ValueChecker.CheckValue(value); }
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
