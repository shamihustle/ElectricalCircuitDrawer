using System;
using System.Collections.Generic;
using System.Drawing;
using Elemnts;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View.Draw
{
    public static class СircuitDrawer
    {
        const int _inputLineElement = 20;

        const int _outputLineElement = 20;

        const int _outputLineCircuit = 10;

        /// <summary>
        /// Определяет размер компонента
        /// </summary>
        private static class SizeDeterminator
        {
            /// <summary>
            /// Размер
            /// </summary>
            public struct Size
            {
                public Size(int width, int height)
                {
                    _height = height;
                    _width = width;
                }
                
                
                private int _width;
                private int _height;

                public int Width
                {
                    get { return _width; }
                    set
                    {
                        if (value < 0)
                        {
                            throw new ArgumentException(@"Error with width");
                        }
                        _width = value;
                    }
                }

                public int Height
                {
                    get { return _height; }
                    set
                    {
                        if (value < 0)
                        {
                            throw new ArgumentException(@"Error with height");
                        }
                        _height = value;
                    }
                }
            }
            
            /// <summary>
            /// Вычисляет размер рисунка цепи с последовательным соединением
            /// </summary>
            /// <param name="circuitBase">Цепь с последовательным соединением</param>
            /// <returns>Размер</returns>
            private static Size GetSize(SerialCircuit circuitBase)
            {
                var size = new Size(0,0);
                foreach (IComponent component in circuitBase.Components)
                {
                    if (component is IElement)
                    {
                        var element = (IElement) component;
                        var elementSize = GetSize(element);
                        if (size.Height < elementSize.Height)
                        {
                            size.Height = elementSize.Width;
                        }
                        size.Width += (elementSize.Width + _inputLineElement + _outputLineElement);
                    }
                    else if (component is SerialCircuit)
                    {
                        var serial = (SerialCircuit)component;
                        var serialCircuitSize = GetSize(serial);
                        if (size.Height < serialCircuitSize.Height)
                        {
                            size.Height = serialCircuitSize.Height;
                        }
                        size.Width += serialCircuitSize.Width;
                    }
                    else if (component is ParallelCircuit)
                    {
                        var parallel = (ParallelCircuit)component;
                        var parallelCircuitSize = GetSize(parallel);
                        if (size.Height < parallelCircuitSize.Height)
                        {
                            size.Height = parallelCircuitSize.Height;
                        }
                        size.Width += parallelCircuitSize.Width;
                    }
                }
                return size;
            }

            /// <summary>
            /// Размер рисунка цепи с параллельным соединением
            /// </summary>
            /// <param name="circuitBase">Цепь с параллельным соединением</param>
            /// <returns>Размер</returns>
            private static Size GetSize(ParallelCircuit circuitBase)
            {
                var size = new Size(0,0);

                foreach (var component in circuitBase.Components)
                {
                    if (component is IElement)
                    {
                        var element = (IElement) component;
                        var elementSize = GetSize(element);
                        size.Height += elementSize.Height;
                        if (size.Width < elementSize.Width)
                        {
                            size.Width = elementSize.Width;
                        }
                    }
                    else if (component is SerialCircuit)
                    {
                        var serial = (SerialCircuit)component;
                        var serialCircuitSize = GetSize(serial);
                        if (size.Width < serialCircuitSize.Width)
                        {
                            size.Width = serialCircuitSize.Width;
                        }
                        size.Height += serialCircuitSize.Height;
                    }
                    else if (component is ParallelCircuit)
                    {
                        var parallel = (ParallelCircuit)component;
                        var parallelCircuitSize = GetSize(parallel);
                        if (size.Width < parallelCircuitSize.Width)
                        {
                            size.Width = parallelCircuitSize.Width;
                        }
                        size.Height += parallelCircuitSize.Height;
                    }
                }
                size.Width += 50;
                return size;
            }

            /// <summary>
            /// Возвращает размер элемента
            /// </summary>
            /// <param name="element"></param>
            /// <returns></returns>
            private static Size GetSize(IElement element)
            {
                return new Size(50,50);
            }

            /// <summary>
            /// Определяет цепь
            /// </summary>
            /// <param name="component">Параллельная или последовательная цепь</param>
            /// <returns>Размер</returns>
            public static Size GetSize(IComponent component)
            {
                if (component is SerialCircuit)
                {
                    var circuit = (SerialCircuit)component;
                    return GetSize(circuit);
                }
                if (component is ParallelCircuit)
                {
                    var circuit = (ParallelCircuit)component;
                    return GetSize(circuit);
                }
                if (component is IElement)
                {
                    var element = (IElement) component;
                    return GetSize(element);
                }
                throw new ArgumentException(@"Error with size");
            }
        }

        /// <summary>
        /// Отрисовывает цепь с последывательным соединением
        /// </summary>
        /// <param name="serial">Цепь</param>
        /// <returns>Рисунок</returns>
        private static Bitmap DrawComponent(SerialCircuit serial)
        {
            var size = SizeDeterminator.GetSize(serial);
            var bitMap = new Bitmap(size.Width,size.Height);
            int x = 0;
            
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                foreach (IComponent component in serial.Components)
                {
                    if (component is IElement)
                    {
                        var element = (IElement)component;
                        var elementBitMap = DrawComponent(element);
                        g.DrawLine(Pens.Black, x, size.Height/2, x + _inputLineElement, size.Height / 2);
                        g.DrawImage(elementBitMap, new Point(x + _inputLineElement, size.Height / 2 - _inputLineElement/2));
                        g.DrawLine(Pens.Black, x + 60, size.Height / 2, x + SizeDeterminator.GetSize(element).Height + _inputLineElement + _outputLineElement, size.Height / 2);
                        x += (SizeDeterminator.GetSize(element).Height + _inputLineElement + _outputLineElement);
                    }
                    else if (component is ICircuit)
                    {
                        var circuitComponent = (ICircuit) component;
                        var circuitBitMap = new Bitmap(1, 1);
                        circuitBitMap = DrawComponent(circuitComponent);
                        g.DrawImage(circuitBitMap, new Point(x, size.Height / 2 - circuitBitMap.Height / 2));
                        //TODO: GetSize isnot need
                        x += SizeDeterminator.GetSize(circuitComponent).Width;
                    }
                }
            }
            return bitMap;
        }
        
        
        /// <summary>
        /// Отрисовывает цепь параллельного соединения
        /// </summary>
        /// <param name="parallel">Цепь</param>
        /// <returns>Рисунок</returns>
        private static Bitmap DrawComponent(ParallelCircuit parallel)
        {
            var size = SizeDeterminator.GetSize(parallel);
            List<Bitmap> bitMapList = new List<Bitmap>();
            var bitMapMainCircuit = new Bitmap(size.Width,size.Height);
            bitMapList.Add(bitMapMainCircuit);
            int x = _inputLineElement;
            int y = 0;
            using (Graphics g = Graphics.FromImage(bitMapMainCircuit))
            {
                g.DrawLine(Pens.Black, 0, size.Height / 2, _inputLineElement, size.Height / 2);
                
                if (parallel.Components[1] is ICircuit)
                {
                    g.DrawLine(Pens.Black, x, y + SizeDeterminator.GetSize(parallel.Components[0]).Height / 2, x, size.Height - SizeDeterminator.GetSize(parallel.Components[1]).Height / 2);
                }
                g.DrawLine(Pens.Black, x, y + SizeDeterminator.GetSize(parallel.Components[0]).Height / 2, x, size.Height - SizeDeterminator.GetSize(parallel.Components[0]).Height / 2);
                
                foreach (var component in parallel.Components)
                {
                    if (component is IElement)
                    {
                        var element = (IElement) component;
                        var bitmapElement = DrawComponent(element);
                        g.DrawLine(Pens.Black, x, y + bitmapElement.Height / 2, x + _inputLineElement, y + bitmapElement.Height / 2);
                        g.DrawImage(bitmapElement, new Point(x + 20, y + 15));
                        g.DrawLine(Pens.Black, x + bitmapElement.Width + _inputLineElement/2, y + bitmapElement.Height / 2, bitMapMainCircuit.Width - _outputLineCircuit, y + bitmapElement.Height / 2);
                        y += bitmapElement.Height;
                    }
                    if (component is ICircuit)
                    {
                        var circuit = (ICircuit) component;
                        var bitmapCircuit = new Bitmap(1, 1);
                        if (circuit is SerialCircuit)
                        {
                            var serialSubcircuit = (SerialCircuit) circuit;
                            bitmapCircuit = DrawComponent(serialSubcircuit);
                            bitMapList.Add(bitmapCircuit);
                        }
                        if (circuit is ParallelCircuit)
                        {
                            var parallelSubcircuit = (ParallelCircuit) circuit;
                            bitmapCircuit = DrawComponent(parallelSubcircuit);
                            bitMapList.Add(bitmapCircuit);
                        }
                        g.DrawImage(bitmapCircuit, new Point(x, y));
                        g.DrawLine(Pens.Black, x + bitmapCircuit.Width, y + bitmapCircuit.Height / 2, bitMapMainCircuit.Width - _outputLineCircuit, y + bitmapCircuit.Height / 2);
                        y += bitmapCircuit.Height;
                    }
                }
                if (parallel.Components[0] is ICircuit)
                {
                    g.DrawLine(Pens.Black, bitMapMainCircuit.Width - _outputLineCircuit, SizeDeterminator.GetSize(parallel.Components[0]).Height / 2, bitMapMainCircuit.Width - _outputLineCircuit, size.Height - SizeDeterminator.GetSize(parallel.Components[1]).Height / 2);
                }
                else
                {
                    g.DrawLine(Pens.Black, bitMapMainCircuit.Width - _outputLineCircuit, SizeDeterminator.GetSize(parallel.Components[0]).Height / 2, bitMapMainCircuit.Width - _outputLineCircuit, size.Height - SizeDeterminator.GetSize(parallel.Components[0]).Height / 2);
                }
                g.DrawLine(Pens.Black, bitMapMainCircuit.Width - _outputLineCircuit, bitMapMainCircuit.Height / 2, bitMapMainCircuit.Width, bitMapMainCircuit.Height / 2);
            }
            return bitMapMainCircuit;
        }

        /// <summary>
        /// Определяет какой компонент надо отрисовать
        /// </summary>
        /// <param name="component">Компонент</param>
        /// <returns>Рисунок компонента</returns>
        public static Bitmap DrawComponent(IComponent component)
        {
            if (component is ICircuit)
            {
                if (component is SerialCircuit)
                {
                    var serial = (SerialCircuit)component;
                    return DrawComponent(serial);
                }
                if (component is ParallelCircuit)
                {
                    var parallel = (ParallelCircuit)component;
                    return DrawComponent(parallel);
                }
            }
            if (component is IElement)
            {
                if (component is Resistor)
                {
                    var resistor = (Resistor)component;
                    return DrawComponent(resistor);
                }
                if (component is Capacitor)
                {
                    var capacitor = (Capacitor)component;
                    return DrawComponent(capacitor);
                }
                if (component is Inductor)
                {
                    var inductor = (Inductor)component;
                    return DrawComponent(inductor);
                }
            }
            throw new ArgumentException(@"Error with argemnts");
        }
        
        /// <summary>
        /// Отрисовка резистора
        /// </summary>
        /// <param name="resistor"></param>
        /// <returns>Рисунок резистора</returns>
        private static Bitmap DrawComponent(Resistor resistor)
        {
            var bitMap = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                g.DrawRectangle(Pens.Black, 0, 0, 40, 20);
            }
            return bitMap;
        }

        /// <summary>
        /// Отрисовка конденсатора
        /// </summary>
        /// <param name="capacitor"></param>
        /// <returns>Писунок конденсатора</returns>
        private static Bitmap DrawComponent(Capacitor capacitor)
        {
            var bitMap = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                g.DrawLine(Pens.Black, 0, 10, 10, 10);
                g.DrawLine(Pens.Black, 10, 0, 10, 20);
                g.DrawLine(Pens.Black, 30, 0, 30, 20);
                g.DrawLine(Pens.Black, 30, 10, 40, 10);
            }
            return bitMap;
        }

        /// <summary>
        /// Отрисовка катушки индуктивности 
        /// </summary>
        /// <param name="inductor"></param>
        /// <returns>Рисунок катушки</returns>
        private static Bitmap DrawComponent(Inductor inductor)
        {
            var bitMap = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                for (int i = 0; i < 4; i++)
                {
                    g.DrawArc(Pens.Black, i * 10, 5, 10, 10, 0, -180);
                }
            }
            return bitMap;
        }
    }
}
