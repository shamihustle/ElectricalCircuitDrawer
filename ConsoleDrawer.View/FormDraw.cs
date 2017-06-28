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

            var serial = new SerialCircuit();
            serial.Add(new Resistor(10));
      
            var parallel = new ParallelCircuit();
            parallel.Add(new Capacitor(10));
            parallel.Add(new Resistor(10));
            serial.Add(parallel);

            var parallel2 = new ParallelCircuit();
            var serial2 = new SerialCircuit();
            serial2.Add(new Resistor(2));
            serial2.Add(new Capacitor(2));
            parallel2.Add(serial2);
            parallel2.Add(new Resistor(1));
            parallel2.Add(new Resistor(2));

            e.Graphics.DrawImage(SubcircuitDraw.CiruitDraw(serial), new Point(0, 0));
        }
    }
}
