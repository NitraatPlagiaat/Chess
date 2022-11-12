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
        private static bool gamePaused = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            Chess.makeInterface(chessPanel);
            Chess.loadPlayingObjects();
            menuNewGame.Enabled = false;
            endCurrentGameToolStripMenuItem.Enabled = false;
            pauseResumeToolStripMenuItem.Enabled = false;
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
                lblWhiteMin.Text = timeSetNumericInput.Value.ToString();
                lblWhiteSec.Text = "00";
                lblBlackMin.Text = timeSetNumericInput.Value.ToString();
                lblBlackSec.Text = "00";
                endCurrentGameToolStripMenuItem.Enabled = true;
                pauseResumeToolStripMenuItem.Enabled = true;
                gameStarted = true;
                whiteTurn = true;
                Functions.enableBoxes();
                timer1.Start();
            }
            else
            {
                if (whiteTurn == false)
                {
                    string move = Functions.move[0] + "," + Functions.move[1] + " => " + Functions.move[2] + "," + Functions.move[3];
                    lbBlack.Items.Add(move);
                    whiteTurn = true;
                }
                else
                {
                    string move = Functions.move[0] + "," + Functions.move[1] + " => " + Functions.move[2] + "," + Functions.move[3];
                    lbWhite.Items.Add(move);
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
        /// <algo>
        /// Loop over the rows and columns
        /// if the forecolor of the box is not equal to the color in Functions.color
        /// AND if the text of the box is K
        /// then make the box it's backcolor red.
        /// </algo>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (Chess.box[r, c].ForeColor != Functions.color && Chess.box[r, c].Text == "K")
                    {
                        Chess.box[r, c].BackColor = Color.Red;
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

        /// <summary>
        /// Start a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewGame_Click(object sender, EventArgs e)
        {
            Chess.loadPlayingObjects();
            Chess.cleanPlayingObjects();
            Functions.clearMoveIndicators(true);
            lbWhite.Items.Clear();
            lbBlack.Items.Clear();
            gameStarted = false;
        }

        /// <summary>
        /// End the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endCurrentGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.disableBoxes(true);
            timer1.Stop();
            menuNewGame.Enabled = true;
            pauseResumeToolStripMenuItem.Enabled = false;
            endCurrentGameToolStripMenuItem.Enabled = false;
        }

        private void gamepiecesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("p = pawn \n\rr = rook \n\rk = knight \n\rb = bischop \n\rQ = queen \n\rK = king");
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use the 'Time' button to start the game if not started and press it during the game after every move you make.\n\r" +
                "If you checked the oponent, press the 'Check' button\n\r" +
                "If you made your oponent checkmate, press the 'Checkmate' button");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chess ALPHA V2\n\r" +
                "Developed by Yirnick van Dijk");
        }

        /// <summary>
        /// Pause or resume the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseResumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gamePaused == false)
            {
                Functions.disableBoxes(true);
                timer1.Stop();
                gamePaused = true;
            }
            else
            {
                Functions.enableBoxes();
                timer1.Start();
                gamePaused = false;
            }
        }
    }
}
