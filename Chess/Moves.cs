using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Moves
    {
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
        public static void calcMovesKing(int row, int column, Color foreColor)
        {
            bool[] sides = new bool[] { false, false, false, false };
            if (row != 0)
            {
                Functions.checkColor(row - 1, column, foreColor);
                sides[0] = true;
            }
            if (column != 7)
            {
                Functions.checkColor(row, column + 1, foreColor);
                if (sides[0] == true)
                {
                    Functions.checkColor(row - 1, column + 1, foreColor);
                }
                sides[1] = true;
            }
            if (row != 7)
            {
                Functions.checkColor(row + 1, column, foreColor);
                if (sides[1] == true)
                {
                    Functions.checkColor(row + 1, column + 1, foreColor);
                }
                sides[2] = true;
            }
            if (column != 0)
            {
                Functions.checkColor(row, column - 1, foreColor);
                if (sides[2] == true)
                {
                    Functions.checkColor(row + 1, column - 1, foreColor);
                }
                if (sides[0] == true)
                {
                    Functions.checkColor(row - 1, column - 1, foreColor);
                }
            }
        }

        /// <summary>
        /// calculate the moves for the bischop
        /// </summary>
        /// <algo>
        /// The bischop can only move diagonaly
        /// Check on each diagonal way if the text on the box is ""
        /// if so, make the backcolor green,
        /// and add or subtract on newRow or newColumn. Depending on the direction
        /// 
        /// else:
        /// if the forecolor of the next box is not the same as the forecolor of the playing player
        /// Make the backcolor of the next box green and break the loop.
        /// 
        /// reset newRow and newColumn to the row and column of the game piece selected
        /// 
        /// do this for all directions
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public static void calcMovesBischop(int row, int column, Color foreColor)
        {
            int newRow = row;
            int newColumn = column;

            while (newColumn != 0 && newRow != 0)
            {
                Functions.checkColor(newRow - 1, newColumn - 1, foreColor);
                if (Functions.blockage(newRow - 1, newColumn - 1)) { break; }
                newRow = newRow - 1;
                newColumn = newColumn - 1;
            }
            newRow = row;
            newColumn = column;
            while (newColumn != 7 && newRow != 0)
            {
                Functions.checkColor(newRow - 1, newColumn + 1, foreColor);
                if (Functions.blockage(newRow - 1, newColumn + 1)) { break; }
                newRow = newRow - 1;
                newColumn = newColumn + 1;
            }
            newRow = row;
            newColumn = column;
            while (newColumn != 0 && newRow != 7)
            {
                Functions.checkColor(newRow + 1, newColumn - 1, foreColor);
                if (Functions.blockage(newRow + 1, newColumn - 1)) { break; }
                newRow = newRow + 1;
                newColumn = newColumn - 1;
            }
            newRow = row;
            newColumn = column;
            while (newColumn != 7 && newRow != 7)
            {
                Functions.checkColor(newRow + 1, newColumn + 1, foreColor);
                if (Functions.blockage(newRow + 1, newColumn + 1)) { break; }
                newRow = newRow + 1;
                newColumn = newColumn + 1;
            }
        }

        /// <summary>
        /// Calculate the possible moves for the knight based on its row and column position
        /// </summary>
        /// <algo>
        /// Set borders by checking if the knight hasn't been out of bounds for coloring a 
        /// box. This can be done by checking where the knight is on the board.
        /// 
        /// A specific box can be colored green 
        /// if the knight has not passed the border of the row and column
        /// if the knight hasn't, make that specific box green
        /// 
        /// Do the same for each box.
        /// </algo>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public static void calcMovesKnight(int row, int column, Color foreColor)
        {
            if (column >= 2 && row >= 1)
            {
                Functions.checkColor(row - 1, column - 2, foreColor);
            }
            if (column >= 1 && row >= 2)
            {
                Functions.checkColor(row - 2, column - 1, foreColor);
            }
            if (column <= 6 && row >= 2)
            {
                Functions.checkColor(row - 2, column + 1, foreColor);
            }
            if (column <= 5 && row >= 1)
            {
                Functions.checkColor(row - 1, column + 2, foreColor);
            }
            if (column <= 5 && row <= 6)
            {
                Functions.checkColor(row + 1, column + 2, foreColor);
            }
            if (column <= 6 && row <= 5)
            {
                Functions.checkColor(row + 2, column + 1, foreColor);
            }
            if (column >= 1 && row <= 5)
            {
                Functions.checkColor(row + 2, column - 1, foreColor);
            }
            if (column >= 2 && row <= 6)
            {
                Functions.checkColor(row + 1, column - 2, foreColor);
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
        public static void calcMovesTower(int row, int column, Color foreColor)
        {
            int newRow = row;
            int newColumn = column;
            while (newRow != 0)
            {
                newRow = Functions.checkText(newRow - 1, column, true);
                Functions.checkColor(newRow, column, foreColor);
                if (Functions.blockage(newRow, column)) { break; }
            }
            newRow = row;
            while (newRow != 7)
            {
                newRow = Functions.checkText(newRow + 1, column, true);
                Functions.checkColor(newRow, column, foreColor);
                if (Functions.blockage(newRow, column)) { break; }
            }
            while (newColumn != 7)
            {
                newColumn = Functions.checkText(row, newColumn + 1, false);
                Functions.checkColor(row, newColumn, foreColor);
                if (Functions.blockage(row, newColumn)) { break; }
            }
            newColumn = column;
            while (newColumn != 0)
            {
                newColumn = Functions.checkText(row, newColumn - 1, false);
                Functions.checkColor(row, newColumn, foreColor);
                if (Functions.blockage(row, newColumn)) { break; }
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
        public static void calcMovesPawn(int row, int column, Color foreColor)
        {
            int newRow = row;
            if (Chess.box[row, column].ForeColor == Color.White)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (newRow != 0)
                    {
                        newRow = Functions.checkText(newRow - 1, column, true);
                    }
                }
                if (column != 0 && row != 0)
                {
                    Functions.checkColor(row - 1, column - 1, foreColor);
                }
                if (column != 7 && row != 0)
                {
                    Functions.checkColor(row - 1, column + 1, foreColor);
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (newRow != 7)
                    {
                        newRow = Functions.checkText(newRow + 1, column, true);
                    }
                }
                if (column != 7 && row != 7)
                {
                    Functions.checkColor(row + 1, column + 1, foreColor);
                }
                if (column != 0 && row != 7)
                {
                    Functions.checkColor(row + 1, column - 1, foreColor);
                }
            }
        }

        /// <summary>
        /// Check if it's possible to castle. If so, show it.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="color"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void calcCastling(int row, int column)
        {
            bool rookSelected = false;

            if (Chess.box[row, column].Text == "r")
            {
                column = column - 3;
                rookSelected = true;
            }

            while (column < 7)
            {
                column++;
                if (Chess.box[row, column].Text == "r")
                {
                    if (rookSelected == true)
                    {
                        Chess.box[row, column - 3].BackColor = Color.Green;
                    }
                    else
                    {
                        Chess.box[row, column].BackColor = Color.Green;
                    }
                }
                else
                {
                    if (Chess.box[row, column].Text != "")
                    {
                        break;
                    }
                }
            }
        }
    }
}
