using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elemnts;
using Elemnts.Curcuit;

namespace ConsoleCircuit
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine(@"First example:");

                var r = new Resistor(1);
                var c = new Capacitor(2);
                var i = new Inductor(3);

                Console.WriteLine(r.CalculateZ(12));
                Console.WriteLine(c.CalculateZ(12));
                Console.WriteLine(i.CalculateZ(12));


                var s1 = new SerialCircuit();
                s1.AddComponent(new Resistor(1));

                var p1 = new ParallelCircuit();
                p1.AddComponent(new Capacitor(2));
                p1.AddComponent(new Inductor(3));
                s1.AddComponent(p1);
                Console.WriteLine(p1.CalculateZ(12));
                Console.WriteLine(s1.CalculateZ(12) +  "\n");
            }

            {
                Console.WriteLine(@"Second example");

                var parallel2 = new ParallelCircuit();
                parallel2.AddComponent(new Resistor(10));
                parallel2.AddComponent(new Capacitor(20));
                var serial2 = new SerialCircuit();
                serial2.AddComponent(parallel2);
                serial2.AddComponent(new Inductor(30));

                var r = new Resistor(10);
                var c = new Capacitor(20);
                var i = new Inductor(30);
                Console.WriteLine("R = " + r.CalculateZ(50));
                Console.WriteLine("C = " + c.CalculateZ(50));
                Console.WriteLine("I = " + i.CalculateZ(50));
                Console.WriteLine("P = " + parallel2.CalculateZ(50));
                Console.WriteLine("Z = " + serial2.CalculateZ(50));
                Console.WriteLine();
            }

            {
                Console.WriteLine(@"Third Example");
                
                var parallel1 = new ParallelCircuit();
                parallel1.AddComponent(new Capacitor(10));
                parallel1.AddComponent(new Inductor(20));
                var serial1 = new SerialCircuit();
                serial1.AddComponent(parallel1);
                serial1.AddComponent(new Inductor(30));
                var parallel2 = new ParallelCircuit();
                parallel2.AddComponent(new Inductor(40));
                parallel2.AddComponent(new Resistor(50));
                serial1.AddComponent(parallel2);
                Console.WriteLine("Z = " + serial1.CalculateZ(50));
            }
            {
                Console.Clear();
                Console.WriteLine(@"Fourth example");
                var parallel1 = new ParallelCircuit();
                var parallel2 = new ParallelCircuit();
                parallel2.AddComponent(new Resistor(20));
                parallel2.AddComponent(new Inductor(30));
                var serial1 = new SerialCircuit();
                serial1.AddComponent(new Capacitor(10));
                serial1.AddComponent(parallel2);
                var parallel3 = new ParallelCircuit();
                parallel3.AddComponent(new Inductor(40));
                parallel3.AddComponent(new Resistor(50));
                var serial2 = new SerialCircuit();
                serial2.AddComponent(parallel3);
                serial2.AddComponent(new Capacitor(60));
                parallel1.AddComponent(serial1);
                parallel1.AddComponent(serial2);
                Console.WriteLine("Z = " + parallel1.CalculateZ(50));
            }

            {
                Console.Clear();
                Console.WriteLine(@"Fifth example");
                var serial1 = new SerialCircuit();
                serial1.AddComponent(new Capacitor(10));
                var parallel1 = new ParallelCircuit();
                parallel1.AddComponent(new Capacitor(30));
                var serial2 = new SerialCircuit();
                serial2.AddComponent(new Inductor(20));
                var parallel2 = new ParallelCircuit();
                parallel2.AddComponent(new Capacitor(40));
                parallel2.AddComponent(new Resistor(50));
                serial2.AddComponent(parallel2);
                parallel1.AddComponent(serial2);
                var serial3 = new SerialCircuit();
                serial3.AddComponent(new Resistor(60));
                serial3.AddComponent(new Inductor(70));
                parallel1.AddComponent(serial3);
                serial1.AddComponent(parallel1);
                Console.WriteLine(@"Z = " + serial1.CalculateZ(50));

            }

            Console.ReadKey();
        }
    }
}
