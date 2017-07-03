using System;
using System.Numerics;
using Elements.Elements;

namespace Elemnts.Elements
{
    /// <summary>
    /// Конденсатор
    /// </summary>
    public class Capacitor : IElement
    {
        /// <summary>
        /// Конструктор конденсатора
        /// </summary>
        /// <param name="value"></param>
        public Capacitor(double value)
        {
            _value = value;
        }

        public Capacitor()
        {
        }

        private string _name; 
        
        private double _value;

        /// <summary>
        /// Имя элемента
        /// </summary>
        public string Name
        {
            get { return "Capacitor"; }
        }

        /// <summary>
        /// Электроёмкость конденсатора
        /// </summary>
        public double Value
        {
            get { return _value; }

            set { _value = ValueChecker.CheckValue(value); }
        }

        /// <summary>
        /// Расчет комплексного сопротивления конденстора
        /// </summary>
        /// <param name="angularFrequency">Угловая частота</param>
        /// <returns>Комплексное сопротивление конденсатора</returns>
        public Complex CalculateZ(double angularFrequency)
        {
            return new Complex(0, -1/(2*Math.PI*angularFrequency*_value));
        }
    }
}
