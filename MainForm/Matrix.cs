using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    public class Matrix
    {
        private int rows;
        private int columns;
        private Dot[][] dots;
        private Random random;
        private bool[][] filled;
        private static readonly int ROWS = 6;
        private static readonly int COLUMNS = 6;
        public Matrix()
        {
            random = new Random();
            this.rows = ROWS;
            this.columns = COLUMNS;
            dots = new Dot[rows][];
            for (int i = 0; i < rows; i++)
            {
                dots[i] = new Dot[columns];
            }
            load();
            newFilled();

        }
        private void newFilled()
        {
            filled = new bool[ROWS][];
            for (int i = 0; i < ROWS; i++)
            {
                filled[i] = new bool[COLUMNS];
            }
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    filled[i][j] = true;

                }
            }
        }
        public void load()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dots[i][j] = new Dot(random);

                }
            }
        }
        public void Reload()
        {
            for (int i = 0; i < ROWS - 1; i++)
            {
                for (int j = 0; j < COLUMNS - 1; j++)
                {
                    if (dots[i][j].Colorr() == dots[i + 1][j].Colorr())
                        return;
                    if (dots[i][j].Colorr() == dots[i][j + 1].Colorr())
                        return;
                }
            }
            load();
        }
        public void Draw(Graphics g)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (filled[i][j] == true)

                        dots[i][j].Draw(g, j * 40 + 10, i * 40 + 10);
                }
            }

        }
        public void Hit(float p1, float p2)
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (dots[i][j].IsHit(p1, p2))
                    {
                        filled[i][j] = false;
                    }
                }
            }

        }
        
        public Dot HitDot(float p1, float p2)
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (dots[i][j].IsHit(p1, p2))
                    {
                        return dots[i][j];
                    }
                }
            }
            return null;

        }
        public void verticalLoad()
        {
            for (int j = COLUMNS - 1; j >= 0; j--)
            {
                for (int i = ROWS - 1; i >= 0; i--)
                {
                    if (filled[i][j] == false)
                    {
                        if (i - 1 >= 0 && filled[i - 1][j] == true)
                        {

                            dots[i - 1][j].Move();
                            dots[i][j] = dots[i - 1][j];
                            filled[i - 1][j] = false;
                            filled[i][j] = true;

                        }

                    }


                }
            }

        }
        public void addNewDots()
        {
            for (int i = ROWS - 1; i >= 0; i--)
            {
                for (int j = COLUMNS - 1; j >= 0; j--)
                {
                    if (filled[i][j] == false)
                    {
                        dots[i][j] = new Dot(random);
                        filled[i][j] = true;

                    }
                }
            }
        }

        public void removeVisited()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (dots[i][j].visited == true)
                    {
                        filled[i][j] = false;

                    }
                }
            }
            verticalLoad();
            addNewDots();
        }
        public int numOfVisited()
        {
            int br = 0;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (dots[i][j].visited == true)
                    {
                        br++;

                    }
                }
            }
            return br;
        }
    }
}
