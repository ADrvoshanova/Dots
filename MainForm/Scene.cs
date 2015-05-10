using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    public class Scene
    {
        public Matrix matrix;
        private List<Point> points;

        public Scene()
        {
            matrix = new Matrix();
            points = new List<Point>();

        }
        public void addPoint(Point p)
        {
            points.Add(p);
        }

        public void drawMatrix(Graphics g)
        {
            matrix.Draw(g);
        }

        public int NumVisited()
        {
            return matrix.numOfVisited();
        }

        public void deleteSelected(float p1, float p2)
        {
            matrix.Hit(p1, p2);
            matrix.verticalLoad();
            matrix.addNewDots();
        }

        public void removeVisited()
        {
            matrix.removeVisited();
        }

        public string Poeni(string p)
        {
            int stari = Convert.ToInt16(p);
            if (matrix.numOfVisited()<8)       
                return (stari + (matrix.numOfVisited()-2)*2+2).ToString();
            else
                return (stari + (matrix.numOfVisited() - 2) * 2 + 12).ToString();
      

        }

        public void Reload()
        {
            matrix.Reload();
        }
    }
}
