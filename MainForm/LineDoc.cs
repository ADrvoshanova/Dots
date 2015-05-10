using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    public class LinesDoc
    {
        public List<Line> Lines { get; set; }

        public LinesDoc()
        {
            Lines = new List<Line>();
        }

        public void AddLine(Line line)
        {

            Lines.Add(line);
        }
        public int Count()
        {
            return Lines.Count();
        }
        public void DrawLines(Graphics g)
        {
            foreach (Line line in Lines)
            {
                line.Draw(g);
            }
        }
    }
}
