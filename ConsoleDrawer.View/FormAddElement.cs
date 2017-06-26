using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elemnts;
using Elemnts.Elements;

namespace ConsoleDrawer.View
{
    public partial class FormAddElement : Form
    {
        public FormAddElement()
        {
            InitializeComponent();
        }

        private IElement _element;

        public IElement Element
        {
            get
            {
                var ss = comboBoxElements.SelectedIndex;

                switch (ss)
                {
                    case 0:
                        {
                            var resistor = new Resistor(Convert.ToDouble(textBoxValue.Text));
                            _element = resistor;
                            break;
                        }
                    case 1:
                        {
                            var capacitor = new Capacitor(Convert.ToDouble(textBoxValue.Text));
                            _element = capacitor;
                            break;
                        }
                    case 2:
                        {
                            var inductor = new Inductor(Convert.ToDouble(textBoxValue.Text));
                            _element = inductor;
                            break;
                        }
                }

                return _element;
            }
            set
            {
                _element = value;
                
            }
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
