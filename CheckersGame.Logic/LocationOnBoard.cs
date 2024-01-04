using System;

namespace CheckersGame.Logic
{
    // We chose to define a struct to agregate the row and column
    // While avoiding the 50% overhead if it were a class.
    public struct LocationOnBoard
    {
        private int m_Row;
        private int m_Column;

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }

        public int Column
        {
            get
            {
                return m_Column;
            }

            set
            {
                m_Column = value;
            }
        }

        public LocationOnBoard(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }

        internal bool DoesEqual(LocationOnBoard i_OtherLocationOnBoard)
        {
            return this.Row == i_OtherLocationOnBoard.Row && this.Column == i_OtherLocationOnBoard.Column;
        }

        internal LocationOnBoard NewUpLeftLocation(int i_NumberOfJumps)
        {
            return new LocationOnBoard(m_Row -= i_NumberOfJumps, m_Column -= i_NumberOfJumps);
        }

        internal LocationOnBoard NewUpRightLocation(int i_NumberOfJumps)
        {
            return new LocationOnBoard(m_Row -= i_NumberOfJumps, m_Column += i_NumberOfJumps);
        }

        internal LocationOnBoard NewDownLeftLocation(int i_NumberOfJumps)
        {
            return new LocationOnBoard(m_Row += i_NumberOfJumps, m_Column -= i_NumberOfJumps);
        }

        internal LocationOnBoard NewDownRightLocation(int i_NumberOfJumps)
        {
            return new LocationOnBoard(m_Row += i_NumberOfJumps, m_Column += i_NumberOfJumps);
        }
    }
}