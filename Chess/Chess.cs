﻿using System;
using System.Data.Common;
using System.Drawing;
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

    class Functions
    {
        public static bool buttonSelected = false;
        public static int[] move = new int[4];
        public static Color color = Color.Transparent;

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
                int oldRow = move[0];
                int oldColumn = move[1];
                move[2] = row;
                move[3] = column;

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

                clearMoveIndicators(false);
                makeMoveVisible(oldRow, oldColumn, row, column);

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
                        calcMovesPawn(row, column);
                        disableBoxes(false);
                        break;
                    case "r":
                        calcMovesTower(row, column, Chess.box[row, column].ForeColor);
                        disableBoxes(false);
                        break;
                    case "k":
                        calcMovesKnight(row, column, Chess.box[row, column].ForeColor);
                        disableBoxes(false);
                        break;
                    case "b":
                        calcMovesBischop(row, column, Chess.box[row, column].ForeColor);
                        disableBoxes(false);
                        break;
                    case "Q":
                        calcMovesBischop(row, column, Chess.box[row, column].ForeColor);
                        calcMovesTower(row, column, Chess.box[row, column].ForeColor);
                        disableBoxes(false);
                        break;
                    case "K":
                        calcMovesKing(row, column, Chess.box[row, column].ForeColor);
                        disableBoxes(false);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void makeMoveVisible(int oldRow, int oldColumn, int row, int column)
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
        /// calc the moves for the king
        /// </summary>
        /// <algo>
        /// Check from each side if they are on the edge
        /// for top and bottom sides the edge is at row 0 and 7,
        /// for left and right sides the edge is at column 0 and 7
        /// if the rows and columns do not equal to 7 or 0,
        /// it means that the king can be moved to that position
        /// and set sides[index] to true
        /// if side[index] is true, it means that not only
        /// the king can move up and down, but potentially also can diagonal
        /// if two other indexes connecting to the corresponding index are true too.
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private static void calcMovesKing(int row, int column, Color foreColor)
        {
            bool[] sides = new bool[] { false, false, false, false };
            if (row != 0)
            {
                if (Chess.box[row - 1, column].ForeColor != foreColor)
                {
                    Chess.box[row - 1, column].BackColor = Color.Green;
                }
                sides[0] = true;
            }
            if (column != 7)
            {
                if (Chess.box[row, column + 1].ForeColor != foreColor)
                {
                    Chess.box[row, column + 1].BackColor = Color.Green;
                }
                if (sides[0] == true)
                {
                    if (Chess.box[row - 1, column + 1].ForeColor != foreColor)
                    {
                        Chess.box[row - 1, column + 1].BackColor = Color.Green;
                    }
                }
                sides[1] = true;
            }
            if (row != 7)
            {
                if (Chess.box[row + 1, column].ForeColor != foreColor)
                {
                    Chess.box[row + 1, column].BackColor = Color.Green;
                }
                if (sides[1] == true)
                {
                    if (Chess.box[row + 1, column + 1].ForeColor != foreColor)
                    {
                        Chess.box[row + 1, column + 1].BackColor = Color.Green;
                    }
                }
                sides[2] = true;
            }
            if (column != 0)
            {
                if (Chess.box[row, column - 1].ForeColor != foreColor)
                {
                    Chess.box[row, column - 1].BackColor = Color.Green;
                }
                if (sides[2] == true)
                {
                    if (Chess.box[row + 1, column - 1].ForeColor != foreColor)
                    {
                        Chess.box[row + 1, column - 1].BackColor = Color.Green;
                    }
                }
                if (sides[0] == true)
                {
                    if (Chess.box[row - 1, column - 1].ForeColor != foreColor)
                    {
                        Chess.box[row - 1, column - 1].BackColor = Color.Green;
                    }
                }
            }
        }

        /// <summary>
        /// calculate the moves for the bischop
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private static void calcMovesBischop(int row, int column, Color foreColor)
        {
            int newRow = row;
            int newColumn = column;

            while (newColumn != 0 && newRow != 0)
            {
                if (Chess.box[newRow - 1, newColumn - 1].Text == "")
                {
                    Chess.box[newRow - 1, newColumn - 1].BackColor = Color.Green;
                    newRow = newRow - 1;
                    newColumn = newColumn - 1;
                }
                else
                {
                    if (Chess.box[newRow - 1, newColumn - 1].ForeColor != foreColor)
                    {
                        Chess.box[newRow - 1, newColumn - 1].BackColor = Color.Green;
                    }
                    break;
                }
            }
            newRow = row;
            newColumn = column;
            while (newColumn != 7 && newRow != 0)
            {
                if (Chess.box[newRow - 1, newColumn + 1].Text == "")
                {
                    Chess.box[newRow - 1, newColumn + 1].BackColor = Color.Green;
                    newRow = newRow - 1;
                    newColumn = newColumn + 1;
                }
                else
                {
                    if (Chess.box[newRow - 1, newColumn + 1].ForeColor != foreColor)
                    {
                        Chess.box[newRow - 1, newColumn + 1].BackColor = Color.Green;
                    }
                    break;
                }
            }
            newRow = row;
            newColumn = column;
            while (newColumn != 0 && newRow != 7)
            {
                if (Chess.box[newRow + 1, newColumn - 1].Text == "")
                {
                    Chess.box[newRow + 1, newColumn - 1].BackColor = Color.Green;
                    newRow = newRow + 1;
                    newColumn = newColumn - 1;
                }
                else
                {
                    if (Chess.box[newRow + 1, newColumn - 1].ForeColor != foreColor)
                    {
                        Chess.box[newRow + 1, newColumn - 1].BackColor = Color.Green;
                    }
                    break;
                }
            }
            newRow = row;
            newColumn = column;
            while (newColumn != 7 && newRow != 7)
            {
                if (Chess.box[newRow + 1, newColumn + 1].Text == "")
                {
                    Chess.box[newRow + 1, newColumn + 1].BackColor = Color.Green;
                    newRow = newRow + 1;
                    newColumn = newColumn + 1;
                }
                else
                {
                    if (Chess.box[newRow + 1, newColumn + 1].ForeColor != foreColor)
                    {
                        Chess.box[newRow + 1, newColumn + 1].BackColor = Color.Green;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Calculate the possible moves for the knight
        /// </summary>
        /// <algo>
        /// check if column is greater or equal to 1 and row is greater or equal to 2
        /// if the selected piece forecolor is white ->
        /// check if the box row - 2, column - 1 isn't white
        /// if so make the backcolor of box row - 2, column - 1 green
        /// -> else check if box row - 2, column - 1 forecolor isn't black
        /// if so make the backcolor of box row - 2, column - 1 green
        /// 
        /// if column is smaller or equal to 6,
        /// if the selected piece forecolor is white ->
        /// check if the box row - 2, column + 1 isn't white
        /// if so make the backcolor of box row - 2, column + 1 green
        /// -> else check if box row - 2, column + 1 forecolor isn't black
        /// if so make the backcolor of box row - 2, column + 1 green
        /// 
        /// check if column is greater or equal to 2 and row is greater or equal to 1
        /// if the selected piece forecolor is white ->
        /// check if the box row - 1, column - 2 isn't white
        /// if so make the backcolor of box row - 1, column - 2 green
        /// -> else check if box row - 1, column - 2 forecolor isn't black
        /// if so make the backcolor of box row - 1, column - 2 green
        /// 
        /// if column is smaller or equal to 5,
        /// if the selected piece forecolor is white ->
        /// check if the box row - 1, column + 2 isn't white
        /// if so make the backcolor of box row - 1, column + 2 green
        /// -> else check if box row - 1, column + 2 forecolor isn't black
        /// if so make the backcolor of box row - 1, column + 2 green
        /// 
        /// check if column is greater or equal to 2 and row is smaller or equal to 6
        /// if the selected piece forecolor is white ->
        /// check if the box row + 1, column - 2 isn't white
        /// if so make the backcolor of box row + 1, column - 2 green
        /// -> else check if box row + 1, column - 2 forecolor isn't black
        /// if so make the backcolor of box row + 1, column - 2 green
        /// 
        /// if column is smaller or equal to 5,
        /// if the selected piece forecolor is white ->
        /// check if the box row + 1, column + 2 isn't white
        /// if so make the backcolor of box row + 1, column + 2 green
        /// -> else check if box row + 1, column + 2 forecolor isn't black
        /// if so make the backcolor of box row + 1, column + 2 green
        /// 
        /// check if column is greater or equal to 1 and row is smaller or equal to 5
        /// if the selected piece forecolor is white ->
        /// check if the box row + 2, column - 1 isn't white
        /// if so make the backcolor of box row + 2, column - 1 green
        /// -> else check if box row + 2, column - 1 forecolor isn't black
        /// if so make the backcolor of box row + 2, column - 1 green
        /// 
        /// if column is smaller or equal to 6,
        /// if the selected piece forecolor is white ->
        /// check if the box row + 2, column + 1 isn't white
        /// if so make the backcolor of box row + 2, column + 1 green
        /// -> else check if box row + 2, column + 1 forecolor isn't black
        /// if so make the backcolor of box row + 2, column + 1 green
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private static void calcMovesKnight(int row, int column, Color foreColor)
        {
            if (column >= 1 && row >= 2)
            {
                if (Chess.box[row - 2, column - 1].ForeColor != foreColor)
                {
                    Chess.box[row - 2, column - 1].BackColor = Color.Green;
                }
                if (column <= 6)
                {
                    if (Chess.box[row - 2, column + 1].ForeColor != foreColor)
                    {
                        Chess.box[row - 2, column + 1].BackColor = Color.Green;
                    }
                }
            }
            if (column >= 2 && row >= 1)
            {
                if (Chess.box[row - 1, column - 2].ForeColor != foreColor)
                {
                    Chess.box[row - 1, column - 2].BackColor = Color.Green;
                }
                if (column <= 5)
                {
                    if (Chess.box[row - 1, column + 2].ForeColor != foreColor)
                    {
                        Chess.box[row - 1, column + 2].BackColor = Color.Green;
                    }
                }
            }
            if (column >= 2 && row <= 6)
            {
                if (Chess.box[row + 1, column - 2].ForeColor != foreColor)
                {
                    Chess.box[row + 1, column - 2].BackColor = Color.Green;
                }
                if (column <= 5)
                {
                    if (Chess.box[row + 1, column + 2].ForeColor != foreColor)
                    {
                        Chess.box[row + 1, column + 2].BackColor = Color.Green;
                    }
                }
            }
            if (column >= 1 && row <= 5)
            {
                if (Chess.box[row + 2, column - 1].ForeColor != foreColor)
                {
                    Chess.box[row + 2, column - 1].BackColor = Color.Green;
                }
                if (column <= 6)
                {
                    if (Chess.box[row + 2, column + 1].ForeColor != foreColor)
                    {
                        Chess.box[row + 2, column + 1].BackColor = Color.Green;
                    }
                }
            }
        }

        /// <summary>
        /// calculate the movements for the Tower from its row and column location
        /// </summary>
        /// <algo>
        /// make 2 ints containing row and column from the button to keep the original row and column
        /// 
        /// while as long as newRow is not 0
        /// if every box above the piece doesn't contain text,
        /// do newRow - 1 and make that box green
        /// else check if the clicked box has a white forecolor ->
        /// if so, check if the forecolor of the box from newRow - 1 is white
        /// if so, make that box also green
        /// -> else check if the box newRow - 1 has a white forecolor
        /// if so, make that box green
        /// break
        /// 
        /// make newRow row
        /// 
        /// while as long as newRow is not 7
        /// if every box right to the piece doesn't contain text,
        /// do newRow - 1 and make that box green
        /// else check if the clicked box has a white forecolor ->
        /// if so, check if the forecolor of the box from newRow - 1 is white
        /// if so, make that box also green
        /// -> else check if the box newRow - 1 has a white forecolor
        /// if so, make that box green
        /// break
        /// 
        /// while as long as newColumn is not 7
        /// if every box right to the piece doesn't contain text,
        /// do newColumn + 1 and make that box green
        /// else check if the clicked box has a white forecolor ->
        /// if so, check if the forecolor of the box from newColumn + 1 is white
        /// if so, make that box also green
        /// -> else check if the box newColumn + 1 has a white forecolor
        /// if so, make that box green
        /// break
        /// 
        /// while as long as newColumn is not 0
        /// if every box right to the piece doesn't contain text,
        /// do newColumn - 1 and make that box green
        /// else check if the clicked box has a white forecolor ->
        /// if so, check if the forecolor of the box from newColumn - 1 is white
        /// if so, make that box also green
        /// -> else check if the box newColumn - 1 has a white forecolor
        /// if so, make that box green
        /// break
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
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
                    if (Chess.box[newRow - 1, column].ForeColor != foreColor)
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
                    if (Chess.box[newRow + 1, column].ForeColor != foreColor)
                    {
                        Chess.box[newRow + 1, column].BackColor = Color.Green;
                    }
                    break;
                }
            }
            while (newColumn != 7)
            {
                if (Chess.box[row, newColumn + 1].Text == "")
                {
                    newColumn = newColumn + 1;
                    Chess.box[row, newColumn].BackColor = Color.Green;
                }
                else
                {
                    if (Chess.box[row, newColumn + 1].ForeColor != foreColor)
                    {
                        Chess.box[newRow, newColumn + 1].BackColor = Color.Green;
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
                    if (Chess.box[row, newColumn - 1].ForeColor != foreColor)
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
        private static void calcMovesPawn(int row, int column)
        {
            int newRow = row;
            if (Chess.box[row, column].ForeColor == Color.White)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (newRow != 0)
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
                    if (newRow != 7)
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
        }

        /// <summary>
        /// Disable every box which is not green if the bool parameter is false.
        /// </summary>
        /// <algo>
        /// loop over each row
        /// loop over each column
        /// if the backcolor of the current box it's color is not green
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
                        if (Chess.box[r, c].BackColor != Color.Green)
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
        /// else, enable the current box
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
                    else
                    {
                        if (cleanup == false)
                        {
                            Chess.box[r, c].Enabled = true;
                        }
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
