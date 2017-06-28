using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Elemnts;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View.Draw
{
    public static class SubcircuitDraw
    {
        private static int x = 0;
        private static int y = 200;

        private static List<Bitmap> bitMapList = new List<Bitmap>(); 

        public static Bitmap CiruitDraw(IComponent component)
        {
            if (component is SerialCircuit)
            {
                var serialCircuit = (SerialCircuit) component;
                return SubCircuitDraw(serialCircuit);
            }
            if (component is ParallelCircuit)
            {
                var parallelCircuit = (ParallelCircuit) component;
                return SubCircuitDraw(parallelCircuit);
            }
            return null;
        }

        public static Bitmap SubCircuitDraw(SerialCircuit serial)
        {
            var bitMap = new Bitmap(_serialSize(serial).Item1,_serialSize(serial).Item2);
            

            using (Graphics g = Graphics.FromImage(bitMap))
            {
                foreach (IComponent component in serial.Components)
                {
                    if (component is IElement)
                    {
                        var element = (IElement)component;
                        var elementImage = ElementDraw.DrawElement(element);
                        g.DrawLine(Pens.Black, x, y, x + 20, y);
                        g.DrawImage(elementImage, new Point(x + 20, y - 10));
                        g.DrawLine(Pens.Black, x + 60, y, x + 90, y);
                        x += 90;
                    }
                    if (component is ICircuit)
                    { 
                        if (component is SerialCircuit)
                        {

                            var subcircuit = (SerialCircuit) component;

                            Bitmap bitMapSubcircuit = new Bitmap(_serialSize(subcircuit).Item1, _serialSize(subcircuit).Item2);

                            bitMapSubcircuit = SubCircuitDraw(subcircuit);

                            g.DrawImage(bitMapSubcircuit, new Point(x, y - 10));
                            

                        }
                        if (component is ParallelCircuit)
                        {
                            var subcircuit = (ParallelCircuit) component;

                            Bitmap bitMapSubcircuit = new Bitmap(_parallelSize(subcircuit).Item1, _parallelSize(subcircuit).Item2);

                            bitMapSubcircuit = SubCircuitDraw(subcircuit);

                            g.DrawImage(bitMapSubcircuit, new Point(x - 110, y - 200)); // ?????????
                            
                        }
                    }
                }
            }
            return bitMap;
        }

        public static Bitmap SubCircuitDraw(ParallelCircuit parallel)
        {
            var bitMap = new Bitmap(1000,1000);
            
            var countConnection = parallel.Components.Count;
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                g.DrawLine(Pens.Black, x, y, x + 20, y);
                x += 20;
                g.DrawLine(Pens.Black, x, y - countConnection*50, x, y + countConnection * 50);
                y += countConnection * 50;
                int i = 0;
                foreach (var components in parallel.Components)
                {
                    if (components is IElement)
                    {
                        var bitMapSubcircuit = ElementDraw.DrawElement(components);
                        g.DrawLine(Pens.Black, x, y, x + 20, y);
                        g.DrawImage(bitMapSubcircuit, x + 20, y - 10);
                        g.DrawLine(Pens.Black, x + 80, y, x + 60, y);
                        if (countConnection == 3)
                        {
                            y -= countConnection * 50;
                        }
                        if (countConnection == 2)
                        {
                            y -= 2*countConnection*50;
                        }
                    }
                    if (components is ICircuit)
                    { 
                        if (components is SerialCircuit)
                        {

                            var subcircuit = (SerialCircuit)components;

                            Bitmap bitMapSubcircuit = new Bitmap(_serialSize(subcircuit).Item1, _serialSize(subcircuit).Item2);

                            bitMapSubcircuit = SubCircuitDraw(subcircuit);

                            g.DrawImage(bitMapSubcircuit, new Point(x, y - 10));
                            

                        }
                        if (components is ParallelCircuit)
                        {
                            var subcircuit = (ParallelCircuit)components;

                            Bitmap bitMapSubcircuit = new Bitmap(_parallelSize(subcircuit).Item1, _parallelSize(subcircuit).Item2);

                            bitMapSubcircuit = SubCircuitDraw(subcircuit);

                            g.DrawImage(bitMapSubcircuit, new Point(x, y));
                            
                        }

                    }
                    
                    i++;
                }
                if (countConnection == 2)
                {
                    y += 2*countConnection*50;
                }
                if (countConnection == 3)
                {
                    y += countConnection*50;
                }
                g.DrawLine(Pens.Black, x + 80, y, x + 80 ,y + 2*countConnection*50);
                g.DrawLine(Pens.Black, x + 80, (y + 2 * countConnection * 50)/2, x + 100, (y + 2 * countConnection * 50) / 2);
            }
            y = 200;
            return bitMap;
        }

        /// <summary>
        /// Определение размеров цепи последовательного соединения
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        private static Tuple<int, int> _serialSize(SerialCircuit serial)
        {
            int height = 200 + 50;
            int width = serial.Components.Count * 50 + (serial.Components.Count - 1)*40 + 40;
            foreach (var components in serial.Components)
            {
                if (components is ParallelCircuit)
                {
                    var parallellSubcircuit = (ParallelCircuit) components;
                    var tuple = _parallelSize(parallellSubcircuit);
                    height += tuple.Item2;
                    width += tuple.Item1;
                }
                if (components is SerialCircuit)
                {
                    var serialSubcircuit = (SerialCircuit) components;
                    var tuple = _serialSize(serialSubcircuit);
                    width += tuple.Item1;
                }
            }
            return new Tuple<int, int>(width, height);
        }

        /// <summary>
        /// Определение размеров цепи параллельного соединения
        /// </summary>
        /// <param name="parallel"></param>
        /// <returns></returns>
        private static Tuple<int, int> _parallelSize(ParallelCircuit parallel)
        {
            int height = 200 + parallel.Components.Count*50 + 40;
            int width = 120;
            foreach (var components in parallel.Components)
            {
                if (components is SerialCircuit)
                {
                    var serialsubCircuit = (SerialCircuit) components;
                    var tuple = _serialSize(serialsubCircuit);
                    height += 25;
                    width += tuple.Item1;
                }
                if (components is ParallelCircuit)
                {
                    var parallelSubcircuit = (ParallelCircuit) components;
                    var tuple = _parallelSize(parallelSubcircuit);
                    height += tuple.Item2;
                    width += tuple.Item1;
                }
            }
            return new Tuple<int, int>(width, height);
        }
    }
}
