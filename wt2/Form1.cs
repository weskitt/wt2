using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wt2
{
    public partial class Form1 : Form
    {

        Funcs funcs = new Funcs();

        public Form1()
        {
            InitializeComponent();
            funcs.InitSimpleMods();
        }
        public int DrawDefaultPoint() //默认必须优先调用
        {
            var g = Pview.CreateGraphics();
            Pen pen = new Pen(Color.Green);

            g.Clear(Color.Black);//清楚画布
            g.DrawLine(pen, 0, Pview.Height / 2, Pview.Width, Pview.Height / 2);

            // for (int i = 0; i < Pview.Width; i++)
            //{
            //    Y_Value xv = new Y_Value(0, 0);
            //    AllData.yArray.Add(xv);
            //};
            

            WAData.DataLength = Pview.Width;
            WAData.DataMax = Pview.Height/2;
            return Pview.Width;
        }
        public void DrawModPoint(object sender, EventArgs e)
        {
            var g = Pview.CreateGraphics();
            Pen pen = new Pen(Color.Green);
            

            funcs.GenAnalogData(0);
            PointF[] data = new PointF[WAData.DataLength];
            double[] yValue = (double[])WAData.yArray.ToArray(typeof(double));
            for (int i = 0; i < WAData.DataLength; i++)
            {
                data[i].X = i;
                data[i].Y = (float)yValue[i] + (float)WAData.DataMax;//DataMax 图形居中
            }
            g.Clear(Color.Black);//清楚画布
            g.DrawLines(pen, data);
            
        }
        private void Pview_Paint(object sender, PaintEventArgs e)
        {
            var dps = DrawDefaultPoint();
            
        }

    }
}
