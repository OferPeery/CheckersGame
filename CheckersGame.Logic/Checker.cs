using System;
using System.Collections.Generic;

namespace CheckersGame.Logic
{
    public class Checker
    {
        private readonly eCheckersTypes r_CheckerType;
        private readonly List<LocationOnBoard> r_PossibleRegularMoves;
        private readonly List<LocationOnBoard> r_PossibleEdibleMoves;
        private char m_CheckerChar;
        private eCheckersDegrees m_CheckerDegree;
        private LocationOnBoard m_LocationOnBoard;

        [Flags]
        public enum eCheckersTypes
        {
            FirstPlayerChecker,
            SecondPlayerChecker,
        }

        [Flags]
        public enum eCheckersDegrees
        {
            Man,
            King,
        }

        internal char CheckerChar
        {
            get
            {
                return m_CheckerChar;
            }

            set
            {
                m_CheckerChar = value;
            }
        }

        public eCheckersTypes CheckerType
        {
            get
            {
                return r_CheckerType;
            }
        }

        public eCheckersDegrees CheckerDegree
        {
            get
            {
                return m_CheckerDegree;
            }

            set
            {
                m_CheckerDegree = value;
            }
        }

        internal List<LocationOnBoard> PossibleRegularMoves
        {
            get
            {
                return r_PossibleRegularMoves;
            }
        }

        internal List<LocationOnBoard> PossibleEdibleMoves
        {
            get
            {
                return r_PossibleEdibleMoves;
            }
        }

        internal LocationOnBoard LocationOnBoardOnBoard
        {
            get
            {
                return m_LocationOnBoard;
            }

            set
            {
                m_LocationOnBoard = value;
            }
        }

        internal Checker(char i_CheckerChar, eCheckersTypes i_CheckerType, int i_RowOnBoard, int i_ColumnOnBoard)
        {
            m_CheckerChar = i_CheckerChar;
            r_CheckerType = i_CheckerType;
            m_CheckerDegree = eCheckersDegrees.Man;
            r_PossibleRegularMoves = new List<LocationOnBoard>();
            r_PossibleEdibleMoves = new List<LocationOnBoard>();
            m_LocationOnBoard = new LocationOnBoard(i_RowOnBoard, i_ColumnOnBoard);
        }

        internal void AddToRegularPossibleMovesList(CheckersBoard i_Board, LocationOnBoard i_LocationOnBoard)
        {
            if (i_Board.IsLocationOnBoard(i_LocationOnBoard) && i_Board.IsEmptySquare(i_LocationOnBoard))
            {
                PossibleRegularMoves.Add(i_LocationOnBoard);
            }
        }

        internal void GenerateRegularPossibleMoves(CheckersBoard i_Board)
        {
            switch (CheckerType)
            {
                case eCheckersTypes.FirstPlayerChecker:
                    AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpLeftLocation(1));
                    AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpRightLocation(1));
                    if (CheckerDegree.Equals(eCheckersDegrees.King))
                    {
                        AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownLeftLocation(1));
                        AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownRightLocation(1));
                    }

                    break;
                case eCheckersTypes.SecondPlayerChecker:
                    AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownRightLocation(1));
                    AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownLeftLocation(1));
                    if (CheckerDegree.Equals(eCheckersDegrees.King))
                    {
                        AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpRightLocation(1));
                        AddToRegularPossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpLeftLocation(1));
                    }

                    break;
            }
        }

        internal void AddToEdiblePossibleMovesList(CheckersBoard i_Board, LocationOnBoard i_FirstJumpLocationOnBoard, LocationOnBoard i_SecondJumpLocationOnBoard) // PUT IN CHECKER
        {
            if (i_Board.IsLocationOnBoard(i_FirstJumpLocationOnBoard) && i_Board.IsLocationOnBoard(i_SecondJumpLocationOnBoard))
            {
                if (!i_Board.IsEmptySquare(i_FirstJumpLocationOnBoard)
                    && !i_Board.GetCheckerAtLocation(i_FirstJumpLocationOnBoard).CheckerType.Equals(CheckerType)
                    && i_Board.IsEmptySquare(i_SecondJumpLocationOnBoard))
                {
                    PossibleEdibleMoves.Add(i_SecondJumpLocationOnBoard);
                }
            }
        }

        internal void GenerateEdiblePossibleMoves(CheckersBoard i_Board)
        {
            switch (CheckerType)
            {
                case eCheckersTypes.FirstPlayerChecker:
                    AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpLeftLocation(1), LocationOnBoardOnBoard.NewUpLeftLocation(2));
                    AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpRightLocation(1), LocationOnBoardOnBoard.NewUpRightLocation(2));
                    if (CheckerDegree.Equals(eCheckersDegrees.King))
                    {
                        AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownLeftLocation(1), LocationOnBoardOnBoard.NewDownLeftLocation(2));
                        AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownRightLocation(1), LocationOnBoardOnBoard.NewDownRightLocation(2));
                    }

                    break;
                case eCheckersTypes.SecondPlayerChecker:
                    AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownRightLocation(1), LocationOnBoardOnBoard.NewDownRightLocation(2));
                    AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewDownLeftLocation(1), LocationOnBoardOnBoard.NewDownLeftLocation(2));
                    if (CheckerDegree.Equals(eCheckersDegrees.King))
                    {
                        AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpRightLocation(1), LocationOnBoardOnBoard.NewUpRightLocation(2));
                        AddToEdiblePossibleMovesList(i_Board, LocationOnBoardOnBoard.NewUpLeftLocation(1), LocationOnBoardOnBoard.NewUpLeftLocation(2));
                    }

                    break;
            }
        }

        internal void ClearPossibleMoves()
        {
            r_PossibleRegularMoves.Clear();
            r_PossibleEdibleMoves.Clear();
        }

        internal char CheckerTypeToChar()
        {
            char checkerChar = 'X';

            switch (r_CheckerType)
            {
                case eCheckersTypes.FirstPlayerChecker:
                    checkerChar = m_CheckerDegree.Equals(eCheckersDegrees.Man) ? 'X' : 'Z';
                    break;
                case eCheckersTypes.SecondPlayerChecker:
                    checkerChar = m_CheckerDegree.Equals(eCheckersDegrees.Man) ? 'O' : 'Q';
                    break;
            }

            return checkerChar;
        }
    }
}