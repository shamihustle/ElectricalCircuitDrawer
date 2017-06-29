using System.Drawing;
using Elemnts;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View.Draw
{
    public static class СircuitDraw
    {
        /// <summary>
        /// Отрисовывает цепь с последывательным соединением
        /// </summary>
        /// <param name="serial">Цепь</param>
        /// <returns>Рисунок</returns>
        public static Bitmap DrawComponent(SerialCircuit serial)
        {
            var size = SizeDeterminator.GetSize(serial);
            var bitMap = new Bitmap(size.Item1,size.Item2);
            int x = 0;
            
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                foreach (IComponent component in serial.Components)
                {
                    if (component is IElement)
                    {
                        var element = (IElement)component;
                        var elementBitMap = DrawComponent(element);
                        g.DrawLine(Pens.Black, x, size.Item2/2, x + 20, size.Item2 / 2);
                        g.DrawImage(elementBitMap, new Point(x + 20, size.Item2 / 2 - 10));
                        g.DrawLine(Pens.Black, x + 60, size.Item2 / 2, x + 90, size.Item2 / 2);
                        x += 90;
                    }
                    else if (component is ICircuit)
                    {
                        var circuitComponent = (ICircuit) component;
                        var circuitBitMap = new Bitmap(1, 1);
                        if (circuitComponent is SerialCircuit)
                        {
                            var serialSubcircuit = (SerialCircuit) circuitComponent;
                            circuitBitMap = DrawComponent(serialSubcircuit);
                        }
                        if (circuitComponent is ParallelCircuit)
                        {
                            var parallelSubcircuit = (ParallelCircuit) circuitComponent;
                            circuitBitMap = DrawComponent(parallelSubcircuit);
                        }
                        g.DrawImage(circuitBitMap, new Point(x, size.Item2 / 2 - circuitBitMap.Height / 2));
                        x += SizeDeterminator.GetSize(circuitComponent).Item1;
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
        public static Bitmap DrawComponent(ParallelCircuit parallel)
        {
            var size = SizeDeterminator.GetSize(parallel);
            var bitMapMainCircuit = new Bitmap(size.Item1,size.Item2);
            int x = 20;
            int y = 0;
            var nesting = false;
            using (Graphics g = Graphics.FromImage(bitMapMainCircuit))
            {
                g.DrawLine(Pens.Black, 0, size.Item2 / 2, 20, size.Item2 / 2);
                for (int i = 0; i < parallel.Components.Count; i++)
                {
                    if (parallel.Components[i] is SerialCircuit)
                    {
                        nesting = true;
                    }
                }
                if (nesting && parallel.Components.Count < 3)
                {
                    g.DrawLine(Pens.Black, x, y + 50 , x, size.Item2 - 50);
                }
                if (!nesting || parallel.Components.Count >= 3)
                {
                    g.DrawLine(Pens.Black, x, y + 25, x, size.Item2 - 25);
                }
                foreach (var component in parallel.Components)
                {
                    if (component is IElement)
                    {
                        var element = (IElement) component;
                        var bitmapElement = DrawComponent(element);
                        g.DrawLine(Pens.Black, x, y + bitmapElement.Height / 2, x + 20, y + bitmapElement.Height / 2);
                        g.DrawImage(bitmapElement, new Point(x + 20, y + 15));
                        g.DrawLine(Pens.Black, x + bitmapElement.Width + 10, y + bitmapElement.Height / 2, bitMapMainCircuit.Width - 8, y + bitmapElement.Height / 2);
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
                        }
                        if (circuit is ParallelCircuit)
                        {
                            var parallelSubcircuit = (ParallelCircuit) circuit;
                            bitmapCircuit = DrawComponent(parallelSubcircuit);
                        }
                        g.DrawImage(bitmapCircuit, new Point(x, y));
                        g.DrawLine(Pens.Black, x + bitmapCircuit.Width, y + bitmapCircuit.Height / 2, bitMapMainCircuit.Width - 8, y + bitmapCircuit.Height / 2);
                        y += bitmapCircuit.Height;
                    }
                }
                if (nesting && parallel.Components.Count < 3)
                {
                    g.DrawLine(Pens.Black, bitMapMainCircuit.Width - 8, 50, bitMapMainCircuit.Width - 8, size.Item2 - 50);
                }
                if (!nesting || parallel.Components.Count >= 3)
                {
                    g.DrawLine(Pens.Black, bitMapMainCircuit.Width - 8, 25, bitMapMainCircuit.Width - 8, size.Item2 - 25);
                }

                g.DrawLine(Pens.Black, bitMapMainCircuit.Width - 8, bitMapMainCircuit.Height / 2, bitMapMainCircuit.Width, bitMapMainCircuit.Height / 2);
            }
            return bitMapMainCircuit;
        }

        /// <summary>
        /// Отрисовывает пассивный элемент
        /// </summary>
        /// <param name="element">Пассивный элемент</param>
        /// <returns>Рисунок</returns>
        public static Bitmap DrawComponent(IElement element)
        {
            if (element is Resistor)
            {
                var bitMap = new Bitmap(50, 50);
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    g.DrawRectangle(Pens.Black, 0, 0, 40, 20);
                }
                return bitMap;
            }
            if (element is Capacitor)
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
            if (element is Inductor)
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
            return null;
        }
    }
}
