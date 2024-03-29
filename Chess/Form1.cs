﻿using System;
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
        private static int minutes = 0;
        private static int seconds = 0;

        /// <summary>
        /// Load the interface and playing objects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <algo>
        /// if the game has not been started:
        /// get the value from timeSetNumericInput and put it in the timers
        /// of the white and black players
        /// also set their amount of seconds at 00
        /// enable toolstrip items end current game and pause/resume
        /// start the game
        /// make white begin first
        /// enable the boxes
        /// start the timer
        /// 
        /// else:
        /// if it is not white's turn
        /// get the moves from functions.move array and put it in black's move history list
        /// make whiteTurn true
        /// 
        /// else:
        /// get the moves from functions.move array and put it in white's move history list
        /// make whiteTurn false
        /// </algo>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimeStop_Click(object sender, EventArgs e)
        {
            if (gameStarted == false)
            {
                setGameTime(timeSetNumericInput.Value.ToString(), "00", true);
                setGameTime(timeSetNumericInput.Value.ToString(), "00", false);
                minutes = Convert.ToInt32(timeSetNumericInput.Value);
                endCurrentGameToolStripMenuItem.Enabled = true;
                pauseResumeToolStripMenuItem.Enabled = true;
                gameStarted = true;
                whiteTurn = true;
                Functions.enableBoxes();
                timer1.Start();
            }
            else
            {
                string gamePiece = Chess.box[Functions.move[2], Functions.move[3]].Text;
                if (whiteTurn == false)
                {
                    minutes = Int32.Parse(lblWhiteMin.Text);
                    seconds = Int32.Parse(lblWhiteSec.Text);
                    string move = gamePiece +": "+ Functions.move[0] + "," + Functions.move[1] + " => " + Functions.move[2] + "," + Functions.move[3];
                    lbBlack.Items.Add(move);
                    whiteTurn = true;
                }
                else
                {
                    minutes = Int32.Parse(lblBlackMin.Text);
                    seconds = Int32.Parse(lblBlackSec.Text);
                    string move = gamePiece + ": " + Functions.move[0] + "," + Functions.move[1] + " => " + Functions.move[2] + "," + Functions.move[3];
                    lbWhite.Items.Add(move);
                    whiteTurn = false;
                }
            }
        }

        /// <summary>
        /// set the time minutes and seconds for one of the players or both
        /// depending on the black or white integer
        /// </summary>
        /// <algo>
        /// true = white
        /// false = black
        /// </algo>
        /// <param name="offsetMin"></param>
        /// <param name="offsetSec"></param>
        /// <param name="blackOrWhite"></param>
        private void setGameTime(string offsetMin, string offsetSec, bool blackOrWhite)
        {
            if (blackOrWhite)
            {
                lblWhiteMin.Text = offsetMin;
                lblWhiteSec.Text = offsetSec;
            }
            else
            {
                lblBlackMin.Text = offsetMin;
                lblBlackSec.Text = offsetSec;
            }
        }

        /// <summary>
        /// count down to 0 depending on whose turn it is
        /// </summary>
        /// <algo>
        /// if it is white's turn:
        /// count down with each second
        /// if the seconds hit 00
        /// do a decrement on the minutes and set seconds back to 60
        /// show the seconds and minutes left to the user
        /// 
        /// if it is black's turn:
        /// do the same but for black
        /// </algo>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds == 0)
            {
                minutes--;
                seconds = 60;
            }
            seconds--;

            if (whiteTurn == true)
            {
                setGameTime(minutes.ToString(), seconds.ToString(), true);
            }
            else
            {
                setGameTime(minutes.ToString(), seconds.ToString(), false);
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
        /// <algo>
        /// Disable all boxes
        /// stop the timer
        /// </algo>
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
        /// <algo>
        /// Load the playing objects
        /// clean up moved playing objects
        /// clear all indicators of made moves and possible moves
        /// clear move history of white
        /// clear move history of black
        /// set gameStarted to false
        /// </algo>
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
        /// <algo>
        /// Disable all boxes
        /// Stop the timer
        /// 
        /// from the toolstrip menu:
        /// enable new game button
        /// disable pause/resume button
        /// disable end current game button
        /// </algo>
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

        /// <summary>
        /// Show a message about which letter which gamepiece is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamepiecesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("p = pawn \n\rr = rook \n\rk = knight \n\rb = bischop \n\rQ = queen \n\rK = king");
        }

        /// <summary>
        /// Show a message about how to use the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use the 'Time' button to start the game if not started and press it during the game after every move you make.\n\r" +
                "If you checked the oponent, press the 'Check' button\n\r" +
                "If you made your oponent checkmate, press the 'Checkmate' button");
        }

        /// <summary>
        /// Show a message about the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chess BETA V1.1\n\r" +
                "Developed by Yirnick van Dijk");
        }

        /// <summary>
        /// Pause or resume the game
        /// </summary>
        /// <algo>
        /// if the game is not paused already,
        /// pause the game by disabling the boxes,
        /// stop the timer and let the program know the game is paused
        /// 
        /// else,
        /// Enable the boxes,
        /// start the timer and let the program know the game is resumed
        /// </algo>
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
