using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static bool gameStarted = false;
        private static bool whiteTurn = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            Chess.makeInterface(this);
            Chess.loadPlayingObjects();
        }

        /// <summary>
        /// Start the timer and switch players timers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimeStop_Click(object sender, EventArgs e)
        {
            if (gameStarted == false)
            {
                gameStarted = true;
                whiteTurn = true;
                Functions.enableBoxes();
                timer1.Start();
            }
            else
            {
                if (whiteTurn == false)
                {
                    for (int i = 0; i < Functions.selected.Length; i++)
                    {
                        lbBlack.Items.Add(Functions.selected[i]);
                    }
                    whiteTurn = true;
                }
                else
                {
                    for (int i = 0; i < Functions.selected.Length; i++)
                    {
                        lbWhite.Items.Add(Functions.selected[i]);
                    }
                    whiteTurn = false;
                }
            }
        }

        /// <summary>
        /// count down to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (whiteTurn == true)
            {
                int min = Int32.Parse(lblWhiteMin.Text);
                int sec = Int32.Parse(lblWhiteSec.Text);

                if (sec == 0)
                {
                    min--;
                    sec = 60;
                }
                sec--;
                lblWhiteMin.Text = min.ToString();
                lblWhiteSec.Text = sec.ToString();
            }
            else
            {
                int min = Int32.Parse(lblBlackMin.Text);
                int sec = Int32.Parse(lblBlackSec.Text);

                if (sec == 0)
                {
                    min--;
                    sec = 60;
                }
                sec--;
                lblBlackMin.Text = min.ToString();
                lblBlackSec.Text = sec.ToString();
            }
        }

        /// <summary>
        /// Declare the oponent check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (whiteTurn == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Chess.box[i, j].ForeColor == Color.Black && Chess.box[i, j].Text == "K")
                        {
                            Chess.box[i, j].BackColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Chess.box[i, j].ForeColor == Color.White && Chess.box[i, j].Text == "K")
                        {
                            Chess.box[i, j].BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Declare the oponent checkmate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckmate_Click(object sender, EventArgs e)
        {
            Functions.disableBoxes(true);
            timer1.Stop();
        }
    }
}
