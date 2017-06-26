using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elemnts;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View
{
    public partial class FormAddCircuit : Form
    {
        public FormAddCircuit()
        {
            InitializeComponent();
        }

        private List<ICircuit> _components = new List<ICircuit>();

        private void buttonCreateSubcircuit_Click(object sender, EventArgs e)
        {
            if (comboBoxCircuit == null)
            {
                MessageBox.Show(@"Error");
                return;
            }


            if (treeViewSubcircuit.Nodes.Count == 0)
            {
                var circuitType = comboBoxCircuit.SelectedIndex;

                switch (circuitType)
                {
                    case 0:
                        {
                            var serial = new SerialCircuit();
                            _components.Add(serial);
                            treeViewSubcircuit.Nodes.Add("Serial");
                            break;
                        }
                    case 1:
                        {
                            var parallel = new ParallelCircuit();
                            _components.Add(parallel);
                            treeViewSubcircuit.Nodes.Add("Parallel");
                            break;
                        }
                }
            }
            else
            {
                var circuitType = comboBoxCircuit.SelectedIndex;

                switch (circuitType)
                {
                    case 0:
                        {
                            var serial = new SerialCircuit();
                            _components[treeViewSubcircuit.SelectedNode.Index].Add(serial);
                            _components.Add(serial);
                            treeViewSubcircuit.SelectedNode.Nodes.Add("Serial");
                            break;
                        }
                    case 1:
                        {
                            var parallel = new ParallelCircuit();
                            _components[treeViewSubcircuit.SelectedNode.Index].Add(parallel);
                            _components.Add(parallel);
                            treeViewSubcircuit.SelectedNode.Nodes.Add("Parallel");
                            break;
                        }
                }
                
            }

            
        }

        private void buttonAddElement_Click(object sender, EventArgs e)
        {
            if (treeViewSubcircuit.SelectedNode == null)
            {
                MessageBox.Show(@"Error with selected circuit");
                return;
            }

            var form = new FormAddElement();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _components[treeViewSubcircuit.SelectedNode.Index].Add(form.Element);

                if (form.Element is Resistor)
                {
                    treeViewSubcircuit.SelectedNode.Nodes.Add("Resistor");
                }
                if (form.Element is Capacitor)
                {
                    treeViewSubcircuit.SelectedNode.Nodes.Add("Capacitor");
                }
                if (form.Element is Inductor)
                {
                    treeViewSubcircuit.SelectedNode.Nodes.Add("Inductor");
                }
            }

        }

        private void buttonCalculateZ_Click(object sender, EventArgs e)
        {
            if (textBoxFrequency.Text == "")
            {
                MessageBox.Show(@"Frequency error");
                return;
            }

            textBoxImpedance.Text = _components[0].CalculateZ(Convert.ToDouble(textBoxFrequency.Text)).ToString();
        }
    }
}
