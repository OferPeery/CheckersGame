using System;
using System.Drawing;
using System.Windows.Forms;
using CheckersGame.Logic;

namespace CheckersGame.UI
{
    public partial class FormCheckers : Form
    {
        private const int k_TileSideSize = 70;
        private const int k_PanelPlayersAndScoresHeight = 150;
        private const int k_FormExtraWidth = 20;
        private const int k_FormExtraHeight = 40;
        private readonly CheckersGameRunner r_CheckersGameRunner;
        private readonly CheckersBoard r_CheckersBoard;
        private readonly Button[,] r_ButtonTilesBoard;
        private readonly PictureBox r_PictureBoxConfetti = new PictureBox();
        private readonly int r_BoardSize;
        private readonly Size r_TileSize = new Size(k_TileSideSize, k_TileSideSize);
        private Button m_ChosenSourceTile;
        private GifImage m_GifImageConfetti;

        public event Action<Move> MoveSelected;

        public FormCheckers(CheckersGameRunner i_CheckersGameRunner)
        {
            r_CheckersGameRunner = i_CheckersGameRunner;
            r_CheckersBoard = i_CheckersGameRunner.CheckersBoard;
            r_BoardSize = i_CheckersGameRunner.CheckersBoard.BoardSize;
            r_ButtonTilesBoard = new Button[r_BoardSize, r_BoardSize];
            r_CheckersGameRunner.MadeKing += checkersGameRunner_MadeKing;
            InitializeComponent();
        }

        private Point getTileLocationOnPanel(int i_Column, int i_Row)
        {
            return new Point(k_TileSideSize * i_Column, k_TileSideSize * i_Row);
        }

        private void checkersGameRunner_MadeKing(LocationOnBoard i_LocationOnBoardMadeKing)
        {
            m_GifImageConfetti = new GifImage(Properties.Resources.Confety);
            r_PictureBoxConfetti.Location = getTileLocationOnPanel(i_LocationOnBoardMadeKing.Column, i_LocationOnBoardMadeKing.Row);
            r_PictureBoxConfetti.Visible = true;
            timerConfetyAnimation.Enabled = true;
            timerConfetyAnimation.Start();
        }

        private void initializePictureBoxConfetti()
        {
            panelBoard.Controls.Add(r_PictureBoxConfetti);
            r_PictureBoxConfetti.Size = r_TileSize;
            r_PictureBoxConfetti.SizeMode = PictureBoxSizeMode.Zoom;
            r_PictureBoxConfetti.BackColor = Color.Transparent;
            r_PictureBoxConfetti.BackgroundImage = Properties.Resources.BrownBackground;
            r_PictureBoxConfetti.BringToFront();
            r_PictureBoxConfetti.Visible = false;
        }

