using System;
using System.Collections.Generic;

namespace CheckersGame.Logic
{
    public class Player
    {
        private readonly string r_PlayerName;
        private readonly ePlayerTypes r_PlayerType;
        private readonly List<Checker> r_PlayerCheckers;
        private readonly CheckersBoard r_Board;
        private Checker.eCheckersTypes m_CheckerType;
        private string m_LastMove;
        private int m_Score;

        [Flags]
        public enum ePlayerTypes
        {
            Person,
            Computer,
        }

        public string PlayerName
        {
            get
            {
                return r_PlayerName;
            }
        }

        public ePlayerTypes PlayerType
        {
            get
            {
                return r_PlayerType;
            }
        }

        public Checker.eCheckersTypes CheckerType
        {
            get
            {
                return m_CheckerType;
            }
        }

        internal string LastMove
        {
            get
            {
                return m_LastMove;
            }

            set
            {
                m_LastMove = value;
            }
        }

        internal List<Checker> PlayerCheckers
        {
            get
            {
                return r_PlayerCheckers;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            internal set
            {
                m_Score = value;
            }
        }

        internal Player(string i_PlayerName, ePlayerTypes i_PlayerType, Checker.eCheckersTypes i_CheckerType, CheckersBoard i_Board)
        {
            r_PlayerName = i_PlayerName;
            r_PlayerType = i_PlayerType;
            m_CheckerType = i_CheckerType;
            m_LastMove = null;
            r_Board = i_Board;
            r_PlayerCheckers = new List<Checker>((r_Board.BoardSize / 4) * (r_Board.BoardSize - 2));
            m_Score = 0;
        }

        internal void GenerateNonContinuesPossibleMoves(CheckersBoard i_Board)
        {
            foreach (Checker checker in PlayerCheckers)
            {
                checker.GenerateRegularPossibleMoves(i_Board);
                checker.GenerateEdiblePossibleMoves(i_Board);
            }
        }

        internal bool DoesHaveMoves()
        {
            bool dosePlayerHaveMoves = false;

            foreach (Checker checker in PlayerCheckers)
            {
                if (checker.PossibleEdibleMoves.Count > 0 || checker.PossibleRegularMoves.Count > 0)
                {
                    dosePlayerHaveMoves = true;
                    break;
                }
            }

            return dosePlayerHaveMoves;
        }

        internal void ClearAllPossibleMoves()
        {
            foreach (Checker checker in PlayerCheckers)
            {
                checker.ClearPossibleMoves();
            }
        }

        internal int ComputePoints()
        {
            int totalPoints = 0;

            foreach (Checker checker in PlayerCheckers)
            {
                totalPoints += checker.CheckerDegree.Equals(Checker.eCheckersDegrees.King) ? 4 : 1;
            }

            return totalPoints;
        }

        internal void InitializePlayerCheckers()
        {
            r_PlayerCheckers.Clear();
            foreach (Checker checker in r_Board.Board)
            {
                if (checker != null && checker.CheckerType.Equals(m_CheckerType))
                {
                    r_PlayerCheckers.Add(checker);
                }
            }
        }
    }
}