using System;
using System.Data.Common;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Chess
{
    class ChessPieces
    {
        public static string[] pieces = new string[]
        {
            "r",
            "k",
            "b",
            "Q",
            "K",
            "b",
            "k",
            "r"
        };

        public static bool conquered = false;
        public static string chessPiece;
        public static Color color;
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
        internal static void makeInterface(Panel board)
        {
            box = new ChessButton[boxes, boxes];
            int h = board.Height;
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
                    box[r, c].ForeColor = Color.Transparent;
                    box[r, c].Row = r;
                    box[r, c].Column = c;
                    box[r, c].Enabled = false;
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
                            box[r, c].Text = "p";
                            box[r, c].ForeColor = Color.Black;
                            break;
                        case 6:
                            box[r, c].Text = "p";
                            box[r, c].ForeColor = Color.White;
                            break;
                        case 7:
                            box[r, c].Text = ChessPieces.pieces[c];
                            box[r, c].ForeColor = Color.White;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Clean the remaining playing objects used in the last game
        /// </summary>
        /// <algo>
        /// Loop over the rows between the range of 2 and 6:
        /// Loop over the columns until 8:
        /// 
        /// if a box is not empty:
        /// make the text of the box on r and c ""
        /// make the forecolor of the box on r and c transparent
        /// 
        /// Disabel all boxes
        /// </algo>
        internal static void cleanPlayingObjects()
        {
            for (int r = 2; r < 6; r++)
            {
                for (int c = 0; c < boxes; c++)
                {
                    if (box[r, c].Text != "")
                    {
                        box[r, c].Text = "";
                        box[r, c].ForeColor = Color.Transparent;
                    }
                }
            }
            Functions.disableBoxes(true);
        }
    }
}
