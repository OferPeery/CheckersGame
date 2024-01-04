using System;
using System.Text;

namespace CheckersGame.Logic
{
    public class CheckersBoard
    {
        private readonly int r_BoardSize;
        private readonly Checker[,] r_Board;

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        internal Checker[,] Board
        {
            get
            {
                return r_Board;
            }
        }

        public Checker this[int i, int j]
        {
            get
            {
                return r_Board[i, j];
            }
        }

        internal CheckersBoard(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            r_Board = new Checker[i_BoardSize, i_BoardSize];
        }

        internal Checker GetCheckerAtLocation(LocationOnBoard i_LocationOnBoard)
        {
            return r_Board[i_LocationOnBoard.Row, i_LocationOnBoard.Column];
        }

        internal void RemoveCheckerAtLocation(LocationOnBoard i_LocationOnBoard)
        {
            r_Board[i_LocationOnBoard.Row, i_LocationOnBoard.Column] = null;
        }

        internal bool IsEmptySquare(LocationOnBoard i_LocationOnBoard)
        {
            return GetCheckerAtLocation(i_LocationOnBoard) == null;
        }

        internal bool IsLocationOnBoard(LocationOnBoard i_LocationOnBoard)
        {
            return (i_LocationOnBoard.Row >= 0) && (i_LocationOnBoard.Row < r_BoardSize) && (i_LocationOnBoard.Column >= 0) && (i_LocationOnBoard.Column < BoardSize);
        }

        internal void InitializeCheckersOnBoard(int i_StartIndex, int i_EndIndex, char i_CheckerChar, Checker.eCheckersTypes i_CheckerType)
        {
            for (int i = i_StartIndex; i < i_EndIndex; i++)
            {
                for (int j = (i + 1) % 2; j < r_BoardSize; j += 2)
                {
                    r_Board[i, j] = new Checker(i_CheckerChar,  i_CheckerType, i, j);
                }
            }
        }

        internal void InitializeBoard()
        {
            int startIndex = 0;
            int endIndex = (r_BoardSize - 2) / 2;

            ClearBoard();
            InitializeCheckersOnBoard(startIndex, endIndex, 'O', Checker.eCheckersTypes.SecondPlayerChecker);
            startIndex = endIndex + 2;
            endIndex = r_BoardSize;
            InitializeCheckersOnBoard(startIndex, endIndex, 'X', Checker.eCheckersTypes.FirstPlayerChecker);
        }

        internal void ClearBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    r_Board[i, j] = null;
                }
            }
        }

        internal string BoardToString()
        {
            StringBuilder boardString = new StringBuilder("  ");
            string lineDelimiter = new string('=', (r_BoardSize * 3) + (r_BoardSize + 1));

            for (char c = 'A'; c < 'A' + r_BoardSize; c++)
            {
                boardString.Append(string.Format(@" {0}  ", c));
            }

            boardString.Append(Environment.NewLine);
            boardString.Append(" ");
            boardString.AppendLine(lineDelimiter);

            for (int i = 0; i < r_BoardSize; i++)
            {
                char lineChar = (char)(i + 'a');

                boardString.Append(string.Format(@"{0}|", lineChar));
                for (int j = 0; j < r_BoardSize; j++)
                {
                    char checkerChar = r_Board[i, j] == null ? ' ' : r_Board[i, j].CheckerChar;

                    boardString.Append(string.Format(@" {0} |", checkerChar));
                }

                boardString.Append(Environment.NewLine);
                boardString.Append(" ");
                boardString.AppendLine(lineDelimiter);
            }

            return boardString.ToString();
        }
    }
}