using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }

        public Line(Point start, Point end, Color color)
        {
            Start = start;
            End = end;
            Color = color;


        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 5);
            g.DrawLine(pen, Start, End);
            pen.Dispose();
        }
    }
}
