using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elemnts.Elements;

namespace ConsoleDrawer.View
{
    public partial class FormAddElements : Form
    {
        public FormAddElements()
        {
            InitializeComponent();
        }


        public IElement Element
        {
            get
            {
                var ss = comboBoxAddElement.SelectedIndex;
                switch (ss)
                {
                    case 0:
                        {
                            var resistor = new Resistor(Convert.ToDouble(textBoxValue.Text));
                            return resistor;
                        }
                    case 1:
                        {
                            var capacitor = new Capacitor(Convert.ToDouble(textBoxValue.Text));
                            return capacitor;
                        }
                    case 2:
                        {
                            var inductor = new Inductor(Convert.ToDouble(textBoxValue.Text));
                            return inductor;
                        }
                }
                throw new ArgumentException(@"Error with combobx element");
            }
            set
            {
                if (value is Resistor)
                {
                    comboBoxAddElement.SelectedIndex = 0;
                    textBoxValue.Text = value.Value.ToString();
                }
                if (value is Capacitor)
                {
                    comboBoxAddElement.SelectedIndex = 1;
                    textBoxValue.Text = value.Value.ToString();
                }
                if (value is Inductor)
                {
                    comboBoxAddElement.SelectedIndex = 2;
                    textBoxValue.Text = value.Value.ToString();
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
