using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elemnts;
using Elemnts.Elements;

namespace ConsoleDrawer.View.Draw
{
    static public class ElementDraw
    {
        public static Bitmap DrawElement(IComponent element)
        {
            if (element is Resistor)
            {
                var bitMap = new Bitmap(50, 50);
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    DrawResistor(g);
                }
                return bitMap;
            }
            if (element is Capacitor)
            {
                var bitMap = new Bitmap(50, 50);
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    DrawCapacitor(g);
                }
                return bitMap;
            }
            if (element is Inductor)
            {
                var bitMap = new Bitmap(50, 50);
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    DrawInductor(g);
                }
                return bitMap;
            }
            return null;

        }

        static void DrawResistor(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Black, 0, 0, 40, 20);
        }

        static void DrawInductor(Graphics graphics)
        {
            for (int i = 0; i < 4; i++)
            {
                graphics.DrawArc(Pens.Black, i * 10, 5, 10, 10, 0, -180);
            }
        }

        static void DrawCapacitor(Graphics graphics)
        {
            graphics.DrawLine(Pens.Black, 0, 10, 10, 10);
            graphics.DrawLine(Pens.Black, 10, 0, 10, 20);
            graphics.DrawLine(Pens.Black, 30, 0, 30, 20);
            graphics.DrawLine(Pens.Black, 30, 10, 40, 10);
        }

        static Tuple<int, int> getSizeElement(Bitmap bitMapElement)
        {
            return new Tuple<int, int>(bitMapElement.Height, bitMapElement.Width);
        }
    }
}
