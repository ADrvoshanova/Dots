using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class MainForm : Form
    {
        Player player;
        Form1 myForm;
        public MainForm()
        {
            InitializeComponent();
            pnlMainFrame.Visible = true;
            pnlMainFrame.Dock = DockStyle.Fill;
            pnlUserName.Visible = false;
            pnlChoose.Visible = false;
            pnlHighScores.Visible = false;
            pnlTimedDots.Visible = false;
            pnlRules.Visible = false;
            
            
            player = new Player("", 0);

        }
        private void btnNewGame_Click(object sender, EventArgs e)
        { 
            tbUsername.Clear();
            pnlMainFrame.Visible = false;
            pnlUserName.Visible = true;
            pnlUserName.Dock = DockStyle.Fill;
            tbUsername.Focus();
        }


        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (tbUsername.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(tbUsername, "Enter username!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbUsername, null);
                e.Cancel = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to quit?", 
                "Quit Game", MessageBoxButtons.YesNo);
            if(r == DialogResult.Yes)
                Application.Exit();
            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pnlUserName.Visible = false;
            player.Username = tbUsername.Text;
            pnlChoose.Visible = true;
            pnlChoose.Dock = DockStyle.Fill;

        }
        private void btnHighScores_Click(object sender, EventArgs e)
        {
            pnlMainFrame.Visible = false;
            pnlHighScores.Visible = true;
            pnlHighScores.Dock = DockStyle.Fill;
            HighScoresForm myForm = new HighScoresForm();
            myForm.TopLevel = false;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            pnlHighScores.Controls.Add(myForm);
            myForm.Show();
            pnlHighScores.Dock = DockStyle.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlHighScores.Visible = false;
            pnlMainFrame.Visible = true;
            pnlMainFrame.Dock = DockStyle.Fill;
        }

        private void btnTimed_Click(object sender, EventArgs e)
        {
            pnlTimedDots.Visible = true;
            pnlChoose.Visible = false;
            myForm = new Form1(true, player.Username);
            myForm.TopLevel = false;
            pnlTimedDots.Controls.Add(myForm);
            myForm.Left = (this.Width - myForm.Width) / 2;
            myForm.Top = (this.Height - myForm.Height) / 2;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            myForm.AutoScroll = true;
            myForm.Show();        
            pnlTimedDots.Dock = DockStyle.Fill;
            timer2.Start();

        }

        private void btnMoves_Click(object sender, EventArgs e)
        {
            pnlTimedDots.Visible = true;
            pnlTimedDots.Dock = DockStyle.Fill;
            pnlChoose.Visible = false;
            myForm = new Form1(false, player.Username);
            myForm.TopLevel = false;
            pnlTimedDots.Controls.Add(myForm);
            myForm.Left = (this.Width - myForm.Width) / 2;
            myForm.Top = (this.Height - myForm.Height) / 2;
            myForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            myForm.Show();
            timer2.Start();
           

        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            pnlRules.Visible = true;
            pnlRules.Dock = DockStyle.Fill;
            pnlMainFrame.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlMainFrame.Visible = true;
            pnlMainFrame.Dock = DockStyle.Fill;
            pnlRules.Visible = false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            pnlMainFrame.Visible = true;
            pnlMainFrame.Dock = DockStyle.Fill;
            pnlTimedDots.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("tick");
            if (myForm.count == 0 && myForm.finished == true)
            {
                
                System.Diagnostics.Debug.WriteLine("timer2 finished");
                player.Score = myForm.score;
                pnlMainFrame.Visible = false;
                pnlHighScores.Visible = true;
                pnlHighScores.Dock = DockStyle.Fill;
                //myForm.saveHighScore();
                HighScoresForm hs = new HighScoresForm();
                hs.TopLevel = false;
                hs.FormBorderStyle = FormBorderStyle.None;
                hs.Dock = DockStyle.Fill;
                pnlHighScores.Controls.Add(hs);
                hs.Show();
                pnlHighScores.Dock = DockStyle.Fill;
                pnlTimedDots.Visible = false;
                myForm.Hide();
                timer2.Stop();
            }
           
        }



    }
}
