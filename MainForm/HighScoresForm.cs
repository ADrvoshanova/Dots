using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class HighScoresForm : Form
    {
        public HighScoresForm()
        {
            InitializeComponent();
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
                    stream.Flush();
                    stream.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
            showScores();
        }

        public void showScores()
        {
            Stream stream = File.OpenRead("HighScores.bin");
            BinaryFormatter bf = new BinaryFormatter();

            List<Player> list = (List<Player>)bf.Deserialize(stream);

            list.Sort(
                delegate(Player p1, Player p2)
           {
               return -(p1.Score.CompareTo(p2.Score));
           }
            );
            stream.Close();
            fillLabels(list);

        }

        public void fillLabels(List<Player> list)
        { 
            lbl1.Text = list[0].Username;
            lbl2.Text = list[1].Username;
            lbl3.Text = list[2].Username;
            lbl4.Text = list[3].Username;
            lbl5.Text = list[4].Username;
            lbl6.Text = list[0].Score.ToString();
            lbl7.Text = list[1].Score.ToString();
            lbl8.Text = list[2].Score.ToString();
            lbl9.Text = list[3].Score.ToString();
            lbl10.Text = list[4].Score.ToString();

        }   
        
    }
}
