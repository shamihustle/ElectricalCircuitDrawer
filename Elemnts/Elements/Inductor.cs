using System;
using System.Numerics;
using Elements.Elements;

namespace Elemnts.Elements
{
    /// <summary>
    /// Индуктивный элемент
    /// </summary>
    public class Inductor : IElement
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"></param>
        public Inductor(double value)
        {
            _value = value;
        }

        public Inductor()
        {
        }

        private string _name;

        private double _value;

        /// <summary>
        /// Имя элемента
        /// </summary>
        public string Name
        {
            get { return "Inductor"; }
        }

        /// <summary>
        /// Индуктивность
        /// </summary>
        public double Value
        {
            get { return _value; }

            set { _value = ValueChecker.CheckValue(value); }
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
