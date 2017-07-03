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

        /// <summary>
        /// Основная цепь
        /// </summary>
        private ICircuit Circuit;

        /// <summary>
        /// Выбор схемы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Отрисовать схему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDraw_Click(object sender, EventArgs e)
        {
            if (serialCircuitBindingSource.Count == 0)
            {
                MessageBox.Show(@"List is empty");
                return;
            }
            var form = new FormDraw
            {
                Component = Circuit
            };
            form.ShowDialog();
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            var impedance = Circuit.CalculateZ(Convert.ToDouble(textBoxFrequency.Text));
            textBoxReal.Text = impedance.Real.ToString();
            textBoxIm.Text = impedance.Imaginary.ToString();
        }

        /// <summary>
        /// Удалить компонент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (serialCircuitBindingSource.Count == 0 || serialCircuitBindingSource.Current == null)
            {
                MessageBox.Show(@"List is empty");
                return;
            }
            Circuit.CircuitChanged += CircuitChanged;
            var component = serialCircuitBindingSource.Current;
            if (component is IElement)
            {
                IElement element = (IElement)component;
                Circuit.RemoveElement(element, Circuit);
                serialCircuitBindingSource.DataSource = Circuit;
            }
            if (component is ICircuit)
            {
                ICircuit circuit = (ICircuit)component;
                Circuit.RemoveCircuit(circuit, Circuit);
                serialCircuitBindingSource.DataSource = Circuit;
            }
        }

        /// <summary>
        /// Переход на другой уровень подцепи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Изменить компонент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (serialCircuitBindingSource.Count == 0 || serialCircuitBindingSource.Current == null)
            {
                MessageBox.Show(@"List is empty");
                return;
            }
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
                try
                {
                    var newElement = form.Element;
                    Circuit.ModifyElement(element, newElement, Circuit);
                    serialCircuitBindingSource.DataSource = Circuit.Components;

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
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

        /// <summary>
        /// Перерасчет комплексного сопротивления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircuitChanged(object sender, EventArgs e)
        {
            var impedance = Circuit.CalculateZ(Convert.ToDouble(textBoxFrequency.Text));
            textBoxReal.Text = impedance.Real.ToString();
            textBoxIm.Text = impedance.Imaginary.ToString();
        }
    }
}
