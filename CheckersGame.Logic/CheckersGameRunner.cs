using System;
using System.Collections.Generic;

namespace CheckersGame.Logic
{
    public class CheckersGameRunner
    {
        private readonly Player r_FirstPlayer;
        private readonly Player r_SecondPlayer;
        private readonly CheckersBoard r_Board;
        private Player m_CurrentPlayerTurn;
        private Player m_OpponentPlayer;
        private Player m_LastPlayerTurn;
        private bool m_IsContinuesTurn;
        private bool m_IsEdibleTurn;
        private Checker m_CurrentMoveChecker;
        private Move m_InputMove;
        private eEndOfsessionTypes m_EndOfSession;

        public event Action<eEndOfsessionTypes> TurnEnded;

        public event Action<LocationOnBoard> MadeKing;

        [Flags]
        public enum eEndOfsessionTypes
        {
            Continue,
            Win,
            Tie,
        }

        public Player FirstPlayer
        {
            get
            {
                return r_FirstPlayer;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return r_SecondPlayer;
            }
        }

        public CheckersBoard CheckersBoard
        {
            get
            {
                return r_Board;
            }
        }

        public Player CurrentPlayerTurn
        {
            get
            {
                return m_CurrentPlayerTurn;
            }
        }

        public Player OpponentPlayer
        {
            get
            {
                return m_OpponentPlayer;
            }
        }

        public Player LastPlayerTurn
        {
            get
            {
                return m_LastPlayerTurn;
            }
        }

        public eEndOfsessionTypes EndOfSession
        {
            get
            {
                return m_EndOfSession;
            }
        }

        public Move InputMove
        {
            get
            {
                return m_InputMove;
            }

            set
            {
                m_InputMove = value;
            }
        }

        public CheckersGameRunner(string i_FirstPlayerName, string i_SecondPlayerName, Player.ePlayerTypes i_SecondPlayerType, int i_BoardSize)
        {
            r_Board = new CheckersBoard(i_BoardSize);
            r_FirstPlayer = new Player(i_FirstPlayerName, Player.ePlayerTypes.Person, Checker.eCheckersTypes.FirstPlayerChecker, r_Board);
            r_SecondPlayer = new Player(i_SecondPlayerName, i_SecondPlayerType, Checker.eCheckersTypes.SecondPlayerChecker, r_Board);
        }

        public void InitializeGameSession()
        {
            r_Board.InitializeBoard();
            r_FirstPlayer.InitializePlayerCheckers();
            r_SecondPlayer.InitializePlayerCheckers();
            m_CurrentPlayerTurn = r_FirstPlayer;
            m_OpponentPlayer = r_SecondPlayer;
            m_LastPlayerTurn = null;
            m_IsContinuesTurn = false;
            m_IsEdibleTurn = false;
            m_CurrentMoveChecker = null;
            m_InputMove = null;
            m_EndOfSession = eEndOfsessionTypes.Continue;
        }

        private void updateEdibleStatus()
        {
            bool isEdible = false;

            foreach (Checker checker in m_CurrentPlayerTurn.PlayerCheckers)
            {
                if (checker.PossibleEdibleMoves.Count > 0)
                {
                    isEdible = true;
                    break;
                }
            }

            m_IsEdibleTurn = isEdible;
        }

        private bool isMoveInPossibleMovesList(List<LocationOnBoard> i_PossibleMovesList, LocationOnBoard i_TargetLocationOnBoard)
        {
            bool isMoveInList = false;

            foreach (LocationOnBoard potentialLocation in i_PossibleMovesList)
            {
                if (potentialLocation.DoesEqual(i_TargetLocationOnBoard))
                {
                    isMoveInList = true;
                    break;
                }
            }

            return isMoveInList;
        }

        private bool isLegalNonContinuesMove()
        {
            bool isLegalMove = false;

            if (!r_Board.IsEmptySquare(m_InputMove.SourceLocationOnBoard) && m_CurrentMoveChecker.CheckerType == CurrentPlayerTurn.CheckerType)
            {
                List<LocationOnBoard> possibleMovesList = m_IsEdibleTurn ? m_CurrentMoveChecker.PossibleEdibleMoves : m_CurrentMoveChecker.PossibleRegularMoves;

                isLegalMove = isMoveInPossibleMovesList(possibleMovesList, m_InputMove.TargetLocationOnBoard);
            }

            return isLegalMove;
        }

