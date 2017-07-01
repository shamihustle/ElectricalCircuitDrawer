using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public Elemnts.IComponent Component;

        
        private void FormDraw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(СircuitDrawer.DrawComponent(Component), new Point(0, 0));
        }
    }
}
