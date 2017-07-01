using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View
{
    public partial class FormAddSircuit : Form
    {
        public FormAddSircuit()
        {
            InitializeComponent();
        }

        
        public ICircuit Circuit
        {
            get
            {
                var ss = comboBoxAddCircuit.SelectedIndex;
                switch (ss)
                {
                    case 0:
                    {
                        var serial = new SerialCircuit();
                        return serial;
                    }
                    case 1:
                    {
                        var parallel = new ParallelCircuit();;
                        return parallel;
                    }
                }
                throw new ArgumentException(@"Error with combobox circuit");
            }
            set
            {
                comboBoxAddCircuit.Visible = true;

                if (value is SerialCircuit)
                {
                    comboBoxAddCircuit.SelectedIndex = 0;
                }
                if (value is ParallelCircuit)
                {
                    comboBoxAddCircuit.SelectedIndex = 1;
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
