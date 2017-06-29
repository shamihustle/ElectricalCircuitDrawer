using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Elemnts;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View.Draw
{
    /// <summary>
    /// Определяет размер электрической цепи
    /// </summary>
    public static class SizeDeterminator
    {
        /// <summary>
        /// Вычисляет размер рисунка цепи с последовательным соединением
        /// </summary>
        /// <param name="circuitBase">Цепь с последовательным соединением</param>
        /// <returns>Размер</returns>
        public static Tuple<int,int> GetSize(SerialCircuit circuitBase)
        {
            var tuple = new Tuple<int, int>(1,1);
            var width = tuple.Item1;
            var height = tuple.Item2;
            foreach (IComponent component in circuitBase.Components)
            {
                if (component is IElement)
                {
                    if (height < 50)
                    {
                        height = 50;
                    }
                    width += 90;
                }
                else if (component is SerialCircuit)
                {
                    var serial = (SerialCircuit)component;
                    var serialCircuitSize = GetSize(serial);
                    if (height < serialCircuitSize.Item2)
                    {
                        height = serialCircuitSize.Item2;
                    }
                    width += serialCircuitSize.Item1;
                }
                else if (component is ParallelCircuit)
                {
                    var parallel = (ParallelCircuit)component;
                    var parallelCircuitSize = GetSize(parallel);
                    if (height < parallelCircuitSize.Item2)
                    {
                        height = parallelCircuitSize.Item2;
                    }
                    width += parallelCircuitSize.Item1;
                }
            }
            return new Tuple<int, int>(width,height);
        }

        /// <summary>
        /// Размер рисунка цепи с параллельным соединением
        /// </summary>
        /// <param name="circuitBase">Цепь с параллельным соединением</param>
        /// <returns>Размер</returns>
        public static Tuple<int,int> GetSize(ParallelCircuit circuitBase)
        {
            var tuple = new Tuple<int, int>(1, 1);
            var width = tuple.Item1;
            var height = tuple.Item2;
            foreach (var component in circuitBase.Components)
            {
                if (component is IElement)
                {
                    height += 50;
                    if (width < 50)
                    {
                        width = 50;
                    }
                }
                else if (component is SerialCircuit)
                {
                    var serial = (SerialCircuit)component;
                    var serialCircuitSize = GetSize(serial);
                    if (width < serialCircuitSize.Item1)
                    {
                        width = serialCircuitSize.Item1;
                    }
                    height += serialCircuitSize.Item2;
                }
                else if (component is ParallelCircuit)
                {
                    var parallel = (ParallelCircuit)component;
                    var parallelCircuitSize = GetSize(parallel);
                    if (width < parallelCircuitSize.Item1)
                    {
                        width = parallelCircuitSize.Item1;
                    }
                    height += parallelCircuitSize.Item2;
                }
            }
            width += 50;
            return new Tuple<int, int>(width,height);
        }

        /// <summary>
        /// Определяет цепь
        /// </summary>
        /// <param name="component">Параллельная или последовательная цепь</param>
        /// <returns>Размер</returns>
        public static Tuple<int,int> GetSize(ICircuit component)
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
            return new Tuple<int, int>(1,1);
        }
    }
}
