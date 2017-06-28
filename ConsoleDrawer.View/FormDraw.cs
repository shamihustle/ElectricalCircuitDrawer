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
using Elemnts.Curcuit;
using Elemnts.Elements;

namespace ConsoleDrawer.View
{
    public partial class FormDraw : Form
    {
        public FormDraw(List<ICircuit> _components)
        {
            InitializeComponent();
            component = _components;
        }

        private List<ICircuit> component = new List<ICircuit>();

        private void FormDraw_Paint(object sender, PaintEventArgs e)
        {
            CircuitDrawer(e);
        }

        private void CircuitDrawer(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Brushes.Black);
            
            blackPen.Width = 1.0F;
            
            var tupleList = new List<Tuple<int, int>>();
            tupleList.Add(new Tuple<int,int>(0,200));

            for (int i = 0; i < component.Count; i++)
            {
                var height = 80 - i*20;
                if (component[i] is SerialCircuit)
                {
                    tupleList.Add(DrawSerial(e, blackPen, tupleList[tupleList.Count - 1].Item1, tupleList[tupleList.Count - 1].Item2));
                    foreach (var element in component[i].Components)
                    {
                        if (element is Resistor)
                        {
                            tupleList.Add(DrawResistor(tupleList[tupleList.Count - 1].Item1, tupleList[tupleList.Count - 1].Item2, e, blackPen));
                        }
                        if (element is Capacitor)
                        {
                            tupleList.Add(DrawCapacitor(tupleList[tupleList.Count - 1].Item1, tupleList[tupleList.Count - 1].Item2, e, blackPen));
                        }
                        if (element is Inductor)
                        {
                            tupleList.Add(DrawInductor(tupleList[tupleList.Count - 1].Item1, tupleList[tupleList.Count - 1].Item2, e, blackPen));
                        }
                    }
                }
                if (component[i] is ParallelCircuit)
                {
                    var tupleListParallel = DrawParallel(e, blackPen, tupleList[tupleList.Count - 1].Item1, tupleList[tupleList.Count - 1 ].Item2, height, component[i].Components.Count);
                    for (int j = 0; j < tupleListParallel.Count; j++)
                    {
                        for (int k = j; k < component[i].Components.Count; k++)
                        {
                            if (component[i].Components[k] is Resistor)
                            {
                                tupleList.Add(DrawResistor(tupleListParallel[j].Item1, tupleListParallel[j].Item2, e, blackPen));
                                break;
                            }
                            if (component[i].Components[k] is Capacitor)
                            {
                                tupleList.Add(DrawCapacitor(tupleListParallel[j].Item1, tupleListParallel[j].Item2, e, blackPen));
                                break;
                            }
                            if (component[i].Components[k] is Inductor)
                            {
                                tupleList.Add(DrawInductor(tupleListParallel[j].Item1, tupleListParallel[j].Item2, e, blackPen));
                                break;
                            }
                        }
                    }
                    tupleList.Add(tupleListParallel[tupleListParallel.Count-1]);
                }
                
            }
        }


        private Tuple<int, int> DrawInductor(int x, int y, PaintEventArgs e, Pen pen)
        {
            var c = 0;
            for (int i = 0; i < 4; i++)
            {
                c = x + (i * 10);
                e.Graphics.DrawArc(pen, c, y - 5, 10, 10, 0, -180);
            }
            return new Tuple<int, int>(c, y);
        }

        private Tuple<int, int> DrawCapacitor(int x1, int y1, PaintEventArgs e, Pen pen)
        {
            e.Graphics.DrawLine(pen, x1, y1, x1 + 20, y1);
            e.Graphics.DrawLine(pen, x1 + 20, y1 + 10, x1 + 20, y1 - 10);
            e.Graphics.DrawLine(pen, x1 + 30, y1 + 10, x1 + 30, y1 - 10);
            e.Graphics.DrawLine(pen, x1 + 30, y1, x1 + 50, y1);
            return new Tuple<int, int>(x1 + 50, y1);
        }

        private Tuple<int, int> DrawResistor(int x1, int y1, PaintEventArgs e, Pen pen)
        {
            e.Graphics.DrawRectangle(pen, x1, y1-10, 40, 20);
            return new Tuple<int, int>(x1 + 40, y1);
        }

        private Tuple<int, int> DrawSerial(PaintEventArgs e, Pen pen, int x, int y)
        {
            e.Graphics.DrawLine(pen, x, y, x + 25, y);
            return new Tuple<int, int>(x + 25, y);
        }

        private List<Tuple<int, int>> DrawParallel(PaintEventArgs e, Pen pen, int x, int y, int height, int countConnection)
        {
            e.Graphics.DrawLine(pen, x, y, x + 25, y);
            var tupleList = new  List<Tuple<int,int>>();
            height = height * (countConnection / 2);
            e.Graphics.DrawLine(pen, x + 25, y + 3 + height, x + 25, y + 3 - height);
            if (countConnection % 2 == 0)
            {
                e.Graphics.DrawLine(pen, x + 25, y + 3 + height, x + 65, y + 3 + height);
                e.Graphics.DrawLine(pen, x + 25, y + 3 - height, x + 65, y + 3 - height);
                if (countConnection == 2)
                {
                    tupleList.Add(new Tuple<int, int>(x + 65, y + 3 + height));
                    tupleList.Add(new Tuple<int, int>(x + 65, y + 3 - height));
                    return tupleList;
                }
                var count = height * 2 / (countConnection - 1);
                int i = 2;
                do
                {
                    e.Graphics.DrawLine(pen, x + 25, y + 3 + height - count, x + 65, y + 3 + height - count);
                    tupleList.Add(new Tuple<int, int>(x + 65, y + 3 + height - count));
                    i++;
                    count += count;
                } while (count < height * 2);
            }
            else
            {
                e.Graphics.DrawLine(pen, x + 25, y + 3 + height, x + 65, y + 3 + height);
                e.Graphics.DrawLine(pen, x + 25, y + 3 - height, x + 65, y + 3 - height);
                tupleList.Add(new Tuple<int, int>(x + 65, y + 3 + height));
                tupleList.Add(new Tuple<int, int>(x + 65, y + 3 - height));
                var count = height * 2 / (countConnection - 1);
                int i = 2;
                do
                {
                    e.Graphics.DrawLine(pen, x + 25, y + 3 + height - count, x + 65, y + 3 + height - count);
                    tupleList.Add(new Tuple<int, int>(x + 65, y + 3 + height - count));
                    i++;
                    count += height * 2 / (countConnection - 1);
                } while (count < height * 2);
            }
            return tupleList;
        }
    }
}
