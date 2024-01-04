using System;
using System.Windows.Forms;
using CheckersGame.Logic;

namespace CheckersGame.UI
{
    internal class UIFlow
    {
        private static readonly FormGameSettings sr_FormGameSettings = new FormGameSettings();
        private static CheckersGameRunner s_CheckersGameRunner;
        private static FormCheckers s_FormCheckers;

        internal static void Run()
        {
            manageFormGameSettings();
            if (sr_FormGameSettings.DialogResult.Equals(DialogResult.OK))
            {
                StratCheckersGame();
                manageFormCheckers();
            }
        }

        private static void manageFormGameSettings()
        {
            bool isPlayer1NameValid;
            bool isPlayer2NameValid;

            sr_FormGameSettings.ShowDialog();
            isPlayer1NameValid = isPlayerNameValid(sr_FormGameSettings.FirstPlayerName);
            isPlayer2NameValid = isPlayerNameValid(sr_FormGameSettings.SecondPlayerName);
            if (sr_FormGameSettings.DialogResult == DialogResult.OK && (!isPlayer1NameValid || !isPlayer2NameValid))
            {
                if (MessageBox.Show("Invalid player name!", "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    manageFormGameSettings();
                }
            }
        }

        internal static void StratCheckersGame()
        {
            string firstPlayerName = sr_FormGameSettings.FirstPlayerName;
            int playerWantedBoardSize = sr_FormGameSettings.WantedBoardSize;
            string secondPlayerName = sr_FormGameSettings.SecondPlayerName;
            Player.ePlayerTypes playerWantedOpponentType = sr_FormGameSettings.WantedOpponentType;

            s_CheckersGameRunner = new CheckersGameRunner(firstPlayerName, secondPlayerName, playerWantedOpponentType, playerWantedBoardSize);
            s_CheckersGameRunner.InitializeGameSession();
            s_CheckersGameRunner.TurnEnded += checkersGameRunner_TurnEnded;
        }

        private static bool isPlayerNameValid(string i_PlayerName)
        {
            bool isValidLegnth = i_PlayerName.Length > 0 && i_PlayerName.Length <= 10;
            bool isContainingSpaces = i_PlayerName.Contains(" ");

            return isValidLegnth && !isContainingSpaces;
        }

        private static void manageFormCheckers()
        {
            s_FormCheckers = new FormCheckers(s_CheckersGameRunner);
            s_FormCheckers.MoveSelected += formCheckers_MoveSelected;
            s_FormCheckers.DrawPanelPlayersAndScores();
            s_FormCheckers.ShowDialog();
        }

        private static void formCheckers_MoveSelected(Move i_Move)
        {
            bool isLegalMove;

            s_CheckersGameRunner.InputMove = i_Move;
            isLegalMove = s_CheckersGameRunner.PlayCurrentPlayerTurn();
            if (!isLegalMove)
            {
                MessageBox.Show("Invalid Move!", "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void checkersGameRunner_TurnEnded(CheckersGameRunner.eEndOfsessionTypes i_EndOfsessionType)
        {
            s_FormCheckers.DrawPanelPlayersAndScores();
            s_FormCheckers.DrawCheckersOnBoard();
            switch (i_EndOfsessionType)
            {
                case CheckersGameRunner.eEndOfsessionTypes.Continue:
                    if (s_CheckersGameRunner.CurrentPlayerTurn.PlayerType.Equals(Player.ePlayerTypes.Computer))
                    {
                        s_CheckersGameRunner.PlayCurrentPlayerTurn();
                    }

                    break;
                case CheckersGameRunner.eEndOfsessionTypes.Win:
                    string winningMessage = getWinningMessage(s_CheckersGameRunner.CurrentPlayerTurn);

                    sessionEndedMessageBox(winningMessage);
                    break;
                case CheckersGameRunner.eEndOfsessionTypes.Tie:
                    string tieMessage = "Tie!";

                    sessionEndedMessageBox(tieMessage);
                    break;
            }
        }

        private static void sessionEndedMessageBox(string i_ReasonGameEndedString)
        {
            string gameEndedMessageString = string.Format(
                @"{0}!
Another Round?",
                i_ReasonGameEndedString);

            if (MessageBox.Show(gameEndedMessageString, "Checkers Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                s_CheckersGameRunner.InitializeGameSession();
                s_FormCheckers.DrawPanelPlayersAndScores();
                s_FormCheckers.DrawCheckersOnBoard();
            }
            else
            {
                s_FormCheckers.Close();
            }
        }

        private static string getWinningMessage(Player i_PlayerWon)
        {
            return string.Format("{0} Won!", i_PlayerWon.PlayerName);
        }
    }
}