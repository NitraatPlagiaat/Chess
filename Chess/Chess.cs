﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class ChessPieces
    {
        public static string[] pieces = new string[]
        {
            "T",
            "R",
            "B",
            "Q",
            "K",
            "B",
            "R",
            "T"
        };
    }

    class ChessButton : Button
    {
        public int Row;
        public int Column;
    }

    class Chess
    {
        public static ChessButton[,] box;
        public static int boxes = 8;

        /// <summary>
        /// Make the interface 8x8 on board
        /// </summary>
        /// <algo>
        /// Make a new modified button box from ChessButton
        /// Make int h with the height of the clientsize
        /// make int w h
        /// 
        /// loop over r
        /// loop over c
        /// 
        /// make on the box r and c dimension the following:
        /// new ChessButton
        /// new Size that's the width and height devided by boxes
        /// Make the location based on r and c and boxes,
        /// do c times w divided by boxes and r times h divided by boxes
        /// when a box is clicked, run a function in class Functions
        /// make the boxes background color gray
        /// make the row of the boxes r
        /// make the column of the boxes c
        /// add the boxes to the controls of board
        /// </algo>
        /// <param name="board"></param>
        internal static void makeInterface(Control board)
        {
            box = new ChessButton[boxes, boxes];
            int h = board.ClientSize.Height;
            int w = h;
            for (int r = 0; r < boxes; r++)
            {
                for (int c = 0; c < boxes; c++)
                {
                    box[r, c] = new ChessButton();
                    box[r, c].Size = new Size(w / boxes, h / boxes);
                    box[r, c].Location = new Point(c * w / boxes, r * h / boxes);
                    box[r, c].Click += Functions.box_click;
                    box[r, c].BackColor = Color.Gray;
                    box[r, c].Row = r;
                    box[r, c].Column = c;
                    board.Controls.Add(box[r, c]);
                }
            }
        }

        /// <summary>
        /// Load game pieces per box
        /// </summary>
        /// <algo>
        /// loop over the rows of the board
        /// loop over the columns of the board
        /// in case the row number is 0, put all black chesspieces other than pawn on row 0
        /// in case the row number is 1, put all black pawn pieces on row 1
        /// in case the row number is 6, put all white pawn pieces on row 6
        /// in case the row number is 7, put all white chesspieces other than pawn on row 7
        /// </algo>
        internal static void loadPlayingObjects()
        {
            for (int r = 0; r < boxes; r++)
            {
                for (int c = 0; c < boxes; c++)
                {
                    switch (r)
                    {
                        case 0:
                            box[r, c].Text = ChessPieces.pieces[c];
                            box[r, c].ForeColor = Color.Black;
                            break;
                        case 1:
                            box[r, c].Text = "P";
                            box[r, c].ForeColor = Color.Black;
                            break;
                        case 6:
                            box[r, c].Text = "P";
                            box[r, c].ForeColor = Color.White;
                            break;
                        case 7:
                            box[r, c].Text = ChessPieces.pieces[c];
                            box[r, c].ForeColor = Color.White;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    class Functions
    {
        public static int[] selected = new int[2];
        public static bool buttonSelected = false;

        /// <summary>
        /// Calculate possible movements per chesspiece
        /// </summary>
        /// <algo>
        /// get row number and column number from the box
        /// 
        /// if the button is already selected
        /// make new integers oldRow and oldColumn and fil them with the numbers from selected array
        /// make the text of the current clicked box the same text as the previous clicked box
        /// make the previous clicked box it's text blank
        /// 
        /// if the forecolor of the previous clicked box is white,
        /// make the current clicked box it's forecolor also white
        /// else make the current clicked box it's forecolor black
        /// 
        /// clear the possible moves boxes
        /// 
        /// set buttonSelected to false
        /// 
        /// else
        /// fill selected[0] with row
        /// fill selected[1] with column
        /// set buttonSelect to true
        /// 
        /// in case the pawn is clicked, calculate the possible movements for the pawn,
        /// in case the tower is clicked, calculate the possible moveemnts for the tower
        /// </algo>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void box_click(object sender, EventArgs e)
        {
            var btn = (dynamic)sender;
            int row = btn.Row;
            int column = btn.Column;

            if (buttonSelected == true)
            {
                int oldRow = selected[0];
                int oldColumn = selected[1];

                Chess.box[row, column].Text = Chess.box[oldRow, oldColumn].Text;
                Chess.box[oldRow, oldColumn].Text = "";

                if (Chess.box[oldRow, oldColumn].ForeColor == Color.White)
                {
                    Chess.box[row, column].ForeColor = Color.White;
                }
                else
                {
                    Chess.box[row, column].ForeColor = Color.Black;
                }

                clearPossibleMoves();

                buttonSelected = false;
            }
            else
            {
                selected[0] = row;
                selected[1] = column;
                buttonSelected = true;
                switch (Chess.box[row, column].Text)
                {
                    case "P":
                        calcMovesPawn(row, column, Chess.box[row, column].ForeColor);
                        break;
                    case "T":
                        calcMovesTower(row, column, Chess.box[row, column].ForeColor);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void calcMovesTower(int row, int column, Color foreColor)
        {
            int newRow = row;
            int newColumn = column;
            while (newRow != 0)
            {
                if (Chess.box[newRow - 1, column].Text == "")
                {
                    newRow = newRow - 1;
                    Chess.box[newRow, column].BackColor = Color.Green;
                }
                else
                {
                    if (Chess.box[newRow - 1, column].ForeColor == Color.Black)
                    {
                        Chess.box[newRow - 1, column].BackColor = Color.Green;
                    }
                    break;
                }
            }
            newRow = row;
            while (newRow != 7)
            {
                if (Chess.box[newRow + 1, column].Text == "")
                {
                    newRow = newRow + 1;
                    Chess.box[newRow, column].BackColor = Color.Green;
                }
                else
                {
                    if (Chess.box[newRow + 1, column].ForeColor == Color.Black)
                    {
                        Chess.box[newRow + 1, column].BackColor = Color.Green;
                    }
                    break;
                }
            }
            newRow = row;
            while (newColumn != 7)
            {
                if (Chess.box[row, newColumn + 1].Text == "")
                {
                    newColumn = newColumn + 1;
                    Chess.box[row, newColumn].BackColor = Color.Green;
                }
                else
                {
                    if (Chess.box[row, newColumn + 1].ForeColor == Color.Black)
                    {
                        Chess.box[row, newColumn + 1].BackColor = Color.Green;
                    }
                    break;
                }
            }
            newColumn = column;
            while (newColumn != 0)
            {
                if (Chess.box[row, newColumn - 1].Text == "")
                {
                    newColumn = newColumn - 1;
                    Chess.box[row, newColumn].BackColor = Color.Green;
                }
                else
                {
                    if (Chess.box[row, newColumn - 1].ForeColor == Color.Black)
                    {
                        Chess.box[row, newColumn - 1].BackColor = Color.Green;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Calculate the possible moves for the pawn
        /// </summary>
        /// <algo>
        /// Make a new int newRow and make that row
        /// 
        /// Check the white player first
        /// loop 2 times because the pawn can move 2 boxes ata time
        /// if there is no other player on column and row - 1,
        /// make row - 1, column green
        /// 
        /// check if you can beat a black piece with the pawn:
        /// if row - 1 and column - 1 is occupied by black,
        /// make the box from the black player green
        /// Else, if row - 1 and column + 1 is occupied by black,
        /// make the box from the black player green
        /// 
        /// do the same for the black player but the opposite way.
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="foreColor"></param>
        private static void calcMovesPawn(int row, int column, Color foreColor)
        {
            int newRow = row;
            if (foreColor == Color.White)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (row >= 2)
                    {
                        if (Chess.box[newRow - 1, column].Text == "")
                        {
                            newRow = newRow - 1;
                            Chess.box[newRow, column].BackColor = Color.Green;
                        }
                    }
                }
                if (column != 0 && row != 0)
                {
                    if (Chess.box[row - 1, column - 1].ForeColor == Color.Black)
                    {
                        Chess.box[row - 1, column - 1].BackColor = Color.Green;
                    }
                }
                if (column != 7 && row != 0)
                {
                    if (Chess.box[row - 1, column + 1].ForeColor == Color.Black)
                    {
                        Chess.box[row - 1, column + 1].BackColor = Color.Green;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (row <= 5)
                    {
                        if (Chess.box[row + 1, column].Text == "")
                        {
                            newRow = newRow + 1;
                            Chess.box[newRow, column].BackColor = Color.Green;
                        }
                    }
                }
                if (column != 7 && row != 7)
                {
                    if (Chess.box[row + 1, column + 1].ForeColor == Color.White)
                    {
                        Chess.box[row + 1, column + 1].BackColor = Color.Green;
                    }
                }
                if (column != 0 && row != 7)
                {
                    if (Chess.box[row + 1, column - 1].ForeColor == Color.White)
                    {
                        Chess.box[row + 1, column - 1].BackColor = Color.Green;
                    }
                }
            }
            disableBoxes();
        }

        /// <summary>
        /// Disable every box that is not green colored
        /// </summary>
        /// <algo>
        /// loop over each row
        /// loop over each column
        /// if the backcolor of the current box it's color is not green
        /// disable the current box
        /// </algo>
        private static void disableBoxes()
        {
            for (int r = 0; r < Chess.boxes; r++)
            {
                for (int c = 0; c < Chess.boxes; c++)
                {
                    if (Chess.box[r, c].BackColor != Color.Green)
                    {
                        Chess.box[r, c].Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Make disabled boxes enabled and make every green box gray again
        /// </summary>
        /// <algo>
        /// loop over each row
        /// loop over each column
        /// if the current box it's color is equal to green,
        /// make the color of the current box gray
        /// else, enable the current box
        /// </algo>
        private static void clearPossibleMoves()
        {
            for (int r = 0; r < Chess.boxes; r++)
            {
                for (int c = 0; c < Chess.boxes; c++)
                {
                    if (Chess.box[r, c].BackColor == Color.Green)
                    {
                        Chess.box[r, c].BackColor = Color.Gray;
                    }
                    else
                    {
                        Chess.box[r, c].Enabled = true;
                    }
                }
            }
        }
    }
}