        private void drawPanelBoard()
        {
            Bitmap whiteBackground = Properties.Resources.WhiteBackground;
            Bitmap brownBackground = Properties.Resources.BrownBackground;

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    Button newTile = new Button();

                    panelBoard.Controls.Add(newTile);
                    newTile.Size = r_TileSize;
                    newTile.Location = getTileLocationOnPanel(j, i);
                    r_ButtonTilesBoard[i, j] = newTile;
                    if (i % 2 == 0)
                    {
                        newTile.BackgroundImage = j % 2 != 0 ? brownBackground : whiteBackground;
                        newTile.Enabled = j % 2 != 0;
                    }
                    else
                    {
                        newTile.BackgroundImage = j % 2 != 0 ? whiteBackground : brownBackground;
                        newTile.Enabled = j % 2 == 0;
                    }

                    newTile.Name = string.Format("buttonTile{0},{1}", i, j);
                    newTile.Click += buttonTile_Clicked;
                    newTile.Tag = new LocationOnBoard(i, j);
                }
            }
        }

        internal void DrawPanelPlayersAndScores()
        {
            labelFirstPlayerName.Text = string.Format("{0}'s Score: {1}", r_CheckersGameRunner.FirstPlayer.PlayerName, r_CheckersGameRunner.FirstPlayer.Score);
            labelSecondPlayerName.Text = string.Format("{0}'s Score: {1}", r_CheckersGameRunner.SecondPlayer.PlayerName, r_CheckersGameRunner.SecondPlayer.Score);
            labelCurrentPlayerTurn.Text = r_CheckersGameRunner.CurrentPlayerTurn.PlayerName;
        }

        private void formCheckers_Load(object sender, EventArgs e)
        {
            Size = new Size((k_TileSideSize * r_BoardSize) + k_FormExtraWidth, (k_TileSideSize * r_BoardSize) + k_PanelPlayersAndScoresHeight + k_FormExtraHeight);
            panelPlayersAndScores.Size = new Size(k_TileSideSize * r_BoardSize, k_PanelPlayersAndScoresHeight);
            panelPlayersAndScores.Location = new Point(0, 0);
            panelBoard.Size = new Size(k_TileSideSize * r_BoardSize, k_TileSideSize * r_BoardSize);
            panelBoard.Location = new Point(0, k_PanelPlayersAndScoresHeight);
            initializePictureBoxConfetti();
            drawPanelBoard();
            DrawCheckersOnBoard();
        }

        private void buttonTile_Clicked(object sender, EventArgs e)
        {
            Button clickedTile = sender as Button;

            if (m_ChosenSourceTile != null)
            {
                if(m_ChosenSourceTile.Name.Equals(clickedTile.Name))
                {
                    clickedTile.BackgroundImage = Properties.Resources.BrownBackground;
                }
                else
                {
                    LocationOnBoard sourceLocation = (LocationOnBoard)m_ChosenSourceTile.Tag;
                    LocationOnBoard targetLocation = (LocationOnBoard)clickedTile.Tag;

                    m_ChosenSourceTile.BackgroundImage = Properties.Resources.BrownBackground;
                    OnMoveSelected(new Move(sourceLocation, targetLocation));
                }

                m_ChosenSourceTile = null;
            }
            else
            {
                if (clickedTile.Image != null)
                {
                    clickedTile.BackgroundImage = Properties.Resources.BrownBlueBackground;
                    m_ChosenSourceTile = clickedTile;
                }
            }
        }

        internal void DrawCheckersOnBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    Button currentButtonTile = r_ButtonTilesBoard[i, j];

                    if (r_CheckersBoard[i, j] != null)
                    {
                        bool isFirstPlayerChecker =
                            r_CheckersBoard[i, j].CheckerType == Checker.eCheckersTypes.FirstPlayerChecker;
                        bool isKing = r_CheckersBoard[i, j].CheckerDegree.Equals(Checker.eCheckersDegrees.King);

                        if (isKing)
                        {
                            currentButtonTile.Image =
                                isFirstPlayerChecker
                                    ? Properties.Resources.WhiteKingCheckerCompressed
                                    : Properties.Resources.BrownKingCheckerCompressed;
                        }
                        else
                        {
                            currentButtonTile.Image =
                                isFirstPlayerChecker
                                    ? Properties.Resources.WhiteCheckerCompressed
                                    : Properties.Resources.BrownCheckerCompressed;
                        }
                    }
                    else
                    {
                        currentButtonTile.Image = null;
                    }
                }
            }
        }

        protected virtual void OnMoveSelected(Move i_Move)
        {
            if (MoveSelected != null)
            {
                MoveSelected.Invoke(i_Move);
            }
        }

        private void timerConfettiAnimation_Tick(object sender, EventArgs e)
        {
            if (!m_GifImageConfetti.IsMaxFrameReached)
            {
                r_PictureBoxConfetti.Image = m_GifImageConfetti.GetNextFrame();
            }
            else
            {
                timerConfetyAnimation.Enabled = false;
                timerConfetyAnimation.Stop();
                m_GifImageConfetti = null;
                r_PictureBoxConfetti.Visible = false;
            }
        }
    }
}