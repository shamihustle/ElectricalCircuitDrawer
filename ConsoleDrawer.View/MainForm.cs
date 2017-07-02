using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleDrawer.View.Draw;
using Elements.Curcuit;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ICircuit Circuit;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewCircuit.Rows.Clear();
            if (comboBoxCircuit.SelectedIndex == 0)
            {
                var serial = new SerialCircuit();
                serial.Add(new Resistor(10));
                var parallel = new ParallelCircuit();
                parallel.Add(new Capacitor(10));
                parallel.Add(new Inductor(10));
                serial.Add(parallel);
                Circuit = serial;
            }
            if (comboBoxCircuit.SelectedIndex == 1)
            {
                var parallel2 = new ParallelCircuit();
                parallel2.Add(new Resistor(1));
                parallel2.Add(new Resistor(2));
                var serial2 = new SerialCircuit();
                serial2.Add(parallel2);
                serial2.Add(new Resistor(1));
                Circuit = serial2;
            }
            if (comboBoxCircuit.SelectedIndex == 2)
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
                Circuit = serial1;
            }
            if (comboBoxCircuit.SelectedIndex == 3)
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
                Circuit = parallel1;
            }
            if (comboBoxCircuit.SelectedIndex == 4)
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
                Circuit = serial1;
            }
            serialCircuitBindingSource.DataSource = Circuit;
        }



        private void buttonDraw_Click(object sender, EventArgs e)
        {
            var form = new FormDraw
            {
                Component = Circuit
            };
            form.ShowDialog();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            var impedance = Circuit.CalculateZ(Convert.ToDouble(textBoxFrequency.Text));
            textBoxReal.Text = impedance.Real.ToString();
            textBoxIm.Text = impedance.Imaginary.ToString();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Circuit.CircuitChanged += CircuitChanged;
            if (serialCircuitBindingSource.Current is IElement)
            {
                IElement element = (IElement)serialCircuitBindingSource.Current;
                Circuit.RemoveComponent(element, Circuit);
                serialCircuitBindingSource.DataSource = Circuit;
            }
            if (serialCircuitBindingSource.Current is ICircuit)
            {
                ICircuit circuit = (ICircuit)serialCircuitBindingSource.Current;
                Circuit.RemoveCircuit(circuit, Circuit);
                serialCircuitBindingSource.DataSource = Circuit;
            }
        }


        private void dataGridViewCircuit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (serialCircuitBindingSource.Current is IElement)
            {
                MessageBox.Show(@"Select circuit");
                return;
            }
            var circuit = (ICircuit)serialCircuitBindingSource.Current;
            serialCircuitBindingSource.DataSource = circuit.Components;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            Circuit.CircuitChanged += CircuitChanged;
            var component = serialCircuitBindingSource.Current;
            if (component is IElement)
            {
                var element = (IElement)component;
                var form = new FormAddElements
                {
                    Element = element
                };
                form.ShowDialog();
                var newElement = form.Element;
                Circuit.ModifyComponent(element, newElement, Circuit);
                serialCircuitBindingSource.DataSource = Circuit.Components;
            }
            if (component is ICircuit)
            {
                var circuit = (ICircuit)component;
                var form = new FormAddSircuit
                {
                    Circuit = circuit
                };
                form.ShowDialog();
                var newCircuit = form.Circuit;
                Circuit.ModifyCircuit(circuit, newCircuit, Circuit);
                serialCircuitBindingSource.DataSource = Circuit;
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            var impedance = Circuit.CalculateZ(Convert.ToDouble(textBoxFrequency.Text));
            textBoxReal.Text = impedance.Real.ToString();
            textBoxIm.Text = impedance.Imaginary.ToString();
        }

        private void CircuitChanged(object sender, EventArgs e)
        {
            var impedance = Circuit.CalculateZ(Convert.ToDouble(textBoxFrequency.Text));
            textBoxReal.Text = impedance.Real.ToString();
            textBoxIm.Text = impedance.Imaginary.ToString();
        }
    }
}
