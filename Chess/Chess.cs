using System;
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
        /// 
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
                    default:
                        break;
                }
            }
        }


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
                }
            }
        }

        /// <summary>
        /// Calculate the possible moves for the pawn
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="foreColor"></param>
        private static void calcMovesPawn(int row, int column, Color foreColor)
        {
            if (foreColor == Color.White)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (Chess.box[row - 1, column].Text == "")
                    {
                        row = row - 1;
                        Chess.box[row, column].BackColor = Color.Green;
                    }
                }
                if (Chess.box[row - 1, column - 1].ForeColor == Color.Black)
                {
                    Chess.box[row - 1, column - 1].BackColor = Color.Green;
                }
                else
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
                    if (Chess.box[row + 1, column].Text == "")
                    {
                        row = row + 1;
                        Chess.box[row, column].BackColor = Color.Green;
                    }
                }
            }
        }
    }
}
