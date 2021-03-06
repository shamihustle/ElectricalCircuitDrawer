﻿using System;
using System.Numerics;

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
        /// Электроёмкость конденсатора
        /// </summary>
        public double Value
        {
            get { return _value; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(@"The electrical capacity must be greater than zero");
                }
                _value = value;
            }
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
