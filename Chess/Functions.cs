using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Functions
    {
        public static bool buttonSelected = false;
        public static int[] move = new int[4];
        public static Color color = Color.Transparent;
        public static bool specialMove = false;

        /// <summary>
        /// Calculate possible movements per chesspiece
        /// </summary>
        /// <algo>
        /// get row number and column number from the box
        /// 
        /// if the button is already selected
        /// make new integers oldRow and oldColumn and fil them with the first two numbers from move array
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
        /// fill move[0] with row
        /// fill move[1] with column
        /// set buttonSelect to true
        /// 
        /// Calculate the moves for a specific gamepiece if it's clicked.
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
                isOpponent(row, column);

                int oldRow = move[0];
                int oldColumn = move[1];
                move[2] = row;
                move[3] = column;

                if (specialMove == false)
                {
                    movePiece(row, column, oldRow, oldColumn);
                    makeMadeMoveVisible(oldRow, oldColumn, row, column);
                }
                else
                {
                    specialMove = false;
                }

                clearMoveIndicators(false);

                buttonSelected = false;
            }
            else
            {
                move[0] = row;
                move[1] = column;
                buttonSelected = true;
                color = Chess.box[row, column].ForeColor;
                switch (Chess.box[row, column].Text)
                {
                    case "p":
                        Moves.calcMovesPawn(row, column, color);
                        break;
                    case "r":
                        Moves.calcMovesTower(row, column, color);
                        Moves.calcCastling(row, column);
                        break;
                    case "k":
                        Moves.calcMovesKnight(row, column, color);
                        break;
                    case "b":
                        Moves.calcMovesBischop(row, column, color);
                        break;
                    case "Q":
                        Moves.calcMovesBischop(row, column, color);
                        Moves.calcMovesTower(row, column, color);
                        break;
                    case "K":
                        Moves.calcMovesKing(row, column, color);
                        Moves.calcCastling(row, column);
                        break;
                }
                disableBoxes(false);
            }
        }

        /// <summary>
        /// Move the piece from it's old row and old column
        /// to the current row and current column
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void movePiece(int row, int column, int oldRow, int oldColumn)
        {
            Chess.box[row, column].Text = Chess.box[oldRow, oldColumn].Text;
            Chess.box[oldRow, oldColumn].Text = "";

            if (Chess.box[oldRow, oldColumn].ForeColor == Color.White)
            {
                Chess.box[row, column].ForeColor = Color.White;
                Chess.box[oldRow, oldColumn].ForeColor = Color.Transparent;
            }
            else
            {
                Chess.box[row, column].ForeColor = Color.Black;
                Chess.box[oldRow, oldColumn].ForeColor = Color.Transparent;
            }
        }

        /// <summary>
        /// Check if gamepiece is the opponent to be conquered
        /// If it's not the opponent, make castling move
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void isOpponent(int row, int column)
        {
            if (Chess.box[row, column].ForeColor != Color.Transparent && Chess.box[row, column].ForeColor != color)
            {
                ChessPieces.color = Chess.box[row, column].ForeColor;
                ChessPieces.chessPiece = Chess.box[row, column].Text;
                ChessPieces.conquered = true;
            }
            else
            {
                if (Chess.box[row, column].Text == "K" || Chess.box[row, column].Text == "r")
                {
                    castle();
                }
            }
        }

        /// <summary>
        /// Make the castle move in Chess
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void castle()
        {
            specialMove = true;
            for (int r = 0; r < Chess.boxes; r++)
            {
                for (int c = 0; c < Chess.boxes; c++)
                {
                    if (Chess.box[r, c].Text == "K" && c == 4 && Chess.box[r, c].ForeColor == color)
                    {
                        Chess.box[r, c].Text = "";
                        Chess.box[r, c].ForeColor = Color.Transparent;
                        Chess.box[r, c + 2].Text = "K";
                        Chess.box[r, c + 2].ForeColor = color;
                    }
                    else
                    {
                        if (Chess.box[r, c].Text == "r" && c != 0 && Chess.box[r, c].ForeColor == color)
                        {
                            Chess.box[r, c].Text = "";
                            Chess.box[r, c].ForeColor = Color.Transparent;
                            Chess.box[r, c - 2].Text = "r";
                            Chess.box[r, c - 2].ForeColor = color;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Make made moves visible each time a player moves a piece
        /// </summary>
        /// <algo>
        /// Loop over the rows and columns:
        /// if the backcolor of the box on row, column is orange,
        /// make the backcolor of that box gray
        /// 
        /// Make the backcolor of the previous box orange
        /// Make the backcolor of the occupied box orange
        /// </algo>
        /// <param name="oldRow"></param>
        /// <param name="oldColumn"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private static void makeMadeMoveVisible(int oldRow, int oldColumn, int row, int column)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (Chess.box[r, c].BackColor == Color.Orange)
                    {
                        Chess.box[r, c].BackColor = Color.Gray;
                    }
                }
            }

            Chess.box[oldRow, oldColumn].BackColor = Color.Orange;
            Chess.box[row, column].BackColor = Color.Orange;
        }

        /// <summary>
        /// Returns true if box has text and forecolor is not the same as current forecolor
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool blockage(int row, int column)
        {
            if (Chess.box[row, column].Text != "")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Make a box green based on the rowm, column and forecolor.
        /// </summary>
        /// <algo>
        /// If the forecolor of the box is equal to forecolor,
        /// make the backcolor of that box green
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="foreColor"></param>
        public static void checkColor(int row, int column, Color foreColor)
        {
            if (foreColor == Color.White)
            {
                if (Chess.box[row, column].ForeColor == Color.Black)
                {
                    Chess.box[row, column].BackColor = Color.Green;
                }
                else
                {
                    if (Chess.box[move[0], move[1]].Text != "p" && Chess.box[row, column].ForeColor != foreColor)
                    {
                        Chess.box[row, column].BackColor = Color.Green;
                    }
                }
            }
            else
            {
                if (Chess.box[row, column].ForeColor == Color.White)
                {
                    Chess.box[row, column].BackColor = Color.Green;
                }
                else
                {
                    if (Chess.box[move[0], move[1]].Text != "p" && Chess.box[row, column].ForeColor != foreColor)
                    {
                        Chess.box[row, column].BackColor = Color.Green;
                    }
                }
            }
        }

        /// <summary>
        /// Make a box green based on it's row, column and if they contain text.
        /// </summary>
        /// <algo>
        /// If the text on the box is "",
        /// make the backcolor of that row green.
        /// And return row.
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static int checkText(int row, int column, bool returnRow)
        {
            if (Chess.box[row, column].Text == "")
            {
                Chess.box[row, column].BackColor = Color.Green;
            }
            if (returnRow)
            {
                return row;
            }
            else
            {
                return column;
            }
        }

        /// <summary>
        /// Disable every box which is not green if the bool parameter is false.
        /// </summary>
        /// <algo>
        /// loop over each row:
        /// loop over each column:
        /// if fullyDisable is true:
        /// disable the box on r and c
        /// 
        /// else:
        /// if the backcolor of the current box it's color is not green:
        /// disable the current box
        /// </algo>
        public static void disableBoxes(bool fullyDisable)
        {
            for (int r = 0; r < Chess.boxes; r++)
            {
                for (int c = 0; c < Chess.boxes; c++)
                {
                    if (fullyDisable == true)
                    {
                        Chess.box[r, c].Enabled = false;
                    }
                    else
                    {
                        if (Chess.box[r, c].BackColor != Color.Green && Chess.box[r, c].BackColor != Color.Orange)
                        {
                            Chess.box[r, c].Enabled = false;
                        }
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
        /// 
        /// else:
        /// 
        /// if cleanup is false:
        /// enable the box on r and c
        /// </algo>
        public static void clearMoveIndicators(bool cleanup)
        {
            for (int r = 0; r < Chess.boxes; r++)
            {
                for (int c = 0; c < Chess.boxes; c++)
                {
                    if (Chess.box[r, c].BackColor != Color.Gray)
                    {
                        Chess.box[r, c].BackColor = Color.Gray;
                    }
                    if (cleanup == false)
                    {
                        Chess.box[r, c].Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Enable all boxes
        /// </summary>
        /// <algo>
        /// loop over the rows
        /// loop over the columns
        /// enable the box on r and c
        /// </algo>
        internal static void enableBoxes()
        {
            for (int r = 0; r < Chess.boxes; r++)
            {
                for (int c = 0; c < Chess.boxes; c++)
                {
                    Chess.box[r, c].Enabled = true;
                }
            }
        }
    }
}
