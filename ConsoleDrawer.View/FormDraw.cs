using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleDrawer.View.Draw;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View
{
    public partial class FormDraw : Form
    {
        public FormDraw()
        {
            InitializeComponent();

        }

        public IComponent Component;

        private void FormDraw_Paint(object sender, PaintEventArgs e)
        {
            // Первая
            {
                var serial = new SerialCircuit();
                serial.Add(new Resistor(10));
                var parallel = new ParallelCircuit();
                parallel.Add(new Capacitor(10));
                parallel.Add(new Inductor(10));
                serial.Add(parallel);
            }

            // Вторая
            {
                var parallel2 = new ParallelCircuit();
                parallel2.Add(new Resistor(1));
                parallel2.Add(new Resistor(2));
                var serial2 = new SerialCircuit();
                serial2.Add(parallel2);
                serial2.Add(new Resistor(1));
            }

            // Третья
            {
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

            }

            // Четвертая
            {
                var parallel1 = new ParallelCircuit();
                var serial1 = new SerialCircuit();
                serial1.Add(new Capacitor(1));
                var parallel2 = new ParallelCircuit();
                var parallel3 = new ParallelCircuit();
                parallel3.Add(new Resistor(1));
                parallel3.Add(new Capacitor(1));
                parallel2.Add(new Resistor(1));
                parallel2.Add(new Capacitor(1));
                var serial3 = new SerialCircuit();
                serial3.Add(parallel3);
                serial3.Add(new Capacitor(1));
                serial1.Add(parallel2);
                parallel1.Add(serial1);
                parallel1.Add(serial3);

            }

            // Пятая
            {
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
                e.Graphics.DrawImage(СircuitDraw.DrawComponent(serial1), new Point(0, 0));

            }
        }
    }
}
