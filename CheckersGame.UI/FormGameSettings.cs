using System;
using System.Linq;
using System.Windows.Forms;
using CheckersGame.Logic;

namespace CheckersGame.UI
{
    public partial class FormGameSettings : Form
    {
        private const float k_SecondsToWaitForAnimationToStartOver = 0.5f;
        private int m_WantedBoardSize;
        private int m_CurrentLengthOfTitle;
        private string m_FullTitleText;
        private DateTime m_TitleAnimationStoppedStartTime;

        internal string FirstPlayerName
        {
            get
            {
                return textBoxPlayer1.Text;
            }
        }

        internal string SecondPlayerName
        {
            get
            {
                return textBoxPlayer2.Text;
            }
        }

        internal int WantedBoardSize
        {
            get
            {
                return m_WantedBoardSize;
            }

            private set
            {
                m_WantedBoardSize = value;
            }
        }

        internal Player.ePlayerTypes WantedOpponentType
        {
            get
            {
                return checkBoxPlayer2.Checked ? Player.ePlayerTypes.Person : Player.ePlayerTypes.Computer;
            }
        }

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayer2.Enabled = (sender as CheckBox).Checked;
            textBoxPlayer2.Text = textBoxPlayer2.Enabled ? null : "Computer";
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            WantedBoardSize = int.Parse((sender as RadioButton).Tag.ToString());
        }

        private void timerTitleAnimation_Tick(object sender, EventArgs e)
        {
            if (m_CurrentLengthOfTitle < m_FullTitleText.Length)
            {
                labelTitle.Text += m_FullTitleText.ElementAt(m_CurrentLengthOfTitle);
                m_CurrentLengthOfTitle++;
            }
            else
            {
                m_TitleAnimationStoppedStartTime = DateTime.Now;
                timerTitleAnimation.Enabled = false;
                timerTitleAnimation.Stop();
                timerTitleHold.Enabled = true;
                timerTitleHold.Start();
            }
        }

        private void timerTitleHold_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - m_TitleAnimationStoppedStartTime).TotalSeconds > k_SecondsToWaitForAnimationToStartOver)
            {
                timerTitleHold.Stop();
                timerTitleHold.Enabled = false;
                labelTitle.Text = string.Empty;
                m_CurrentLengthOfTitle = 0;
                timerTitleAnimation.Enabled = true;
                timerTitleAnimation.Start();
            }
        }

        private void formGameSettings_Load(object sender, EventArgs e)
        {
            m_FullTitleText = labelTitle.Text;
            labelTitle.Text = string.Empty;
            timerTitleAnimation.Enabled = true;
            timerTitleAnimation.Start();
        }

        private void formGameSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerTitleAnimation.Enabled = false;
            timerTitleHold.Enabled = false;
        }
    }
}