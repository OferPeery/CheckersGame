using System;

namespace CheckersGame.Logic
{
    public class Move
    {
        private LocationOnBoard m_SourceLocationOnBoard;
        private LocationOnBoard m_TargetLocationOnBoard;

        internal LocationOnBoard SourceLocationOnBoard
        {
            get
            {
                return m_SourceLocationOnBoard;
            }

            set
            {
                m_SourceLocationOnBoard = value;
            }
        }

        internal LocationOnBoard TargetLocationOnBoard
        {
            get
            {
                return m_TargetLocationOnBoard;
            }

            set
            {
                m_TargetLocationOnBoard = value;
            }
        }

        public Move(LocationOnBoard i_SourceLocationOnBoard, LocationOnBoard i_TargetLocationOnBoard)
        {
            m_SourceLocationOnBoard = i_SourceLocationOnBoard;
            m_TargetLocationOnBoard = i_TargetLocationOnBoard;
        }
    }
}