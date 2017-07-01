using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elemnts;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleCircuit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Первая схема
            {
#region
                Console.WriteLine(@"First example:");

                var r = new Resistor(1);
                var c = new Capacitor(2);
                var i = new Inductor(3);

                Console.WriteLine("R = " + r.CalculateZ(50));
                Console.WriteLine("C = " + c.CalculateZ(50));
                Console.WriteLine("I = " + i.CalculateZ(50));


                var s1 = new SerialCircuit();
                s1.Add(new Resistor(1));

                var p1 = new ParallelCircuit();
                p1.Add(new Capacitor(2));
                p1.Add(new Inductor(3));
                s1.Add(p1);
                Console.WriteLine("P1 = " + p1.CalculateZ(50));
                Console.WriteLine("Z = " + s1.CalculateZ(50) +  "\n");
#endregion
            }

            // Вторая схема
            {
#region
                Console.WriteLine(@"Second example");

                var parallel2 = new ParallelCircuit();
                parallel2.Add(new Resistor(10));
                parallel2.Add(new Capacitor(20));
                var serial2 = new SerialCircuit();
                serial2.Add(parallel2);
                serial2.Add(new Inductor(30));

                var r = new Resistor(10);
                var c = new Capacitor(20);
                var i = new Inductor(30);
                Console.WriteLine("R = " + r.CalculateZ(50));
                Console.WriteLine("C = " + c.CalculateZ(50));
                Console.WriteLine("I = " + i.CalculateZ(50));
                Console.WriteLine("P1 = " + parallel2.CalculateZ(50));
                Console.WriteLine("Z = " + serial2.CalculateZ(50) + "\n");
#endregion
            }

            // Третья схема
            {
#region
                Console.WriteLine(@"Third Example");
                var parallel1 = new ParallelCircuit();
                parallel1.Add(new Capacitor(10));
                parallel1.Add(new Inductor(20));
                var serial1 = new SerialCircuit();
                serial1.Add(parallel1);
                serial1.Add(new Inductor(30));
                var parallel2 = new ParallelCircuit();
                parallel2.Add(new Inductor(40));
                parallel2.Add(new Resistor(50));
                serial1.Add(parallel2);
                Console.WriteLine("Z = " + serial1.CalculateZ(50) + "\n");
#endregion
            }

            // Четвертая схема
            {
#region
                Console.WriteLine(@"Fourth example");
                var parallel1 = new ParallelCircuit();
                var parallel2 = new ParallelCircuit();
                parallel2.Add(new Resistor(20));
                parallel2.Add(new Inductor(30));
                var serial1 = new SerialCircuit();
                serial1.Add(new Capacitor(10));
                serial1.Add(parallel2);
                var parallel3 = new ParallelCircuit();
                parallel3.Add(new Inductor(40));
                parallel3.Add(new Resistor(50));
                var serial2 = new SerialCircuit();
                serial2.Add(parallel3);
                serial2.Add(new Capacitor(60));
                parallel1.Add(serial1);
                parallel1.Add(serial2);
                Console.WriteLine("Z = " + parallel1.CalculateZ(50)  + "\n");
#endregion
            }

            // Пятая схема
            {
#region
                Console.WriteLine(@"Fifth example");
                var serial1 = new SerialCircuit();
                serial1.Add(new Capacitor(10));
                var parallel1 = new ParallelCircuit();
                parallel1.Add(new Capacitor(30));
                var serial2 = new SerialCircuit();
                serial2.Add(new Inductor(20));
                var parallel2 = new ParallelCircuit();
                parallel2.Add(new Capacitor(40));
                parallel2.Add(new Resistor(50));
                serial2.Add(parallel2);
                parallel1.Add(serial2);
                var serial3 = new SerialCircuit();
                serial3.Add(new Resistor(60));
                serial3.Add(new Inductor(70));
                parallel1.Add(serial3);
                serial1.Add(parallel1);
                Console.WriteLine(@"Z = " + serial1.CalculateZ(50));
#endregion
            }

            {
                var serial = new SerialCircuit();
                serial.Add(new Resistor(10));
                var parallel = new ParallelCircuit();
                parallel.Add(new Resistor(20));
                parallel.Add(new Capacitor(35));
                serial.Add(parallel);
                Console.WriteLine(@"Z = " + serial.CalculateZ(50));

            }
            Console.ReadKey();
        }
    }
}
