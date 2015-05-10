using MainForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Form1 : Form
    {
        public bool finished = false;
        Scene scene;
        Image logo;
        private SoundPlayer soundV;
        private SoundPlayer soundR;
        bool mouseDown;
        Dot prva;
        Dot second;
        Line line;
        LinesDoc linesDoc;
        List<Dot> selected;
        Color currentColor;
        bool Timer;
        public int count { get; set; }
        public int score { get; set; }
        Player player;
        public Form1(bool timer, String Username)
        {
            InitializeComponent();
            Timer = timer;
            scene = new Scene();
            logo = Resources.Logo;
            this.DoubleBuffered = true;
            player = new Player(Username, 0);
            soundV = new SoundPlayer("visited.wav");
            soundR = new SoundPlayer("remove1.wav");

            mouseDown = false;
            selected = new List<Dot>();
            linesDoc = new LinesDoc();
            prva = null;
            second = null;
            score = 0;
            checkType();

            try
            {
                if (!File.Exists("HighScores.bin"))
                {
                    List<Player> list = new List<Player>();

                    list.Add(new Player("Ana", 100)); 
                    list.Add(new Player("Filip", 70)); 
                    list.Add(new Player("Nena", 89));
                    list.Add(new Player("Zan", 120));
                    list.Add(new Player("Marija", 56));

                    Stream stream = File.Create("HighScores.bin");

                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Context = new StreamingContext(StreamingContextStates.CrossAppDomain);
                    bf.Serialize(stream, list);

                    stream.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void checkType()
        {
            if (Timer)
            {
                lblMode.Text = "Remaining time: ";
                lblValue.Text = "60";
                count = 60;
                timer1.Start();
            }
            else
            {
                lblMode.Text = "Moves left: ";
                lblValue.Text = "30";
                count = 30;
            }
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Brush brush = new SolidBrush(Color.FromArgb(50, 100, 100, 100));
            g.FillRectangle(brush, 65, 155, 250, 250);
            scene.drawMatrix(g);
            g.DrawImageUnscaled(logo, 0, 0);
            if (mouseDown && line != null)
            {
                line.Draw(g);
            }
            linesDoc.DrawLines(g);


        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (scene.matrix.HitDot(e.X, e.Y) != null)
            {
                prva = scene.matrix.HitDot(e.X, e.Y);
                currentColor = prva.Colorr();
                prva.visited = true;
                soundV.Play();
            }
            else
            {
                prva = null;
            }

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            if (linesDoc.Count() > 0)
            {

                lblPoeni.Text = scene.Poeni(lblPoeni.Text);
                soundR.Play();
                scene.removeVisited();
            }
            if (!Timer)
            {
                int potezi = Convert.ToInt16(lblValue.Text);
                if (potezi == 1)
                {   
                    
                    score = Convert.ToInt16(lblPoeni.Text);
                    player.Score = score;
                    saveHighScore();
                    count = 0;                    
                    lblPoeni.Text = "0";                    

                }
                else
                {
                    lblValue.Text = (potezi - 1).ToString();
                    count = potezi - 1;
                }

            }
            linesDoc = new LinesDoc();
            prva = null;
            second = null;
            line = null;
            scene.Reload();


        }

        private bool isValid(Dot pom)
        {
            if (pom != null && pom.Colorr().Equals(currentColor) && pom.visited == false &&
                   (
                   (pom.x() == prva.x() && Math.Abs(pom.y() - prva.y()) <= (40))
                   || (pom.y() == prva.y() && Math.Abs(pom.x() - prva.x()) <= (40))))
            {

                return true;

            }
            return false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && prva != null)
            {
                line = new Line(new Point((int)prva.x(), (int)prva.y()), new Point(e.X, e.Y), currentColor);

                if (scene.matrix.HitDot(e.X, e.Y) != null)
                {
                    second = scene.matrix.HitDot(e.X, e.Y);
                    if (isValid(second))
                    {
                        line = new Line(new Point((int)prva.x(), (int)prva.y()), new Point((int)second.x(), (int)second.y()), currentColor);
                        second.visited = true;
                        prva = second;
                        linesDoc.AddLine(line);
                        soundV.Play();
                    }


                }
            }

            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sekundi = Convert.ToInt16(lblValue.Text);
            if (sekundi == 0)
            {

                    timer1.Stop();
                    score = Convert.ToInt16(lblPoeni.Text);
                    player.Score = score;
                    saveHighScore();     
                    lblPoeni.Text = "0";
                    //HighScoresForm hs = new HighScoresForm();
                    //hs.ShowDialog();
                

                
            }
            else
            {
                lblValue.Text = (sekundi - 1).ToString();
                count = sekundi - 1;
            }

        }
        
   
        public void saveHighScore()
        {
            System.Diagnostics.Debug.WriteLine("save high score form1");
            Stream stream = File.OpenRead("HighScores.bin");
            BinaryFormatter bf = new BinaryFormatter();

            List<Player> list = (List<Player>)bf.Deserialize(stream);
                        
            list.Add(player);
            stream.Close();
            File.Create("HighScores.bin").Dispose();
            stream = File.Create("HighScores.bin");

            bf = new BinaryFormatter();
            bf.Context = new StreamingContext(StreamingContextStates.CrossAppDomain);
            bf.Serialize(stream, list);
            stream.Flush();
            stream.Close();
            finished = true;
            
        } 

    }
}
