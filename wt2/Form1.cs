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
        public Form1()
        {
            InitializeComponent();
        }
        public int DrawDefaultPoint()
        {
            var g = Pview.CreateGraphics();
            Pen pen = new Pen(Color.Green);

            g.Clear(Color.Black);//清楚画布
            g.DrawLine(pen, 0, Pview.Height / 2, Pview.Width, Pview.Height / 2);

            for (int i = 0; i < Pview.Width; i++)
            {
                Y_Value xv = new Y_Value(0, 0);
                AllData.yArray.Add(xv);
            }

            return Pview.Width;
        }
        private void Pview_Paint(object sender, PaintEventArgs e)
        {
            var dps = DrawDefaultPoint();
        }
    }
}
