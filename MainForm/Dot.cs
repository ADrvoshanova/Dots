using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    public class Dot
    {
        private string[] colors = { "#FF3DA59E", "#FFE36166", "#FFE9871D", "#FF6CAF60", "#E6DB22", "#9C5DB5" };
        private Color color;
        private static readonly int RADIUS = 10;
        private Brush brush;
        private float X;
        private float Y;
        public bool visited { get; set; }
        public bool filled { get; set; }
        public float x()
        {
            return X;
        }
        public float y()
        {
            return Y;
        }
        public Color Colorr()
        {
            return color;
        }

        public Dot(Random rnd)
        {

            color = ColorTranslator.FromHtml(colors[rnd.Next(0, 6)]);
            brush = new SolidBrush(color);
            visited = false;

        }
        public void Draw(Graphics g, int x, int y)
        {
            Pen pen = new Pen(color);
            X = x + 80;
            Y = y + 170;
            g.FillEllipse(brush, X - RADIUS, Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
            g.DrawEllipse(pen, X - RADIUS, Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
        }
        public void Move()
        {
            X -= (2 * RADIUS - 20);
            Y -= (2 * RADIUS - 20);
        }
        public bool IsHit(float x, float y)
        {
            double d = Math.Sqrt((X - x) * (X - x) + (Y - y) * (Y - y));
            return d <= RADIUS + 10;
        }
    }
}