        private bool isLegalContinuesMove()
        {
            bool isLegalMove = false;

            if (m_CurrentMoveChecker.LocationOnBoardOnBoard.DoesEqual(m_InputMove.SourceLocationOnBoard))
            {
                isLegalMove = isMoveInPossibleMovesList(m_CurrentMoveChecker.PossibleEdibleMoves, m_InputMove.TargetLocationOnBoard);
            }

            return isLegalMove;
        }

        private bool updateContinuesMove()
        {
            bool isContinuesMove = false;

            if (m_IsEdibleTurn)
            {
                m_CurrentMoveChecker.GenerateEdiblePossibleMoves(r_Board);
                isContinuesMove = m_CurrentMoveChecker.PossibleEdibleMoves.Count > 0;
            }

            return isContinuesMove;
        }

        private void setComputerMove(Checker i_Checker, List<LocationOnBoard> i_PossibleMovesList)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, i_PossibleMovesList.Count);
            LocationOnBoard sourceLocationOnBoard = i_Checker.LocationOnBoardOnBoard;
            LocationOnBoard targetLocationOnBoard = i_PossibleMovesList[randomIndex];

            m_InputMove = new Move(sourceLocationOnBoard, targetLocationOnBoard);
        }

        private void chooseComputerMove()
        {
            foreach (Checker checker in m_CurrentPlayerTurn.PlayerCheckers)
            {
                List<LocationOnBoard> possibleMovesList = m_IsEdibleTurn ? checker.PossibleEdibleMoves : checker.PossibleRegularMoves;

                if (possibleMovesList.Count > 0)
                {
                    setComputerMove(checker, possibleMovesList);
                    break;
                }
            }
        }

        public bool PlayCurrentPlayerTurn()
        {
            bool isLegaleMove = m_IsContinuesTurn ? handleContinuesMove() : handleNonContinuesMove();

            if (isLegaleMove)
            {
                makeCurrentPlayerMove();
                handleEndOfTurn();
            }

            return isLegaleMove;
        }

        private bool handleNonContinuesMove()
        {
            bool isLegaleMove = false;

            m_CurrentPlayerTurn.ClearAllPossibleMoves();
            m_CurrentPlayerTurn.GenerateNonContinuesPossibleMoves(r_Board);
            updateEdibleStatus();
            switch (CurrentPlayerTurn.PlayerType)
            {
                case Player.ePlayerTypes.Person:
                    m_CurrentMoveChecker = r_Board.GetCheckerAtLocation(m_InputMove.SourceLocationOnBoard);
                    isLegaleMove = isLegalNonContinuesMove();
                    break;
                case Player.ePlayerTypes.Computer:
                    chooseComputerMove();
                    m_CurrentMoveChecker = r_Board.GetCheckerAtLocation(m_InputMove.SourceLocationOnBoard);
                    isLegaleMove = true;
                    break;
            }

            return isLegaleMove;
        }

        private bool handleContinuesMove()
        {
            bool isLegaleMove = false;

            switch (CurrentPlayerTurn.PlayerType)
            {
                case Player.ePlayerTypes.Person:
                    isLegaleMove = isLegalContinuesMove();
                    break;
                case Player.ePlayerTypes.Computer:
                    setComputerMove(m_CurrentMoveChecker, m_CurrentMoveChecker.PossibleEdibleMoves);
                    isLegaleMove = true;
                    break;
            }

            return isLegaleMove;
        }

        private void handleEndOfTurn()
        {
            m_CurrentPlayerTurn.ClearAllPossibleMoves();
            m_IsContinuesTurn = updateContinuesMove();
            m_IsEdibleTurn = m_IsContinuesTurn;
            updateEndOfSession();
            switch (m_EndOfSession)
            {
                case eEndOfsessionTypes.Win:
                    addScoreToWinnerPlayer(m_CurrentPlayerTurn, m_OpponentPlayer);
                    break;
                case eEndOfsessionTypes.Continue:
                    updateTurns();
                    break;
            }

            OnTurnEnded(m_EndOfSession);
        }

        protected virtual void OnTurnEnded(eEndOfsessionTypes i_EndOfsessionTypes)
        {
            if (TurnEnded != null)
            {
                TurnEnded.Invoke(i_EndOfsessionTypes);
            }
        }

        protected virtual void OnMadeKing(LocationOnBoard i_LocationOnBoardMadeKing)
        {
            if (MadeKing != null)
            {
                MadeKing.Invoke(i_LocationOnBoardMadeKing);
            }
        }

        private void updateTurns()
        {
            if (!m_IsContinuesTurn)
            {
                Player temporalOpponentPlayerForSwapping = m_OpponentPlayer;

                m_LastPlayerTurn = m_CurrentPlayerTurn;
                m_OpponentPlayer = m_CurrentPlayerTurn;
                m_CurrentPlayerTurn = temporalOpponentPlayerForSwapping;
            }
            else
            {
                m_LastPlayerTurn = m_CurrentPlayerTurn;
            }
        }

        private void eatChecker()
        {
            LocationOnBoard loctionToEat;

            if (m_InputMove.TargetLocationOnBoard.Row < m_InputMove.SourceLocationOnBoard.Row)
            {
                loctionToEat = m_InputMove.TargetLocationOnBoard.Column > m_InputMove.SourceLocationOnBoard.Column ? m_InputMove.SourceLocationOnBoard.NewUpRightLocation(1) : m_InputMove.SourceLocationOnBoard.NewUpLeftLocation(1);
            }
            else
            {
                loctionToEat = m_InputMove.TargetLocationOnBoard.Column > m_InputMove.SourceLocationOnBoard.Column ? m_InputMove.SourceLocationOnBoard.NewDownRightLocation(1) : m_InputMove.SourceLocationOnBoard.NewDownLeftLocation(1);
            }

            m_OpponentPlayer.PlayerCheckers.Remove(r_Board.GetCheckerAtLocation(loctionToEat));
            r_Board.RemoveCheckerAtLocation(loctionToEat);
        }

        private void makeCurrentPlayerMove()
        {
            r_Board.Board[m_InputMove.TargetLocationOnBoard.Row, m_InputMove.TargetLocationOnBoard.Column] = m_CurrentMoveChecker;
            r_Board.Board[m_CurrentMoveChecker.LocationOnBoardOnBoard.Row, m_CurrentMoveChecker.LocationOnBoardOnBoard.Column] = null;
            m_CurrentMoveChecker.LocationOnBoardOnBoard = m_InputMove.TargetLocationOnBoard;
            if (m_IsEdibleTurn)
            {
                eatChecker();
            }

            makeKingIfNeeded();
        }

        private void makeKingIfNeeded()
        {
            int kingRow = m_CurrentMoveChecker.CheckerType.Equals(Checker.eCheckersTypes.FirstPlayerChecker) ? 0 : r_Board.BoardSize - 1;

            if (m_CurrentMoveChecker.LocationOnBoardOnBoard.Row == kingRow && !m_CurrentMoveChecker.CheckerDegree.Equals(Checker.eCheckersDegrees.King))
            {
                m_CurrentMoveChecker.CheckerDegree = Checker.eCheckersDegrees.King;
                m_CurrentMoveChecker.CheckerChar = m_CurrentMoveChecker.CheckerTypeToChar();
                OnMadeKing(m_CurrentMoveChecker.LocationOnBoardOnBoard);
            }
        }

        private void updateEndOfSession()
        {
            eEndOfsessionTypes endOfSession = eEndOfsessionTypes.Continue;

            if (!m_IsContinuesTurn)
            {
                if (m_OpponentPlayer.PlayerCheckers.Count == 0)
                {
                    endOfSession = eEndOfsessionTypes.Win;
                }
                else
                {
                    m_OpponentPlayer.GenerateNonContinuesPossibleMoves(r_Board);
                    if (!m_OpponentPlayer.DoesHaveMoves())
                    {
                        m_CurrentPlayerTurn.GenerateNonContinuesPossibleMoves(r_Board);
                        if (!m_CurrentPlayerTurn.DoesHaveMoves())
                        {
                            endOfSession = eEndOfsessionTypes.Tie;
                        }
                        else
                        {
                            endOfSession = eEndOfsessionTypes.Win;
                        }

                        m_CurrentPlayerTurn.ClearAllPossibleMoves();
                    }

                    m_OpponentPlayer.ClearAllPossibleMoves();
                }
            }

            m_EndOfSession = endOfSession;
        }

        private void addScoreToWinnerPlayer(Player i_WinnerPlayer, Player i_LoserPlayer)
        {
            i_WinnerPlayer.Score += Math.Abs(i_WinnerPlayer.ComputePoints() - i_LoserPlayer.ComputePoints());
        }
    }
}